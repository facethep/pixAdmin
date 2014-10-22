using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 using pixAdmin.DBStats;


namespace pixAdmin
{
    public partial class pageRedirection : System.Web.UI.Page
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
            string sQuery = "select  * from LandingPagesMask";
            var result = db.Query<pixPageRedirection>(sQuery);
            grdPageRedirect.DataSource = result;
            grdPageRedirect.DataBind();
            db.CloseSharedConnection();
        }


        protected void grdPageRedirect_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPageRedirect.EditIndex = -1;
            BindPages();
        }
        protected void grdPageRedirect_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            grdPageRedirect.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BindPages();
        }
        protected void grdPageRedirect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdPageRedirect_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowID;

            GridViewRow row = (GridViewRow)grdPageRedirect.Rows[e.RowIndex];

            pixPageRedirection lPage = new pixPageRedirection();
            rowID = Int16.Parse(row.Cells[1].Text);

            var db = new PetaPoco.Database("myConnectionString");
            lPage.id = rowID;
            var result = db.Delete(lPage);
            db.CloseSharedConnection();
            grdPageRedirect.EditIndex = -1;
            BindPages();
        }




        protected void updateRedirect(object sender, GridViewUpdateEventArgs e)
        {

            int cellNumber = 1;
            int rowID;
            //string txtTier;
            GridViewRow row = (GridViewRow)grdPageRedirect.Rows[e.RowIndex];

            rowID = Int16.Parse(row.Cells[cellNumber].Text);
            TextBox txtProviderid = (TextBox)row.Cells[cellNumber + 1].Controls[0];
            TextBox txtOriginPageId = (TextBox)row.Cells[cellNumber + 2].Controls[0];
            TextBox txtRedirectpageId = (TextBox)row.Cells[cellNumber + 3].Controls[0];


            pixPageRedirection lPage = new pixPageRedirection();
            lPage.id = rowID;
            lPage.providerid = -1;

            if (txtProviderid.Text != string.Empty)
            {
                lPage.providerid = int.Parse(txtProviderid.Text);
            }

            lPage.pageid_origin = int.Parse(txtOriginPageId.Text);
            lPage.pageid_redirectTo = int.Parse(txtRedirectpageId.Text);
            

            var db = new PetaPoco.Database("myConnectionString");
            var result = db.Update(lPage);
            db.CloseSharedConnection();
            grdPageRedirect.EditIndex = -1;
            BindPages();

        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            pixPageRedirection pageRedirect = new pixPageRedirection();
            pageRedirect.providerid = -1;

            if (txtProviderID.Text != string.Empty || txtProviderID.Text != "")
            {
                pageRedirect.providerid = int.Parse(txtProviderID.Text);
            }


            pageRedirect.pageid_origin= int.Parse(txtpageOrigin.Text);
            pageRedirect.pageid_redirectTo = int.Parse(txtPageDestination.Text);

            var db = new PetaPoco.Database("myConnectionString");
            var result = db.Insert(pageRedirect);
            db.CloseSharedConnection();
            BindPages();
        }
    }
}