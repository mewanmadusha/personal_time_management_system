using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1626661.model
{
    public class EventModel
    {
        private int event_id;
        private string event_title;
        private string event_description;
        private DateTime event_begin_time;
        private DateTime event_end_time;
        private string event_location;
        private string event_variety; //task or event
        private int event_recuring_variety;
        private List<ContactModel> ContactList;
        private int userId;

        public int Event_id { get => event_id; set => event_id = value; }
        public string Event_title { get => event_title; set => event_title = value; }
        public string Event_description { get => event_description; set => event_description = value; }
        public DateTime Event_begin_time { get => event_begin_time; set => event_begin_time = value; }
        public DateTime Event_end_time { get => event_end_time; set => event_end_time = value; }
        public string Event_location { get => event_location; set => event_location = value; }
        public string Event_variety { get => event_variety; set => event_variety = value; }
        public int Event_recuring_variety { get => event_recuring_variety; set => event_recuring_variety = value; }
        public int UserId { get => userId; set => userId = value; }
        internal List<ContactModel> ContactList1 { get => ContactList; set => ContactList = value; }
    }
}
