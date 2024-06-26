﻿using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Stakeholders.Core.Domain.Users;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System.Data;

using System.Net;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories;

public class UserDatabaseRepository : IUserRepository
{
    private readonly StakeholdersContext _dbContext;

    public UserDatabaseRepository(StakeholdersContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Exists(string username)
    {
        return _dbContext.Users.Any(user => user.Username == username);
    }

    public User? GetActiveByName(string username)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Username == username && user.IsActive);
    }
    public User GetUserByToken(string token)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Token == token);
    }
    public long GetHighestUserId()
    {
        long highestUserId = _dbContext.Users
            .OrderByDescending(user => user.Id)
            .Select(user => user.Id)
            .FirstOrDefault();

        return highestUserId;
    }

    public User Create(User user)
    {
        user.Id = GetHighestUserId() + 1;
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return user;
    }

    public long GetPersonId(long userId)
    {
        var person = _dbContext.People.FirstOrDefault(i => i.UserId == userId);
        if (person == null) throw new KeyNotFoundException("Not found.");
        return person.Id;
    }

    public User Get(int id)
    {
        return _dbContext.Users.FirstOrDefault(i => i.Id == id);
    }

    public List<long> GetAllUserIds()
    {
        return _dbContext.Users.Select(user => user.Id).ToList();
    }

    public Result<object> GetUserById(long userId)
    {
        try
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var credentialsDto = new CredentialsDto
                {
                    Username = user.Username,
                    Password = user.Password,
                };

                return Result.Ok((object)credentialsDto);

            }
            else
            {
                return Result.Fail("User not found.");
            }
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error: {ex.Message}");
        }

        // Handle any exceptions that may occur during database access
        //return Result.Fail($"Error: {ex.Message}");
    }

    public Result GetUserById(int userId)
    {
       _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        return Result.Ok();
    }


    public User Update(User user)
    {
        try
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new KeyNotFoundException(e.Message);
        }
        return (User)user;
    }

    public string GetTouristEmail(int id)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
        var touristEmail = user.Email;

        return touristEmail;
    }
    
    public User? GetByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(i => i.Email == email);
    }
    
    public List<string> GetAdminEmails()
    {
        var adminEmails = _dbContext.Users
            .Where(user => user.Role == Core.Domain.Users.UserRole.Administrator && user.IsActive)
            .Select(user => user.Email)
            .ToList();

        return adminEmails;
    }

    public string GetUserEmail(long userId)
    {
        var user = _dbContext.Users.Find(userId);

        if (user != null)
        {
            return user.Email;
        }
        else
        {
            return "User not found";
        }
    }

    public List<User> GetAuthors()
    {
        return _dbContext.Users
            .Where(u => u.Role == Core.Domain.Users.UserRole.Author)
            .ToList();
    }
    
    // novo
    public Result<object> GetWholeUserById(long userId)
    {
        try
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var credentialsDto = new UserAccountDto
                {
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    Role = (API.Dtos.UserRole)user.Role,
                    IsActive = user.IsActive,
                };

                return Result.Ok((object)credentialsDto);

            }
            else
            {
                return Result.Fail("User not found.");
            }
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error: {ex.Message}");
        }

        // Handle any exceptions that may occur during database access
        //return Result.Fail($"Error: {ex.Message}");
    }
}


