using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1626661.model
{
    public class ContactModel
    {
        private int contactId;
        private string contactName;
        private string mobileNo;
        private string email;
        private int userId;

        public int ContactId { get => contactId; set => contactId = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string MobileNo { get => mobileNo; set => mobileNo = value; }
        public string Email { get => email; set => email = value; }
        public int UserId { get => userId; set => userId = value; }
    }
}
