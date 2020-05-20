using EventosInformatica.Web.Data.Helpers;
using EventosInformatica.Web.Models;
using EventosInformatica.Web.Models.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosInformatica.Web.Data
{
    public class SeedDb
    {
        private readonly DataDbContext _dataContext;
        private readonly IUserHelper _userHelper;
        public SeedDb(DataDbContext dataDbContext, IUserHelper userHelper)
        {
            _dataContext = dataDbContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync(
                firstname: "Jose Luis",
                lastname: "Cuevas",
                email: "admin@gmail.com",
                phone: "6641234567", 
                rol: "Admin"
            );
            var customer = await CheckUserAsync("Josue", "Montano", "cliente@gmail.com", "6647654321", "Client");
            await CheckManagerAsync(manager);
            await CheckClienteAsync(customer);
        }

        private async Task<User> CheckUserAsync(string firstname, string lastname, string email, string phone, string rol)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FullName = firstname + "" + lastname,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                };

                await _userHelper.AddUserAsync(user, "admin1234");
                await _userHelper.AddUserToRole(user, rol);
            }
            return user;
        }


        private async Task CheckManagerAsync(User manager)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager
                {
                    User = manager
                });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async  Task CheckClienteAsync(User client)
        {
            if (!_dataContext.Clients.Any())
            {
                _dataContext.Clients.Add(new Client 
                {
                    User = client 
                });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Client");
        }

    }
}
