using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public short? PiezasUnidad { get; set; }

        public decimal? Costo { get; set; }

        public short? ColorId { get; set; }

        [Required]
        public short TipoMaterialId { get; set; }

        public byte UnidadCompraId { get; set; }

        [Required]
        public byte UnidadAlmacenId { get; set; }

        [Required]
        public short FamiliaId { get; set; }

        [Required]
        public byte EstatusId { get; set; }

        public string ErpId { get; set; }

        public int? UsuarioCreoId { get; set; }

        public int? UsuarioModificoId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Unidad Unidad { get; set; }

        public TipoMaterial TipoMaterial { get; set; }

        public TipoMaterial Familia { get; set; }
    }


}
