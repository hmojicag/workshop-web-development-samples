using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace samplewebapp.Dto {

    public class Puestos {
        
        public string Puesto { get; set; }
        
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        
        public string Categoria { get; set; }
        
        public string Depende { get; set; }
        
        public decimal ValorMinimo { get; set; }
        
        public decimal ValorMaximo { get; set; }
        
        public string SATRiesgoPuesto { get; set; }
        
    }
}