using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ProjectTracker.Models
{
    public class LogProcesso
    {
        [Key]
        public int Id { get; set; }
        //public int IdUsuario  { get; set; }         
        //public int IdEmpresa { get; set; }         
        //public int IdProcesso { get; set; }
        //
        [Required]
        public string Status { get; set; } = String.Empty;
        public long? TempoDecorrido { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        //public DateTime? DataCadastro { get; set; }

        [Required]
        public int IdProcessoUsuario { get; set; }
        public virtual ProcessoUsuario? ProcessoUsuario { get; set; }
        //public virtual Usuario Usuario { get; set; } = new Usuario();
        //public virtual Empresa Empresa { get; set; } = new Empresa();
        //public virtual Processo Processo { get; set; }  = new Processo();



    }
}                               
