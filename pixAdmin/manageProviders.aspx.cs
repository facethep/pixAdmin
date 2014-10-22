using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.DBStats;
using System.Web.Configuration;
using System.Configuration;
namespace pixAdmin
{
    public partial class manageProviders : System.Web.UI.Page
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindProvidersData();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           
           
        }

       
        protected void Button3_Click(object sender, EventArgs e)
        {
           
            var myProvider = new pixProviders();
            myProvider.id = Convert.ToInt32(txtProviderID.Text);
            myProvider.name = txtProviderName.Text;
            myProvider.isActive = true;
            myProvider.method = "GET";
            myProvider.pcmac = txtpcmac.Text;
            myProvider.param1 = txtProviderParam1.Text;
            myProvider.param2 = txtProviderParam2.Text;
            myProvider.param3 = txtProviderParam3.Text;
            myProvider.pixel_url = txtProviderPixelURL.Text;
            myProvider.sendResponseEvery = Convert.ToInt16(txtProviderSendResponseEvery.Text);
            myProvider.pixel_url_Text2Replace = txtProviderURLtext2Replace.Text;


            var db = new PetaPoco.Database("myConnectionString");
            db.Insert(myProvider);
            db.CloseSharedConnection();
            BindProvidersData();
        }

        private void BindProvidersData()
        {
            var db = new PetaPoco.Database("myConnectionString");
           
            string sQuery = "select  * from Providers ";
            if (drpPCMAC.SelectedValue !="ALL"){
                sQuery += " where pcmac = '" + drpPCMAC.SelectedValue + "' ";
            }

            sQuery  +=  "order by name asc";
            

            var result = db.Query<pixProviders>(sQuery);
            GridView1.DataSource = result;
            GridView1.DataBind();
            db.CloseSharedConnection(); 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
       
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            GridView1.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BindProvidersData();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            lblError.Text =  System.Configuration.ConfigurationManager.AppSettings["SEND_RESPONSE"];
           /* Configuration configuration;
            * 
            CustomErrorsSection section;
            string str = "error.htm";
            log.Info("trying to refresh web.config");
            configuration = WebConfigurationManager.OpenWebConfiguration("~");
            section = (CustomErrorsSection)configuration.GetSection("system.web/customErrors");
            str = section.DefaultRedirect;
            if (str == "error.htm") { str = "error2.htm"; }
            else if (str == "error2.htm") {str = "error.htm";}

            section.DefaultRedirect = str;
            log.Error("Saving web.config");

            try
            {
                configuration.Save();
                log.Error("Web.config - saved");

            }
            catch (Exception ex)
            {
                log.Fatal("Error saving log file", ex);
            }
        */

        }



        protected void updateProvider(object sender, GridViewUpdateEventArgs e)
        {
            
            int cellNumber = 1;
            int providerid;

            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

            providerid = Int16.Parse(row.Cells[cellNumber].Text);
            TextBox txtName = (TextBox)row.Cells[cellNumber+1].Controls[0];
            TextBox txtPcMac = (TextBox)row.Cells[cellNumber + 2].Controls[0];

            TextBox txtPixelUrl = (TextBox)row.Cells[cellNumber+3].Controls[1];
            TextBox txtParam1 = (TextBox)row.Cells[cellNumber+4].Controls[0];
            TextBox txtParam2 = (TextBox)row.Cells[cellNumber+5].Controls[0];
            TextBox txtParam3 = (TextBox)row.Cells[cellNumber+6].Controls[0];
            TextBox txtResponseEvery = (TextBox)row.Cells[cellNumber+7].Controls[0];
            TextBox txtText2Replace = (TextBox)row.Cells[cellNumber+8].Controls[0];

            var db = new PetaPoco.Database("myConnectionString");
           pixProviders provider = new pixProviders();

            provider.id = providerid; 
            provider.name = txtName.Text;
            provider.pcmac = txtPcMac.Text;
            provider.pixel_url = txtPixelUrl.Text;
            provider.param1 = txtParam1.Text;
            provider.param2 = txtParam2.Text;
            provider.param3 = txtParam3.Text;
            provider.sendResponseEvery = short.Parse( txtResponseEvery.Text);
            provider.pixel_url_Text2Replace = txtText2Replace.Text;

            var result = db.Update(provider);
            db.CloseSharedConnection();
            GridView1.EditIndex = -1;
            BindProvidersData();

        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindProvidersData();
        }

   

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProvidersData();
        }

    }
}