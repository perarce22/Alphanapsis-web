using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Entidades.Custom;

namespace USD.Alphanapsis.Dto
{
    public class EntidadBaseDto
    {
        [Required]
        public bool FlagActivo { get; set; }
        [Required]
        public bool FlagEliminado { get; set; }
        [Required]
       
        [MaxLength(100)]
        public string CreadoPor { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
       
        [MaxLength(100)]
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        
        public string Estado
        {
            get { return this.FlagActivo ? "Activo" : "Inactivo"; }
        }
        
        public string EstadoProyecto
        {
            get { return this.FlagActivo ? "Abierto" : "Cerrado"; }
        }
        
        public string EstadoEliminado
        {
            get { return this.FlagEliminado ? "Eliminado" : "Activo"; }
        }

        
        public string FechaCreacionStr
        {
            get { return this.FechaCreacion.ToString("dd/MM/yyyy"); }
        }
        
        public string FechaCreacionHoraStr
        {
            get { return this.FechaCreacion.ToString("dd/MM/yyyy HH:mm"); }
        }
        
        public string FechaModificacionStr
        {
            get { return this.FechaModificacion.HasValue ? this.FechaModificacion.Value.ToString("dd/MM/yyyy") : this.FechaCreacion.ToString("dd/MM/yyyy"); }
        }

        
        public string ModificadoPorStr
        {
            get { return this.ModificadoPor == null ? this.CreadoPor : this.ModificadoPor; }
        }
        
        public List<TraduccionDto> ListarTraduccion { set; get; }
    }
}
