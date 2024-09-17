namespace CustomersApi.Interface
{
    public interface IUpdateCustomer
    {
        Task<Dtos.CustomerDto> Execute(Dtos.CustomerDto customer);
    }
}
