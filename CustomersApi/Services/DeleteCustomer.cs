namespace CustomersApi.Services;
using CustomersApi.Interface;
using CustomersApi.Repositories;

public class DeleteCustomer :   IDeleteCustomer

{
    private readonly CustomerDatabaseContext customerDatabase;

    public DeleteCustomer(CustomerDatabaseContext _customerDatabase)
    {
        customerDatabase = _customerDatabase;
    }
    
    public async Task<int> Delete(int id)
    {
        //Verifico si el registro a borrar existe

        var entity = await customerDatabase.Get(id);
        if (entity == null)
            return 0;
        else
            //Busco el id en el dba


            return id;
    
    }

}
