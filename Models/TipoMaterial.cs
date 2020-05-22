namespace Models
{
    public class TipoMaterial
    {
        public short TipoMaterialId { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public byte EstatusId { get; set; }
        public string ErpId { get; set; }
    }
}