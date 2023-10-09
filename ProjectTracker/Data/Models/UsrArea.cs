namespace ProjectTracker.Models
{
    public class UsrArea
    {                           
        public int IdUsuario { get; set; }
        public int IdArea { get; set; }
        public DateTime DataCad { get; set; }
        public virtual Usuario Usuario { get; set; } = new Usuario();
        public virtual Area Area { get; set; } = new Area();
    }
}
