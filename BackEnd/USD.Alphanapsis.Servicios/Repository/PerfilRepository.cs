using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Data;
using System.Linq;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public PerfilRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public ICollection<Perfil> ListarPerfil(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros)
        {

            
            {
                try
                {
                    //IRepositorio<Perfil> rep = new EfRepositorio<Perfil>(ctx);
                    var lista = (from a in _bd.Perfil
                                 where (a.FlagActivo == estado || !estado.HasValue)
                                 && (string.IsNullOrEmpty(filtro) || a.Nombre.Contains(filtro.ToUpper()))
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.PerfilId,
                                     a.FlagActivo
                                 });
                    nroTotalRegistros = lista.Count();
                    lista = lista.Skip((page - 1) * rows).Take(rows);
                    var listaFinal = (from a in lista.ToList()
                                      select new Perfil
                                      {
                                          Nombre = a.Nombre,
                                          PerfilId = a.PerfilId,
                                          FlagActivo = a.FlagActivo
                                      }).ToList();
                    return listaFinal;
                }
                 
                catch (Exception ex)
                {
                    log.Error("Error ", ex);
                    throw new USDException(ExceptionIds.Perfil, "Error en el metodo: List<Perfil>.", new object[] { null });
                }
            }
        }

        public Perfil ObtenerPerfil(int id)
        {
            try
            {
                
                {
                    //IRepositorio<Perfil> rep = new EfRepositorio<Perfil>(ctx);
                    return _bd.Perfil.Find(id);
                }
            }
            
            catch (Exception ex)
            {
                log.Error("Error ", ex);
                throw new USDException(ExceptionIds.Perfil, "Error en el metodo: ObtenerPerfil.", new object[] { null });
            }
        }

        public void EliminaPerfil(int id, string usuario)
        {
            
            {
                try
                {
                    //IRepositorio<Perfil> rep = new EfRepositorio<Perfil>(ctx); 
                    var obj = _bd.Perfil.Find(id);
                    obj.ModificadoPor = usuario;
                    obj.FechaModificacion = DateTime.Now;
                    _bd.SaveChanges();
                }
               
                catch (Exception ex)
                {
                    log.Error("Error ", ex);
                    throw new USDException(ExceptionIds.Perfil, "Error en el metodo: EliminaServicio.", new object[] { null });
                }
            }
        }

        public int RegistrarPerfil(Perfil perfil)
        {
            
            {
                try
                {
                    if (perfil.PerfilId == 0)
                    {
                        _bd.Perfil.Add(perfil);
                        _bd.SaveChanges();
                        return perfil.PerfilId;
                    }
                    else
                    {
                        var act = _bd.Perfil.FirstOrDefault(m => m.PerfilId == perfil.PerfilId);
                        act.Nombre = perfil.Nombre;
                        act.PerfilId = perfil.PerfilId;
                        _bd.SaveChanges();
                        return act.PerfilId;
                    }
                }
                 
                catch (Exception ex)
                {
                    log.Error("Error ", ex);
                    throw new USDException(ExceptionIds.Perfil, "Error en el metodo: RegistrarServicio.", new object[] { null });
                }
            }
        }

        public ICollection<Perfil> ListarPerfil()
        {

            
            {
                try
                {
                    //IRepositorio<Perfil> rep = new EfRepositorio<Perfil>(ctx);
                    var lista = (from a in _bd.Perfil
                                 where (a.FlagActivo == true)
                                 && a.FlagEliminado == false
                                 orderby a.Nombre ascending
                                 select new
                                 {
                                     a.Nombre,
                                     a.PerfilId,
                                     a.FlagActivo
                                 });

                    var listaFinal = (from a in lista.ToList()
                                      select new Perfil
                                      {
                                          Nombre = a.Nombre,
                                          PerfilId = a.PerfilId,
                                          FlagActivo = a.FlagActivo
                                      }).ToList();
                    return listaFinal;
                }
                
                catch (Exception ex)
                {
                    log.Error("Error ", ex);
                    throw new USDException(ExceptionIds.Perfil, "Error en el metodo: List<Perfil>.", new object[] { null });
                }
            }
        }

        public ICollection<OpcionPerfilDto> ListarPerfilOpciones(int? perfilId, int page, int rows, out int nroTotalRegistros)
        {
            
            {
                //IRepositorio<Opcion> rep = new EfRepositorio<Opcion>(ctx);
                //IRepositorio<OpcionPerfil> repOP = new EfRepositorio<OpcionPerfil>(ctx);

                var lista1 = (from a in _bd.Opcion
                              join aa in _bd.Opcion on a.ParentId equals aa.OpcionId into p0
                              from q0 in p0.DefaultIfEmpty()
                              join b in _bd.OpcionPerfil on a.OpcionId equals b.OpcionId
                              where a.FlagActivo == true &&
                                    a.FlagEliminado == false &&
                                    b.FlagActivo == true &&
                                    b.FlagEliminado == false &&
                                    b.PerfilId == perfilId
                              select new
                              {
                                  a.OpcionId,
                                  a.Etiqueta,
                                  Parent = q0 == null ? "" : q0.Etiqueta,
                                  a.Url,
                                  a.ParentId,
                                  a.Orden,
                                  Flag = true,
                                  b.OpcionPerfilId
                              }).ToList().Select(m => new OpcionPerfilDto()
                              {
                                  Opcion = new OpcionDto()
                                  {
                                      OpcionId = m.OpcionId,
                                      Etiqueta = m.Etiqueta,
                                      Parent = m.Parent,
                                      Url = m.Url,
                                      ParentId = m.ParentId,
                                      Orden = m.Orden,
                                      Flag = m.Flag
                                  },
                                  OpcionPerfilId = m.OpcionPerfilId
                              }).ToList();

                var lista2 = (from a in _bd.Opcion
                              join aa in _bd.Opcion on a.ParentId equals aa.OpcionId into p0
                              from q0 in p0.DefaultIfEmpty()
                              where a.FlagActivo == true &&
                                   a.FlagEliminado == false
                              select new
                              {
                                  a.OpcionId,
                                  a.Etiqueta,
                                  Parent = q0 == null ? "" : q0.Etiqueta,
                                  a.Url,
                                  ParentId = q0 == null ? a.OpcionId : a.ParentId,
                                  a.Orden,
                                  Flag = false,
                                  OpcionPerfilId = 0
                              }).ToList().Select(m => new OpcionPerfilDto()
                              {
                                  Opcion = new OpcionDto()
                                  {
                                      OpcionId = m.OpcionId,
                                      Etiqueta = m.Etiqueta,
                                      Parent = m.Parent,
                                      Url = m.Url,
                                      ParentId = m.ParentId,
                                      Orden = m.Orden,
                                      Flag = m.Flag
                                  },
                                  OpcionPerfilId = m.OpcionPerfilId
                              }).OrderBy(o => o.Opcion.ParentId).ToList();

                var lista3 = lista2.Select(m => new OpcionPerfilDto()
                {
                    Opcion = new OpcionDto()
                    {
                        OpcionId = m.Opcion.OpcionId,
                        Etiqueta = m.Opcion.Etiqueta,
                        Parent = m.Opcion.Parent,
                        Url = m.Opcion.Url,
                        ParentId = m.Opcion.ParentId,
                        Orden = m.Opcion.Orden,
                        Flag = (lista1.Count(p => p.Opcion.OpcionId == m.Opcion.OpcionId)) > 0 ?
                                      lista1.FirstOrDefault(p => p.Opcion.OpcionId == m.Opcion.OpcionId).Opcion.Flag : m.Opcion.Flag
                    },
                    OpcionPerfilId = (lista1.Count(p => p.Opcion.OpcionId == m.Opcion.OpcionId)) > 0 ?
                                      lista1.FirstOrDefault(p => p.Opcion.OpcionId == m.Opcion.OpcionId).OpcionPerfilId : m.OpcionPerfilId
                });

                nroTotalRegistros = lista3.Count();
                lista3 = lista3.Skip((page - 1) * rows).Take(rows);

                return lista3.ToList();

            }
        }

        public bool ActualizaOpcionPerfil(OpcionPerfilDto opcionPerfil)
        {
            var proc = false;

            
            {

                //IRepositorio<OpcionPerfil> rep = new EfRepositorio<OpcionPerfil>(ctx);

                var lista = (from a in _bd.OpcionPerfil
                             where a.OpcionPerfilId == opcionPerfil.OpcionPerfilId && a.OpcionId == opcionPerfil.OpcionId
                             select new
                             {
                                 a.OpcionPerfilId,
                                 a.PerfilId,
                                 a.OpcionId,
                                 a.CreadoPor,
                                 a.FlagActivo,
                                 a.ModificadoPor,
                                 a.FlagEliminado
                             });

                var perfilOpcionData = (from a in lista.ToList()
                                        select new OpcionPerfil
                                        {
                                            OpcionPerfilId = a.OpcionPerfilId,
                                            PerfilId = a.PerfilId,
                                            OpcionId = a.OpcionId,
                                            CreadoPor = a.CreadoPor,
                                            FlagActivo = a.FlagActivo,
                                            ModificadoPor = a.ModificadoPor,
                                            FlagEliminado = a.FlagEliminado
                                        }).ToList().FirstOrDefault();

                if (perfilOpcionData != null)
                {
                    var dato = _bd.OpcionPerfil.Find(perfilOpcionData.OpcionPerfilId);

                    dato.FlagActivo = opcionPerfil.Flag;
                    dato.FlagEliminado = opcionPerfil.Flag == true ? false : true;
                    dato.ModificadoPor = opcionPerfil.ModificadoPor;
                    dato.FechaModificacion = opcionPerfil.FechaModificacion;

                    _bd.SaveChanges();
                }
                else
                {
                    var opcionPerfilNew = new OpcionPerfil()
                    {
                        PerfilId = opcionPerfil.PerfilId,
                        OpcionId = opcionPerfil.OpcionId,
                        FechaCreacion = opcionPerfil.FechaCreacion,
                        CreadoPor = opcionPerfil.CreadoPor,
                        FlagActivo = opcionPerfil.Flag,
                        FlagEliminado = opcionPerfil.Flag == true ? false : true
                    };

                    _bd.OpcionPerfil.Add(opcionPerfilNew);
                    _bd.SaveChanges();

                }

                proc = true;
            }

            return proc;
        }
    }
}
