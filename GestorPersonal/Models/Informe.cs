using GestorPersonal.Areas.Identity.Data;

namespace GestorPersonal.Models
{
    public partial class Informe
    {
        public int Id { get; set; }
        public string? UsuarioId { get; set; }
        public virtual Gasto? Gasto { get; set; }
    }
}
