using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.DBStats;

namespace pixAdmin
{
    public partial class managePages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindPages();
            }
        }

        private void BindPages()
        {
            var db = new PetaPoco.Database("myConnectionString");
            string sQuery = "select  * from landingpages";
            var result = db.Query<pixLandingPages>(sQuery);
            GridView1.DataSource = result;
            GridView1.DataBind();
            db.CloseSharedConnection();
        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindPages();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            GridView1.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BindPages();
        }



        protected void updatepage(object sender, GridViewUpdateEventArgs e)
        {

            int cellNumber = 1;
            int pageid;

            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

            pageid = Int16.Parse(row.Cells[cellNumber].Text);
            TextBox txtName = (TextBox)row.Cells[cellNumber + 1].Controls[0];
            TextBox txtAdv = (TextBox)row.Cells[cellNumber + 2].Controls[0];
            TextBox txtpcmac = (TextBox)row.Cells[cellNumber + 3].Controls[0];

            TextBox txtUrl = (TextBox)row.Cells[cellNumber + 4].Controls[1];
          

            var db = new PetaPoco.Database("myConnectionString");
            pixLandingPages page = new pixLandingPages();

            page.id = pageid;
            page.name = txtName.Text;
            page.advertizer = txtAdv.Text;
            page.pcmac = txtpcmac.Text;
            page.url = txtUrl.Text;
            page.isActive=true;
              
            var result = db.Update(page);
            db.CloseSharedConnection();
            GridView1.EditIndex = -1;
            BindPages();

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnAddPage_Click(object sender, EventArgs e)
        {
            var myPage = new pixLandingPages();
            myPage.id = Convert.ToInt32(txtID.Text);
            myPage.name = txtName.Text;
            myPage.advertizer = txtAdv.Text;
            myPage.pcmac = txtPCMAC.Text;
            myPage.isActive = true;
            myPage.url = txtURL.Text;
            var db = new PetaPoco.Database("myConnectionString");
            db.Insert(myPage);
            db.CloseSharedConnection();
            BindPages();
        }
    }
}