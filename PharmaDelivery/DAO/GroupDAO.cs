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
    public class GroupDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static List<Group> getGroups(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetGroup", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                        {
                            command.Parameters.AddWithValue("@GroupId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@GroupId", id);
                        }

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Group> groupList = new List<Group>();

                        while (rdr.Read())
                        {
                            Group group = new Group();
                            group.id = Convert.ToInt32(rdr["Id"]);
                            group.Name = rdr["GroupName"].ToString();
                            groupList.Add(group);
                        }
                        return groupList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }
        public static List<SubGroup> getSubgroupByGroupId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetSubGroupByGroupId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@GroupId", id);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<SubGroup> groupList = new List<SubGroup>();

                        while (rdr.Read())
                        {
                            SubGroup group = new SubGroup();
                            group.Id = Convert.ToInt32(rdr["Id"]);
                            group.SubGroupName = rdr["SubgroupName"].ToString();
                            group.ParentId = Convert.ToInt32(rdr["GroupId"]);
                            groupList.Add(group);
                        }
                        return groupList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }
        public static List<Preparate> getPreparateBySubId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetPreparateBySubGroupId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SubGroupId", id);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<Preparate> groupList = new List<Preparate>();

                        while (rdr.Read())
                        {
                            Preparate preparate = new Preparate();
                            preparate.id = Convert.ToInt32(rdr["Id"]);
                            preparate.PreparateName = rdr["PreparateName"].ToString();
                            preparate.SubGroupId = Convert.ToInt32(rdr["SubGroupId"]);
                            groupList.Add(preparate);
                        }
                        return groupList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }
    }
}