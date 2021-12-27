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
    public class CustomerController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        List<CustomerModel> models = new List<CustomerModel>();
        public List<CustomerModel> getEmp()
        {
            SqlCommand command = new SqlCommand("select * from customer", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                models.Add(new CustomerModel
                {
                    id = Convert.ToInt32(reader["id_customer"]),
                    name = Convert.ToString(reader["name_customer"]),
                    phone = reader["phone_number_customer"].ToString(),
                    address = reader["address_customer"].ToString()
                });
            }
            connection.Close();

            return models.ToList();
        }
    }
}
