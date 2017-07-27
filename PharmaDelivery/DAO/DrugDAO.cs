using PharmaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaDelivery.DAO
{
    public class DrugDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static Drug saveDrug(Drug newdrug)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SaveDrug", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@GroupId", newdrug.GroupId);
                        command.Parameters.AddWithValue("@Name", newdrug.Name);
                        command.Parameters.AddWithValue("@SubgroupId", newdrug.SubGroupId);
                        command.Parameters.AddWithValue("@PreparateId", newdrug.PreparateId);
                        command.Parameters.AddWithValue("@Price", newdrug.Price);

                        command.ExecuteNonQuery();
                        return newdrug;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return null;
                }
            }

        }
    }
}