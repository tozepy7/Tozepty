using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TozeptyDAL.Interfaces
{
    public interface IAdminRepository
    {

        Admin CreateAdmin(Admin admin); 

        string GetAdminName(int adminId); 

        // Read
        bool CheckAdminExistsByEmail(string UserEmail);
        bool CheckAdminExists(string userName);

        Admin GetAdminById(int adminId);

        IEnumerable<Admin> GetAllAdmins();
        //bool AdminExistsEmail(string UserEmail, int id);

        // Update
        Admin UpdateAdmin(Admin admin); 

        // Delete
        Admin DeleteAdmin(int adminId);  
        Admin GetAdminByUserName(string userName); 
        void SaveAdminchanges();  
        Admin GetAdminByUserNamePhone(string userName, string phoneNumber); 
    }
}
