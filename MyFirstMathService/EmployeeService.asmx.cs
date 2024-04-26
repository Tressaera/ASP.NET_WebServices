using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyFirstMathService
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {
        SqlConnection objConn = new SqlConnection();

        [WebMethod]
        public DataTable GetEmployee(int empid)
        {
            if (objConn.State == ConnectionState.Closed)
            {
                objConn.ConnectionString = ConfigurationManager.AppSettings["DBConnectionString"].ToString(); objConn.Open();
            }
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConn;
            objCommand.CommandText = "Select * from Employee where EmpId=" + empid.ToString();
            DataSet dsEmp = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(dsEmp);
            return dsEmp.Tables[0];
        }
        [WebMethod]
        public DataTable GetAllEmployees()
        {
            if (objConn.State == ConnectionState.Closed)
            {
                objConn.ConnectionString = ConfigurationManager.AppSettings["DBConnectionString"].ToString(); objConn.Open();
            }
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConn;
            objCommand.CommandText = "Select * from Employee";
            DataSet dsEmp = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(dsEmp);
            return dsEmp.Tables[0];
        }
        [WebMethod]
        public string SaveEmployee(Employee emp)
        {
            if (objConn.State == ConnectionState.Closed)
            {
                objConn.ConnectionString = ConfigurationManager.AppSettings["DBConnectionString"].ToString(); objConn.Open();
            }
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConn;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "sp_SaveEmployee";
            objCommand.Parameters.AddWithValue("@EmpName", emp.EmpName);
            objCommand.Parameters.AddWithValue("@Salary", emp.Salary);
            objCommand.Parameters.AddWithValue("@Address", emp.Address);
            objCommand.ExecuteNonQuery();
            return "Kaydedildi";
        }
        }
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
    }
    }
