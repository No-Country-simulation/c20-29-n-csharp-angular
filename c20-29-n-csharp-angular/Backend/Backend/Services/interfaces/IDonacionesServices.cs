using Backend.Models;

namespace Backend.Servicios.Interfaces
{
    public interface IDonacionesService
    {

        Task<IEnumerable<Donaciones>> GetDonaciones();
        Task<Donaciones> GetDonacionById(int idDonacion);
        Task<Donaciones> PostDonacion(Donaciones donacion);
        Task<Donaciones> DeleteDonacion(int idDonacion);
        Task<Donaciones> UpdateDonacion(int idDonacion, Donaciones donacion);
        public Task<Donaciones> GetOneDonacion(int idDonacion);
        public bool GuardarCambios();
        public Task<Donaciones> DeleteModelo(int idDonacion);
        public void AgregarEntidad<T>(T endidad);
        public bool ExisteDonacion(int idDonacion);


    }
}
