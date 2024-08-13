﻿using eventManagementAPI.Models;

namespace eventManagementAPI.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
