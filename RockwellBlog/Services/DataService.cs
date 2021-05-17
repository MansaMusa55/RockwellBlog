using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RockwellBlog.Data;
using RockwellBlog.Enums;
using RockwellBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockwellBlog.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IBlogFileService _fileService;
        private readonly UserManager<BlogUser> _userManager;
        private readonly IConfiguration _configuration;

        public DataService(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, IBlogFileService fileService, UserManager<BlogUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _roleManager = roleManager;
            _fileService = fileService;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task ManageDataAsync()
        {
            //Task 0: Make sure the DB is present by running through the migration
            await _context.Database.MigrateAsync();
            //Task 1: Seed Roles and entering them into the system
            await SeedRolesAsync();
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //Are there any roles already in the system
            if (_context.Roles.Any())
                return;

            //Spin tough an enum and do stuff
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //Create a Role in the system for each role
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }


        private async Task SeedUsersAsync()
        {
            if (_context.Users.Any())
            {
                return;
            }
            var adminUser = new BlogUser()
            {
                Email = "SamCannon@mailinator.com",
                UserName = "Mansa",
                FirstName = "Samuel",
                LastName = "Cannon",
                Password = _configuration["AdminPassword"],
                PhoneNumber = "763-283-7237",
                EmailConfirmed = true,
            };

            await _userManager.CreateAsync(adminUser, _configuration["AdminPassword"]);
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());
        }
    }
}
