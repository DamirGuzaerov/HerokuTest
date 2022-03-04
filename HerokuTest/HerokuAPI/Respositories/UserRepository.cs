using HerokuAPI.Models;
using HerokuAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace HerokuAPI.Respositories;

public class UserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByIdAsync(int id) =>
        await _context.Users.FirstOrDefaultAsync(user => user != null && user.UserId == id);
    
    public async Task CreateUser(User? user) {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}