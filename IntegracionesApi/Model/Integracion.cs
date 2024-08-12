using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;


namespace IntegracionesApi.Model
{
    public class Integracion
    {
        [Key]    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cliente { get; set; }
        public string Us { get; set; }
    }//
}
