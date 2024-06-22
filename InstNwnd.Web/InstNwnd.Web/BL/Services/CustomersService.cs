using InstNwnd.Web.BL.Interfaces;
using InstNwnd.Web.Data.Interfaces;


namespace InstNwnd.Web.BL.Services;

public class CustomersService : ICustomersServices
{
    private readonly ICustomersDb CustomersDb;

    public CustomersService(ICustomersDb CustomersDb)
    {
        this.CustomersDb = CustomersDb;
    }

   
}
