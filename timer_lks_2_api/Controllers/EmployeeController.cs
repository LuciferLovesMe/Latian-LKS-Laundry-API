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
    public class EmployeeController : ApiController
    {
        LaundryEntities ent = new LaundryEntities();
        SqlConnection conn = new SqlConnection(Utils.conn);

        [HttpPost]
        public IHttpActionResult post(employee e)
        {
            if(e != null)
            {
                string sql = "Select * from employee where email_employee = '" + e.email_employee + "' and password_employee = '" + e.password_employee + "'";
                var user = ent.employees.SqlQuery(sql).FirstOrDefault();
                if (user != null)
                {
                    EmployeeModel emp = new EmployeeModel();
                    emp.id = Convert.ToInt32(user.id_employee);
                    emp.name = user.name_employee.ToString();
                    emp.email = user.email_employee.ToString();

                    return Ok(emp);
                }

                return Ok(user);
            }
            else
            {
                return null;
            }
        }
    }
}
