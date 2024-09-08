namespace Backend.Models
{
    public class Formularios
    {
        public int IdFormularios { get; set; }
        public enum TipoFormulario
        {
            Productos,
            Servicios,
            Donaciones,
            Refugio
        } 
        public string NombreRefugio{ get; set; }
        public int TipoOrganizacion { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaFundacion{ get; set; }
        public int IdTipoDocument { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string TelegfonoRef { get; set; }
        public string NombreRef { get; set; }
        public string ApellidoRef { get; set; }
        public bool Terminos { get; set; }
        public int IdProdcServ { get; set; }
        public string Contacto { get; set; }
    }
}
