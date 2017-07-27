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
    public class PreparateDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static Preparate savePreparate(Preparate newPreparate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SavePreparate", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PreparateName", newPreparate.PreparateName);
                        command.Parameters.AddWithValue("@SubgroupId", newPreparate.SubGroupId);

                        command.ExecuteNonQuery();
                        return newPreparate;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    
                }
            }

        }
    }
}