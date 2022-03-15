using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Dto
{
    public static class InitAutoMapper
    {
        public static IMapper mapper = null;
        public static bool autoMapper = false;

        public static void Start()
        {
            if (!autoMapper)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Usuario, UsuarioDto>().MaxDepth(7);
                    cfg.CreateMap<UsuarioDto, Usuario>().MaxDepth(7);

                    cfg.CreateMap<UsuarioSede, UsuarioSedeDto>().MaxDepth(7);
                    cfg.CreateMap<UsuarioSedeDto, UsuarioSede>().MaxDepth(7);
                });
                mapper = config.CreateMapper();
                autoMapper = true;
            }
        }
        }
}
