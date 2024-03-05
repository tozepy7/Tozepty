using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TozeptyDAL.Data;
using TozeptyDAL.Interfaces;

namespace TozeptyDAL.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly FoodDbContext dbContext;

        public AdminRepository(FoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveAdminchanges()
        {
            dbContext.SaveChanges();
        }

        //Create Admin
        public Admin CreateAdmin(Admin admin)
        {
            dbContext.Admins.Add(admin);
            dbContext.SaveChanges();
            return admin;
        }

        //Get admin data using username and phone
        public Admin GetAdminByUserNamePhone(string userName, string phoneNumber)
        {
            var result = dbContext.Admins.FirstOrDefault(l =>
                l.UserName == userName && l.PhoneNumber == phoneNumber
            );
            return result;
        }

        //Get Admin name using id
        public string GetAdminName(int adminId)
        {
            var username = dbContext
                .Admins.Where(a => a.Id == adminId)
                .Select(a => a.UserName)
                .FirstOrDefault();

            return username;
        }

        //Delete the admin

        public Admin UpdateAdmin(Admin admin)
        {
            //We will find the admin exist or not
            var existingAdmin = dbContext.Admins.Find(admin.Id);
            if (existingAdmin != null) //If not null then we will update
            {
                existingAdmin.FirstName = admin.FirstName;
                existingAdmin.LastName = admin.LastName;
                existingAdmin.Email = admin.Email;
                existingAdmin.PhoneNumber = admin.PhoneNumber;
                existingAdmin.UserName = admin.UserName;
                existingAdmin.Password = admin.Password;
                existingAdmin.RoleId = admin.RoleId;

                dbContext.SaveChanges(); //save the changes
            }

            return existingAdmin; //return updated admin , or else returns null if no data is found/updated
        }

        public Admin DeleteAdmin(int adminId)
        {
            //Find the admin by id
            var admin = dbContext.Admins.Find(adminId);

            if (admin != null)
            {
                dbContext.Admins.Remove(admin); //mark given identity deleted
                dbContext.SaveChanges(); //save the changes
            }

            return admin;
        }

        //Get Admin by username
        public Admin GetAdminByUserName(string userName)
        {
            var result = dbContext.Admins.FirstOrDefault(a => a.UserName == userName);

            return result;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return dbContext.Admins.ToList();
        }

        public Admin GetAdminById(int adminId)
        {
            return dbContext.Admins.Find(adminId);
        }

        public bool CheckAdminExistsByEmail(string UserEmail)
        {
            return dbContext.Admins.Any(a => a.Email == UserEmail);
        }

        public bool CheckAdminExists(string userName)
        {
            return dbContext.Admins.Any(a => a.UserName == userName);
        }
    }
}
