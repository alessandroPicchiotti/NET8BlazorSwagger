using AppClient.Class;
using AppClient.Services.Interfaces;
using BaseLibrary.Entities;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace AppClient.Services.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<MyAppSettings> sett;
        private  int _totale;

        public UserService(HttpClient  httpClient, IOptions<MyAppSettings> sett) 
        {
            this.httpClient = httpClient;
            this.sett = sett;
        }

        public int Totale => _totale;

        public async Task<List<User>> GetUsers()
        {
            //User[] temp = new[] { new User(){ email="",id=0,name=""} };            
            User[] user= await httpClient.GetFromJsonAsync<User[]>($"{sett.Value.Url}Users") ?? new[] { new User() };//temp;
            if (user != null ) {
                this._totale = user.Length;
                return user.ToList<User>();
            }
            else
            {
                return new List<User>();
            }
        }
    }
}
