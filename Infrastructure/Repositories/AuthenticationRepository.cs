using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{

    private readonly BackendDbContext _context;

    public AuthenticationRepository(BackendDbContext context)
    {
        _context = context;
    }
    

    public async Task<User?> LoginAsync(UserLoginDTO userLoginDTO)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userLoginDTO.Email);
        if (user == null) return null;

        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(user, user.Password, userLoginDTO.Password);

        return result == PasswordVerificationResult.Success ? user : null;
    }
}