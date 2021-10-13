using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioApi.Models
{
    public class Inventario
    {
        [Key]
        [Required(ErrorMessage = "El nombre del Producto es requerido")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El nombre del Producto debe contener entre 2 a 60 caracteres")]
        public string Producto { get; set; }
        [Display(Name = "Precio del producto")]
        public int Precio { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La letra de la cancion debe contener entre 3 a 600 caracteres")]
        [Display(Name = "Descripcion del producto ")]
        public string Descripcion { get; set; }
        [Display(Name = "Cantidad del producto ")]
        public int Cantidad { get; set; }
    }
}
