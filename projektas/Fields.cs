using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektas
{
    class Fields
    {
        public bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool isValidPassword(string password)
        {
            if (password.Length > 7)
                return true;

            return false;
        }

        public bool isValidPhone(string phone)
        {
           return phone.All(char.IsNumber);
        }

        public bool isValidCarNumber(string carNumber)
        {
            if (carNumber.Length != 6)
                return false;

            for(int i = 0; i < carNumber.Length - 3; i++) {
                string character = Convert.ToString(carNumber[i]);

                if (!character.All(char.IsLetter))
                    return false;
            }

            for (int i = 3; i < carNumber.Length; i++)
            {
                string character = Convert.ToString(carNumber[i]);

                if (!character.All(char.IsDigit))
                    return false;
            }

            return true;
        }
    }
}
