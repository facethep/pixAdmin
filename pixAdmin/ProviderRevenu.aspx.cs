using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pixAdmin.DBStats;

namespace pixAdmin
{
    public partial class ProviderRevenu : System.Web.UI.Page
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
           int drpIndex=0;
            
            var db = new PetaPoco.Database("myConnectionString");
            string sQuery = "select  Tiers.*, name + ' - ' + pcmac as providerName  from Tiers, providers    where Tiers.providerID = providers.id order by name";
            var result = db.Query<pixTiers_presentation>(sQuery);
            grdProviderRevenu.DataSource = result;
            grdProviderRevenu.DataBind();
            db.CloseSharedConnection();

            //if (drpProviders.SelectedIndex != null)
            drpIndex = drpProviders.SelectedIndex;

             sQuery = "SELECT id, name + ' - ' + pcmac + ' - ' + cast( id as varchar) as name  FROM providers order by name asc";
             var result1 = db.Fetch<pixProviders>(sQuery);
            drpProviders.DataSource = result1;
            drpProviders.DataBind();

            drpProviders.SelectedIndex = drpIndex;
            db.CloseSharedConnection();



        }

        protected void updateRevenu(object sender, GridViewUpdateEventArgs e)
        {

            int cellNumber = 1;
            int providerid, rowID;
            //string txtTier;
            GridViewRow row = (GridViewRow)grdProviderRevenu.Rows[e.RowIndex];

            rowID = Int16.Parse(row.Cells[cellNumber].Text);
            providerid = Int16.Parse(row.Cells[cellNumber+1].Text);
            TextBox txtTier = (TextBox)row.Cells[cellNumber + 3].Controls[0];
            TextBox txtCountryCode= (TextBox)row.Cells[cellNumber + 4].Controls[0];
            TextBox txtRevenu = (TextBox)row.Cells[cellNumber + 5].Controls[0];
            TextBox txtCost = (TextBox)row.Cells[cellNumber + 6].Controls[0];

         
           
            pixTiers Tier= new pixTiers();
            Tier.id = rowID;
            Tier.providerID = providerid;
            Tier.TierName= txtTier.Text;
            Tier.countryCode =  txtCountryCode.Text;
            Tier.revenu= decimal.Parse(txtRevenu.Text);
            Tier.cost = decimal.Parse(txtCost.Text);

            var db = new PetaPoco.Database("myConnectionString");
            var result = db.Update(Tier);
            db.CloseSharedConnection();
            grdProviderRevenu.EditIndex = -1;
            BindPages();

        }
        protected void grdProviderRevenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProviderRevenu.EditIndex = -1;
            BindPages();
        }
        protected void grdProviderRevenu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            grdProviderRevenu.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BindPages();
        }
        protected void grdProviderRevenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdProviderRevenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowID;

            GridViewRow row = (GridViewRow)grdProviderRevenu.Rows[e.RowIndex];

            pixTiers Tier = new pixTiers();
            rowID = Int16.Parse(row.Cells[1].Text);
          
            var db = new PetaPoco.Database("myConnectionString");
            Tier.id = rowID;
            var result = db.Delete(Tier);
            db.CloseSharedConnection();
            grdProviderRevenu.EditIndex = -1;
            BindPages();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {

            pixTiers Tier = new pixTiers();
            Tier.providerID = Int16.Parse(drpProviders.SelectedValue);
            Tier.countryCode = txtCountryCode.Text;
            Tier.TierName = drpTiers.SelectedValue;
            Tier.revenu = decimal.Parse(txtRevenu.Text);
            Tier.cost = decimal.Parse(txtCost.Text);

            var db = new PetaPoco.Database("myConnectionString");
            var result = db.Insert(Tier);
            db.CloseSharedConnection();
            BindPages();



        }
    }
}