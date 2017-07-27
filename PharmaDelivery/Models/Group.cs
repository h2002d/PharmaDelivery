using PharmaDelivery.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaDelivery.Models
{
    public class Group
    {
        public int id { get; set; }
        public string Name { get; set; }

        public Group()
        {
           
        }
        public static List<Group> GetGroupById(int? id)
        {
            return GroupDAO.getGroups(id);
        }
    }
}