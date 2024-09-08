using Backend.Models;
using Microsoft.AspNetCore.Mvc;
namespace Backend.Data
{
    public class ComentariosRepositorio : IComentariosRepositorio
    {
        AppDbContext _entityFramework;
        public ComentariosRepositorio(IConfiguration config)
        {
            _entityFramework = new AppDbContext(config);
        }
        public bool SaveChanges()
        {
            return _entityFramework.SaveChanges() > 0;
        }
        public void AddEntity<T>(T entity)
        {
            if (entity != null)
            {
                _entityFramework.Add(entity);
            }
        }
        public void RemoveEntity<T>(T entity)
        {
            if (entity != null)
            {
                _entityFramework.Remove(entity);
            }
        }

        //////////////////////
        ///
        public IEnumerable<Comentarios> GetComentarios()
        {
            IEnumerable<Comentarios> comentarios = _entityFramework.Comentarios.ToList<Comentarios>();
            return comentarios;
        }
        public Comentarios GetSingleComentario(int idComentario)
        {
            Comentarios? comentario = _entityFramework.Comentarios.Where(comentario => comentario.IdComentario == idComentario).FirstOrDefault();

            if (comentario != null)
            {
                return comentario;
            }
            throw new Exception("Failed to Get Customer");
        }

        /*
        public Comentarios EditCustomer(Comentarios customer)
        {
            Comentarios? CustomerOnDb = _entityFramework.Comentarios.Where(customer => customer.IdentificationNumber == customer.IdentificationNumber).FirstOrDefault();

            if (CustomerOnDb != null)
            {
                CustomerOnDb.Name = customer.Name ?? CustomerOnDb.Name;
                CustomerOnDb.LastNamer = customer.LastNamer ?? CustomerOnDb.LastNamer;
                CustomerOnDb.Email = customer.Email ?? CustomerOnDb.Email;
                CustomerOnDb.Phone = customer.Phone ?? CustomerOnDb.Phone;
                CustomerOnDb.Adress = customer.Adress ?? CustomerOnDb.Adress;
                CustomerOnDb.TypeOfCustomer = customer.TypeOfCustomer ?? CustomerOnDb.TypeOfCustomer;
                CustomerOnDb.IsCustomerActicve = customer.IsCustomerActicve || CustomerOnDb.IsCustomerActicve;
                if (_entityFramework.SaveChanges() > 0)
                {
                    return CustomerOnDb;
                }
            }
            throw new Exception("Failed to Update or edit Customer or was not found");
        }
        public IActionResult AddCustomer(Comentarios customer)
        {
            Comentarios customerToDb = new Comentarios();


            customerToDb.Name = customer.Name;
            customerToDb.LastNamer = customer.LastNamer;
            customerToDb.Email = customer.Email;
            customerToDb.Phone = customer.Phone;
            customerToDb.Adress = customer.Adress;
            customerToDb.TypeOfCustomer = customer.TypeOfCustomer;
            customerToDb.IsCustomerActicve = customer.IsCustomerActicve;
            customerToDb.IdentificationNumber = customer.IdentificationNumber;
            _entityFramework.Add(customerToDb);
            if (_entityFramework.SaveChanges() > 0)
            {
                return (IActionResult)customerToDb;
            }
            throw new Exception("Failed to Add Customer");
        }
        public IActionResult DeleteCustomer(int identificationNumber)
        {
            Comentarios? CustomerOnDb = _entityFramework.Comentarios.Where(customer => customer.IdentificationNumber == identificationNumber).FirstOrDefault<Comentarios>();

            if (CustomerOnDb != null)
            {
                _entityFramework.Comentarios.Remove(CustomerOnDb);
                if (_entityFramework.SaveChanges() > 0)
                {
                    return (IActionResult)CustomerOnDb;
                }
            }
            throw new Exception("Failed to Update or delete Customer");

        }

        */
    }
}
