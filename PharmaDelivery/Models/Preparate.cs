using PharmaDelivery.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaDelivery.Models
{
    public class Preparate
    {
        public int id { get; set; }
        public int SubGroupId { get; set; }
        public string PreparateName { get; set; }
        public static List<Preparate> GetPreparatesById(int id)
        {
           return GroupDAO.getPreparateBySubId(id);
        }
        public Preparate Save()
        {
            return PreparateDAO.savePreparate(this);
        }
    }
}