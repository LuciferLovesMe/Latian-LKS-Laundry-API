using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using timer_lks_2_api.Models;

namespace timer_lks_2_api.Controllers
{
    public class PackageController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        List<PackageModel> models = new List<PackageModel>();

        public List<PackageModel> getdata()
        {
            SqlCommand command = new SqlCommand("select * from package", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    models.Add(new PackageModel
                    {
                        id = Convert.ToInt32(reader["id_package"]),
                        name = reader["name_package"].ToString(),
                        desc = reader["description_package"].ToString(),
                        price = Convert.ToInt32(reader["price_package"])
                    });
                }
                connection.Close();

                return models.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
