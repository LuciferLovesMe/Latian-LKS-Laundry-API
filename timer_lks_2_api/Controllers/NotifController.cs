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
    public class NotifController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        List<NotifModel> models = new List<NotifModel>();

        [Route("api/notif")]
        public List<NotifModel> get()
        {
            SqlCommand command = new SqlCommand("select * from header_transaction join detail_transaction on detail_transaction.id_header_transaction = header_transaction.id_header_transaction join package on detail_transaction.id_package = package.id_package ", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    models.Add(new NotifModel
                    {
                        id_employee = Convert.ToInt32(reader["id_employee"]),
                        name_package = Convert.ToString(reader["name_package"]),
                        complete_datetime = Convert.ToString(reader["complete_datetime_detail_transaction"])
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

        [Route("api/notif/{id_employee}")]
        public NotifModel get(int id_employee)
        {
            NotifModel model = new NotifModel();
            SqlCommand command = new SqlCommand("select * from header_transaction join detail_transaction on detail_transaction.id_header_transaction = header_transaction.id_header_transaction join package on detail_transaction.id_package = package.id_package where header_transaction.id_employee = " + id_employee + " and complete_datetime_detail_transaction is not null", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.id_employee = Convert.ToInt32(reader["id_employee"]);
                    model.name_package = reader["name_package"].ToString();
                    model.complete_datetime = reader["complete_datetime_detail_transaction"].ToString();
                }
                connection.Close();

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
