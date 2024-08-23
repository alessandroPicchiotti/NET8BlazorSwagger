using BaseLibrary.Entities;

namespace AppClient.Services.Interfaces
{
    public interface IUserService
    {
       Task<List<User>> GetUsers();
        int Totale { get ;}
    }
}
