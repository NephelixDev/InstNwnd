using InstNwnd.Web.BL.Interfaces;
using InstNwnd.Web.Data.Interfaces;


namespace InstNwnd.Web.BL.Services;

public class Order_DetailsService : IOrder_DetailsService
{
    private readonly IOrder_DetailsDb Order_DetailsDb;

    public Order_DetailsService(IOrder_DetailsDb Order_DetailsDb)
    {
        this.Order_DetailsDb = Order_DetailsDb;
    }

    
}
