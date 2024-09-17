using CustomersApi.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mysqlx.Crud;
using System.Data.Common;

namespace CustomersApi.Repositories
{
    public class CustomerDatabaseContext : DbContext

    {
        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options) : base(options)
        {


        }


        public DbSet<CustomerEntity> customers { get; set; } //nombre de la tabla

        public async Task<CustomerEntity> Get(long id)
        {
            return await customers.FirstAsync(x => x.Id == id);
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                Id = null,
                fisrtname = customerDto.FirstName,
                lastname = customerDto.LastName,
                email = customerDto.Email,
                phone = customerDto.Phone,
                adress = customerDto.Address

            };

            EntityEntry<CustomerEntity> response = await customers.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.Id ?? throw new Exception("An error occurred while creating the client"));

        }

        public async Task<bool> Update(CustomerEntity customer)
        { 
           customers.Update(customer);
           await SaveChangesAsync();

            return true;
        
        }



    }
    public class CustomerEntity
    {
        public long? Id { get; set; }
        public string fisrtname { get; set; }
        public string lastname { get; set; }
        public string adress { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public CustomerDto toDto()
        {
            return new CustomerDto()
            {
                FirstName = fisrtname,
                LastName = lastname,
                Email = email,
                Phone = phone,
                Address = adress,
                Id = Id ?? throw new Exception("error")
            };
        }

    } 
}