using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USD.Alphanapsis.Data;
using USD.Alphanapsis.Dto.Custom;
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

        public   ICollection<TraduccionDto> ListarTraduccion(string prefijo)
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
                                 select new TraduccionDto()
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
    }
}
