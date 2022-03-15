using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD.Alphanapsis.Dto
{
    public class UbigeoDto : EntidadBaseDto
    {
        public int UbigeoId { get; set; }
        [MaxLength(6)]
       
        public string Codigo { get; set; }
        [MaxLength(2)]
       
        public string DepartamentoId { get; set; }
        [MaxLength(50)]
       
        public string Departamento { get; set; }
        [MaxLength(2)]
       
        public string ProvinciaId { get; set; }
        [MaxLength(50)]
       
        public string Provincia { get; set; }
        [MaxLength(2)]
       
        public string DistritoId { get; set; }
        [MaxLength(50)]
       
        public string Distrito { get; set; }

        
        public string DepartamentoProvinciaDistrito { get {
                return string.Format("{0} - {1} - {2}", Departamento, Provincia, Distrito);
            } }
        
        public string DepartamentoProvincia
        {
            get
            {
                return string.Format("{0} - {1}", Departamento, Provincia);
            }
        }



    }
}
