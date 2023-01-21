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
            var req = new HttpRequestMessage(HttpMethod.Post, "api/User");
            req.Headers.Add("login", login);
            req.Headers.Add("password", password);
            await _httpClient.SendAsync(req);
        }
        catch
        {
            throw;
        }
    }


}
