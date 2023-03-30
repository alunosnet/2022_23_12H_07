using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SkinsModulo17e.Data
{
    public class AppRoleProvider : RoleProvider
    {
        private SkinsModulo17eContext db = new SkinsModulo17eContext();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                var utilizador = db.utilizadors.Where(u => u.email == username).First();
                if (utilizador.nome.ToLower()=="admin" )
                    return new string[] { "Administrador" };
                else
                    return new string[] { "Funcionário" };
            }
            catch
            {
                return new string[] { "" };
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                var utilizador = db.utilizadors.Where(u => u.nome == username).First();
                if (utilizador.nome.ToLower() == "admin" && roleName!="Administrador")
                    throw new Exception();
                if (utilizador.nome.ToLower() != "admin" && roleName != "Funcionário")
                    throw new Exception();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return roleName == "Administrador" || roleName == "Funcionário";
        }
    }


}
