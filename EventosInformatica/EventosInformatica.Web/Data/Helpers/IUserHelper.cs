﻿using EventosInformatica.Web.Models;
using EventosInformatica.Web.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosInformatica.Web.Data.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRole(User user, string roleName);
        Task<bool> IsUserInRole(User user, string roelName);

        Task<SignInResult> LoginAsync(LoginViewModel loginViewModel);
        Task LogoutAsync();

        // Unidad 4
        Task<SignInResult> ValidatePasswordAsync(User user, string password);
    }
}
