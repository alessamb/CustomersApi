namespace CustomersApi.Interface
{
    public interface IAddCustomer

    {
        Task<int> AddClient(Dtos.CreateCustomerDto customer);
    }
}
