using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.DBStats;

namespace pixAdmin
{
    public partial class X_ByPageAndGeo : System.Web.UI.Page
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
            string sQuery = "select  * from LandingPages_X_Mask";
            var result = db.Query<pixLandingPages_X_Mask>(sQuery);
            grdpagesX.DataSource = result;
            grdpagesX.DataBind();
            db.CloseSharedConnection();
        }



        protected void updateX(object sender, GridViewUpdateEventArgs e)
        {

            int cellNumber = 1;
            int  rowID;
            //string txtTier;
            GridViewRow row = (GridViewRow)grdpagesX.Rows[e.RowIndex];

            rowID = Int16.Parse(row.Cells[cellNumber].Text);
            TextBox txtProviderid = (TextBox)row.Cells[cellNumber + 1].Controls[0];
            TextBox txtPageId = (TextBox)row.Cells[cellNumber + 2].Controls[0];
            TextBox txtCountryCode = (TextBox)row.Cells[cellNumber + 3].Controls[0];
            TextBox txt_X = (TextBox)row.Cells[cellNumber + 4].Controls[0];


            pixLandingPages_X_Mask page_X = new pixLandingPages_X_Mask();
            page_X.id = rowID;
            page_X.providerid = -1;

            if (txtProviderid.Text != string.Empty)
            {
                page_X.providerid = int.Parse(txtProviderid.Text);
            }
            
            page_X.pageid= int.Parse(txtPageId.Text);
            page_X.countryCode = txtCountryCode.Text;
            page_X.sendResponseEvery_x = int.Parse(txt_X.Text);

            var db = new PetaPoco.Database("myConnectionString");
            var result = db.Update(page_X);
            db.CloseSharedConnection();
            grdpagesX.EditIndex = -1;
            BindPages();

        }
        protected void grdpagesX_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdpagesX.EditIndex = -1;
            BindPages();
        }
        protected void grdpagesX_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            grdpagesX.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BindPages();
        }
        protected void grdpagesX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdpagesX_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowID;

            GridViewRow row = (GridViewRow)grdpagesX.Rows[e.RowIndex];

            pixLandingPages_X_Mask pageX = new pixLandingPages_X_Mask();
            rowID = Int16.Parse(row.Cells[1].Text);

            var db = new PetaPoco.Database("myConnectionString");
            pageX.id = rowID;
            var result = db.Delete(pageX);
            db.CloseSharedConnection();
            grdpagesX.EditIndex = -1;
            BindPages();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            pixLandingPages_X_Mask pageX = new pixLandingPages_X_Mask();
            pageX.providerid = -1;
            if (txtProviderID.Text != string.Empty || txtProviderID.Text != "")
            {
                pageX.providerid = int.Parse(txtProviderID.Text);

            }
           
            
            pageX.pageid = int.Parse(txtPageID.Text);
            pageX.countryCode = txtCountryCode.Text;
            pageX.sendResponseEvery_x = int.Parse(txt_X.Text);

            var db = new PetaPoco.Database("myConnectionString");
            var result = db.Insert(pageX);
            db.CloseSharedConnection();
            BindPages();
        }
    }
}