using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.DBStats;


namespace pixAdmin
{
    public partial class lpRename : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            var db = new PetaPoco.Database("myConnectionString");

            string strSQL = " update [pixelDB].[dbo].landingpages ";
            strSQL +=  "set URL = replace(URL, '" + txtFromText.Text + "','" +txtToText.Text+ " ')";
            try
            {
                db.Execute(strSQL);
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Update Sucesfully - Please Delete Cache!";
            }
            catch (Exception ex){
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Erros, please check logs, " + ex.Message;
            }
            

 
        }

        
    }
}