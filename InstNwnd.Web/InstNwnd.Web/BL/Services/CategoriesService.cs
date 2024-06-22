using InstNwnd.Web.BL.Interfaces;
using InstNwnd.Web.Data.Interfaces;



namespace InstNwnd.Web.BL.Services;

public class CategoriesService : ICategoriesService
{
    private readonly ICategoriesDb  CategoriesDb;

    public CategoriesService(ICategoriesDb CategoriesDb)
    {
        this.CategoriesDb = CategoriesDb;
    }

    
}