using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tms.Data.AppContext;
using Tms.Service.Common;

namespace Tms.Service.User
{
    public class UserService :BaseService
    {


        public List<AspNetUsers> GetAllUsers()
        {

            var list = Entity.AspNetUsers
                .Include(x => x.AspNetUserRoles)
                .ToList();
            return list;

        }
        public bool UpdateUserRole(string userId, string roleId)
        {
           
            var user = Entity.AspNetUsers.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                
                var userRole = Entity.AspNetUserRoles.FirstOrDefault(ur => ur.UserId == userId);

                if (userRole != null)
                {
                    
                    Entity.AspNetUserRoles.Remove(userRole);
                    Entity.SaveChanges(); 
                }

               
                var newUserRole = new AspNetUserRoles
                {
                    UserId = userId,
                    RoleId = roleId
                };

                Entity.AspNetUserRoles.Add(newUserRole);
                Entity.SaveChanges();
                return true;
            }

            return false;
        }


    }
}
