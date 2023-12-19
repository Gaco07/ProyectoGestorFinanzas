using GestorPersonal.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestorPersonal.Models
{
    public partial class Gasto
    {
        public Gasto()
        {
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? UsuarioId { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }
}
