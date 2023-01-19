using Microsoft.EntityFrameworkCore;
using Shoap.Api.Data;
using Shoap.Api.Entities;
using Shoap.Api.Repositories.Contracts;

namespace Shoap.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ShoapDbContext _context;
	public UserRepository(ShoapDbContext context)
	{
		_context = context;
	}

    public async Task<User?> GetUser(string login)
    {
        var users = await _context.Users.ToListAsync();
        return users.Find(user => user.Login == login);
    }

    public async Task InsertUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetNextId()
    {
        return (await _context.Users.ToListAsync()).Select(user => user.Id).Max() + 1;
    }
}
