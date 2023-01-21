using Shoap.Models.Dtos;
using Shoap.Services.Contracts;
using System.Net.Http.Json;

namespace Shoap.Services;
public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ExistsUser(string login, string password)
    {
        try
        {
            var user = await GetUser(login);
            if(user == null)
            {
                return false;
            }
            return user.Password == password;
        }
        catch
        {
            return false;
        }
    }

    public async Task<UserDto?> GetUser(string login)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<UserDto?>($"api/User/{login}");

        }
        catch
        {
            return null;
        }
    }

    public async Task InsertUser(string login, string password)
    {
        try
        {
            UserDto user = new() { Login = login, Password = password };
            await _httpClient.PostAsJsonAsync("api/User", user);
        }
        catch
        {
            throw;
        }
    }

    public async Task UpdateMoney(UserDto user)
    {
        await _httpClient.PutAsJsonAsync<UserDto>("api/User", user);
    }
}
