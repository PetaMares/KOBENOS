using System;
using System.Collections.Generic;
using System.Text;

namespace kobenos.category.test
{
    public class SystemAccess
    {
        public List<string> SystemAccessKeys = new List<string> {
            "MinimumPasswordAge",
            "MaximumPasswordAge",
            "MinimumPasswordLength",
            "PasswordComplexity",
            "PasswordHistorySize",
            "LockoutBadCount",
            "RequireLogonToChangePassword",
            "ForceLogoffWhenHourExpire",
            "NewAdministratorName",
            "NewGuestName",
            "ClearTextPassword",
            "LSAAnonymousNameLookup",
            "EnableAdminAccount",
            "EnableGuestAccount"
        };

        public void Execute() 
        {
            Parse p = new Parse();
            p.ReadText();
            p.ParseText(p.listSystemAccess, SystemAccessKeys);
        }

        //vyhodnocení jednotlivých hodnot
        public bool MinimumPasswordAge(string val)
        {
            bool result = false;
            
                switch (val) 
                {
                    case "0":
                        result = true;
                        break;
                    default:
                        result = false;
                        break;
                }
            
            return result;
        }
        public bool MaximumPasswordAge(string val)
        {
            bool result = false;

            switch (val)
            {
                case "42":
                    result = true;
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }
        public bool MinimumPasswordLength(string val)
        {
            bool result = false;

            switch (val)
            {
                case "0":
                    result = true;
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }
        
    }
}
