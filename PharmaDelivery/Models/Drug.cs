using PharmaDelivery.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaDelivery.Models
{
    public class Drug
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int PreparateId { get; set; }
        public double Price { get; set; }
        public Drug SaveDrug()
        {
            return DrugDAO.saveDrug(this);
        }
    }
}