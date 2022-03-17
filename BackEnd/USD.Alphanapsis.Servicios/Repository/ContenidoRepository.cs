using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Entidades;
using USD.Alphanapsis.Entidades.Custom;
using USD.Alphanapsis.Servicios.IRepository;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class ContenidoRepository : IContenidoRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public ContenidoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<Traduccion> ListarTraduccion(string prefijo)
        {
            try
            {
                var lista = (from a in _bd.Idioma
                             join b in _bd.ContenidoEstaticoIdioma on a.IdiomaId equals b.IdiomaId
                             join c in _bd.ContenidoEstatico on b.ContenidoEstaticoId equals c.ContenidoEstaticoId
                             where a.FlagActivo == true
                             && b.FlagActivo == true
                             && c.FlagActivo == true
                             && a.Prefijo.ToUpper() == prefijo.ToUpper()
                             orderby a.Nombre ascending
                             select new
                             {
                                 c.Campo,
                                 b.Valor
                             });
                var resultado = (from a in lista.ToList()
                                 select new Traduccion()
                                 {
                                     Key = a.Campo,
                                     Texto = a.Valor
                                 }).ToList();
                return resultado;
            }

            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
        }
        //TODO: PAP pendiente implementar

        //public override ICollection<ContenidoEstaticoIdiomaDto> ListarContenidoEstatico(int IdiomaId)
        //{
        //    try
        //    {
        //        var lista = new List<ContenidoEstaticoIdioma>();
        //        conexion.Open();
        //        using (var comando = new SqlCommand("USP_LISTAR_CONTENIDO_TRADUCIDO", conexion))
        //        {
        //            comando.CommandType = CommandType.StoredProcedure;
        //            comando.Parameters.Add(new SqlParameter() { ParameterName = "@IdiomaId", SqlDbType = SqlDbType.NVarChar, Value = IdiomaId, Direction = ParameterDirection.Input, IsNullable = true });
        //            using (SqlDataReader rdr = comando.ExecuteReader(CommandBehavior.CloseConnection))
        //            {
        //                if (rdr.HasRows)
        //                {
        //                    var colidiomaid = rdr.GetOrdinal("idiomaid");
        //                    var colcontenidoestaticoid = rdr.GetOrdinal("contenidoestaticoid");
        //                    var colValor = rdr.GetOrdinal("Valor");
        //                    var colcontenidoestaticoidiomaid = rdr.GetOrdinal("contenidoestaticoidiomaid");
        //                    var colCampo = rdr.GetOrdinal("Campo");
        //                    while (rdr.Read())
        //                    {
        //                        lista.Add(new ContenidoEstaticoIdioma()
        //                        {
        //                            ContenidoEstaticoIdiomaId = rdr.GetValueInt32(colcontenidoestaticoidiomaid),
        //                            Valor = rdr.GetValueString(colValor),
        //                            Idioma = new Idioma()
        //                            {
        //                                IdiomaId = rdr.GetValueInt32(colidiomaid)
        //                            },
        //                            ContenidoEstatico = new ContenidoEstatico()
        //                            {
        //                                ContenidoEstaticoId = rdr.GetValueInt32(colcontenidoestaticoid),
        //                                Campo = rdr.GetValueString(colCampo),
        //                            }
        //                        });

        //                    }
        //                    rdr.Close();
        //                }
        //            }
        //        }
        //        conexion.Close();
        //        return lista;

        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //        throw ex;
        //    }
        //}
        public   void GrabarTraduccion(ICollection<ContenidoEstaticoIdioma> contenido, string usuario)
        {


            try
            {
                foreach (var item in contenido)
                {
                    if (item.ContenidoEstaticoIdiomaId == 0)
                    {
                        _bd.Set<ContenidoEstaticoIdioma>().Add(
                            new ContenidoEstaticoIdioma()
                            {
                                IdiomaId = item.IdiomaId,
                                ContenidoEstaticoId = item.ContenidoEstaticoId,
                                Valor = item.Valor,
                                FechaCreacion = DateTime.Now,
                                CreadoPor = usuario
                            }
                            );
                    }
                    else
                    {
                        var traduccion = _bd.Set<ContenidoEstaticoIdioma>().FirstOrDefault(x => x.ContenidoEstaticoIdiomaId == item.ContenidoEstaticoIdiomaId);
                        traduccion.Valor = item.Valor;
                        traduccion.FechaModificacion = DateTime.Now;
                        traduccion.ModificadoPor = usuario;
                    }
                }
                _bd.SaveChanges();
            }

            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

        }
    }
}
