using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MyWebClient
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceSoapClient obj = new EmployeeService.EmployeeServiceSoapClient();
            DataTable dtEmp = obj.GetAllEmployees();
            gvEmployee.DataSource = dtEmp;
            gvEmployee.DataBind();
        }
    }
}