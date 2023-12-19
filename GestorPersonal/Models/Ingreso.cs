using GestorPersonal.Areas.Identity.Data;

namespace GestorPersonal.Models
{
    public partial class Ingreso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? UsuarioId { get; set; }
    }
}
