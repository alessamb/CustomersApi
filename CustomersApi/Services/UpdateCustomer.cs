using CustomersApi.Interface;
using CustomersApi.Repositories;

namespace CustomersApi.Services
{
    public class UpdateCustomer : IUpdateCustomer
       
    {
        private readonly CustomerDatabaseContext customerDatabase;

        public UpdateCustomer ( CustomerDatabaseContext _customerDatabase)
        {
            customerDatabase = _customerDatabase;
        }    
       public async Task<Dtos.CustomerDto> Execute(Dtos.CustomerDto customer)
        { 
            var entity =await customerDatabase.Get(customer.Id);
            if (entity == null)
                return null;
            else

            entity.fisrtname = customer.FirstName;
            entity.lastname = customer.LastName;
            entity.email = customer.Email;
            entity.phone = customer.Phone;
            entity.adress = customer.Address;

            await customerDatabase.Update(entity);
            return entity.toDto();    
        
        }
    }
}
