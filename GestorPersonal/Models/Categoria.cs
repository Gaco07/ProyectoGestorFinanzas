using GestorPersonal.Areas.Identity.Data;

namespace GestorPersonal.Models
{
    public partial class Categoria
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? UsuarioId { get; set; }
    }
}
