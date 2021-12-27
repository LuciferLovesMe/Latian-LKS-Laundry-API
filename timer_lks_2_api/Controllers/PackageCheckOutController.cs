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
    public class PackageCheckOutController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        int id_header, price;

        [Route("api/post")]
        [HttpPost]
        public bool post([FromBody] CheckOut c)
        {
            if(c != null)
            {
                SqlCommand command = new SqlCommand("insert into header_transaction values(" + c.id_employee + ", " + c.id_customer + ", getdate(), getdate())", connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    SqlCommand com = new SqlCommand("select top(1) * from header_transaction order by id_header_transaction desc", connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = com.ExecuteReader();
                        reader.Read();
                        id_header = Convert.ToInt32(reader["id_header_transaction"]);
                        connection.Close();

                        SqlCommand comm = new SqlCommand("select * from package where id_package = " + c.id_package, connection);
                        try
                        {
                            connection.Open();
                            SqlDataReader reader1 = comm.ExecuteReader();
                            reader1.Read();
                            price = Convert.ToInt32(reader1["price_package"]);
                            connection.Close();

                            SqlCommand sql = new SqlCommand("insert into detail_transaction(id_header_transaction, id_package, price_detail_transaction, total_unit_detail_transaction) values(" + id_header + ", " + c.id_package + ", " + price + ", 1)", connection);
                            try
                            {
                                connection.Open();
                                sql.ExecuteNonQuery();
                                connection.Close();

                                return true;
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
