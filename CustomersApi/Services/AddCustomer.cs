using CustomersApi.Interface;
using CustomersApi.Repositories;

namespace CustomersApi.Services
{
    public class AddCustomer : IAddCustomer
    {

        private readonly CustomerDatabaseContext customerDatabase;

        public AddCustomer(CustomerDatabaseContext _customerDatabase)
        {
            customerDatabase = _customerDatabase;
        }
        public async Task<int> AddClient(Dtos.CreateCustomerDto customer)
        {
            int Id = 0;
            // Validaciones

            string lastName = customer.LastName;
            string firstName = customer.FirstName;
            string address = customer.Address;
            string email = customer.Email;
            string phone = customer.Phone;


            if (lastName == string.Empty)
            { throw new ApplicationException("The name cannot be empty"); }
            else if (lastName.Length > 100)
            { throw new ApplicationException("The name cannot contain more than 100 characters"); }


            if (firstName == string.Empty)
            { throw new ApplicationException("The firstName cannot be empty"); }
            else if (firstName.Length > 100)
            { throw new ApplicationException("The firstName cannot contain more than 100 characters"); }


            if (address == string.Empty)
            { throw new ApplicationException("The address cannot be empty"); }


            bool isValidFormat = System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!isValidFormat) { throw new ApplicationException("The email is not correct"); }
            else if (email == string.Empty)
            { throw new ApplicationException("The email cannot be empty"); }


            if (phone == string.Empty)
            { throw new ApplicationException("The phone cannot be empty"); }

            //Agrego a la base 

            var entity = await customerDatabase.Add(customer);
            if (entity != null)
            {
                Id = (int)entity.Id;
            }
           
            // retorno el id correspondiente
            return Id;

        }
    }
}

