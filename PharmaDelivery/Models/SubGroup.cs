using PharmaDelivery.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaDelivery.Models
{
    public class SubGroup
    {
        public int Id { get; set; }
        public string SubGroupName { get; set; }
        public int ParentId { get; set; }

        public SubGroup()
        {

        }

        public static List<SubGroup> GetSubGroupByParentId(int id)
        {
            return GroupDAO.getSubgroupByGroupId(id);
        }
    }
}