using System;
using USD.Alphanapsis.Data;
using System.Linq;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Entidades;
using USD.Alphanapsis.Utiles;

namespace USD.Alphanapsis.Servicios.Repository
{
    public class CorrelativoRepository : ICorrelativoRepository
    {
        private readonly ApplicationDbContext _bd;
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public CorrelativoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public Correlativo ObtenerCorrelativo(int tipoCorrelativo, int centroId, string usuario)
        {
            try
            {
                //IRepositorio<Correlativo> rep = new EfRepositorio<Correlativo>(ctx);
                var correlativo = _bd.Correlativo.Where(m => m.TipoCorrelativo == tipoCorrelativo && m.FechaCreacion.Year == DateTime.Now.Year &&
                                                       m.FechaCreacion.Month == DateTime.Now.Month).OrderByDescending(p => p.CorrelativoId).FirstOrDefault();

                var indent = centroId.ToString().PadLeft(1, '0');
                var year = DateTime.Now.ToString("yy");
                var month = DateTime.Now.Month.ToString().PadLeft(2, '0');
                var day = DateTime.Now.Day.ToString().PadLeft(2, '0');

                if (correlativo == null)
                {
                    return new Correlativo()
                    {
                        Valor = 1,
                        Ceros = indent + year + month + "000",
                        FechaCreacion = DateTime.Now,
                        CreadoPor = usuario,
                        FlagActivo = true,
                        TipoCorrelativo = tipoCorrelativo,
                        Prefijo = Util.GetEnumDescription((TipoCorrelativo)tipoCorrelativo)
                    };
                }
                else
                {
                    return new Correlativo()
                    {
                        Valor = correlativo.Valor + 1,
                        Ceros = indent + year + month + "".PadLeft(4 - (correlativo.Valor + 1).ToString().Length, '0'),
                        FechaCreacion = DateTime.Now,
                        CreadoPor = usuario,
                        FlagActivo = true,
                        TipoCorrelativo = tipoCorrelativo,
                        Prefijo = Util.GetEnumDescription((TipoCorrelativo)tipoCorrelativo)
                    };
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

        }
        public Correlativo RegistrarCorrelativo(int tipoCorrelativo, int centroId, string usuario, DateTime fechaEmision)
        {
            try
            {
                var annio = fechaEmision.Year;
                //IRepositorio<Correlativo> rep = new EfRepositorio<Correlativo>(ctx);
                var correlativo = _bd.Correlativo.Where(m => m.TipoCorrelativo == tipoCorrelativo && m.FechaEmision.Year == annio &&
                                                       m.FechaEmision.Month == fechaEmision.Month &&
                                                       m.FechaEmision.Day == fechaEmision.Day).OrderByDescending(p => p.CorrelativoId).FirstOrDefault();

                var indent = centroId.ToString().PadLeft(2, '0');
                var year = fechaEmision.ToString("yy");
                var month = fechaEmision.Month.ToString().PadLeft(2, '0');
                var day = fechaEmision.Day.ToString().PadLeft(2, '0');

                if (correlativo == null)
                {
                    _bd.Correlativo.Add(new Correlativo()
                    {
                        Valor = 1,
                        Ceros = indent + year + month + day + "00",
                        FechaEmision = fechaEmision,
                        FechaCreacion = DateTime.Now,
                        CreadoPor = usuario,
                        FlagActivo = true,
                        TipoCorrelativo = tipoCorrelativo,
                        Prefijo = Util.GetEnumDescription((TipoCorrelativo)tipoCorrelativo)
                    });
                }
                else
                {
                    _bd.Correlativo.Add(new Correlativo()
                    {
                        Valor = correlativo.Valor + 1,
                        Ceros = indent + year + month + day + "".PadLeft(3 - (correlativo.Valor + 1).ToString().Length, '0'),
                        FechaEmision = fechaEmision,
                        FechaCreacion = DateTime.Now,
                        CreadoPor = usuario,
                        FlagActivo = true,
                        TipoCorrelativo = tipoCorrelativo,
                        Prefijo = Util.GetEnumDescription((TipoCorrelativo)tipoCorrelativo)
                    });

                }

                _bd.SaveChanges();
                correlativo = _bd.Correlativo.Where(m => m.TipoCorrelativo == tipoCorrelativo && m.FechaEmision.Year == annio &&
                                                   m.FechaEmision.Month == fechaEmision.Month &&
                                                   m.FechaEmision.Day == fechaEmision.Day).OrderByDescending(p => p.CorrelativoId).FirstOrDefault();
                return correlativo;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }

        }

    }
}
