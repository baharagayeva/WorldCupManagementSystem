using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldCupManagementSystem.Constants;
using WorldCupManagementSystem.Models;
using WorldCupManagementSystem.Operations.Abstract;
using WorldCupManagementSystem.Operations.Concrete;

namespace WorldCupManagementSystem
{
    public partial class AddOrEditCountry : System.Web.UI.Page
    {
        ICountryOperation _operation = new CountryManager();
        private Mode PageMode
        {
            get
            {
                return (Mode)ViewState["PageMode"];
            }
            set
            {
                ViewState["PageMode"]=value;
            }
        }

        private int RowId
        {
            get
            {
                return (int)ViewState["ID"];
            }
            set
            {
                ViewState["ID"]=value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLocations();
                if (Request.QueryString["ID"] != null)
                {
                    PageMode = Mode.Edit;
                    RowId = int.Parse(Request.QueryString["ID"]);
                    BindData();
                }
                else
                {
                    txtId.Text = _operation.GetNextId().Data.ToString();
                    PageMode = Mode.Insert;
                }
            }
        }

        private void BindData()
        {
            var data = _operation.Get(RowId).Data;
            txtId.Text = data.ID.ToString();
            txtName.Text = data.Name.ToString();

            for (int i = 0; i < ddlLocation.Items.Count; i++)
            {
                if (ddlLocation.Items[i].Value == data.Region.ToString())
                {
                    ddlLocation.Items[i].Selected = true;
                    break;
                }
            }
        }

        private void BindLocations()
        {
            var locations = Enum.GetValues(typeof(Regions)).Cast<Regions>().ToList();
            foreach (var item in locations)
            {
                ddlLocation.Items.Add(new ListItem
                {
                    Text = item.ToString(),
                    Value = item.ToString()
                });
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(PageMode == Mode.Edit)
            {
                UpdateData();
            }
            else
            {
                InsertData();
            }
            RedirectToMainPage();
        }

        private void InsertData()
        {
            Regions region = default;
            if(!Enum.TryParse<Regions>(ddlLocation.SelectedValue, out region))
            {

            }

            Country country = new Country();
            country.ID = _operation.GetNextId().Data;
            country.Name = txtName.Text;
            country.Region = region;
            _operation.Add(country);
        }

        private void UpdateData()
        {
            Regions region = default;
            if (!Enum.TryParse<Regions>(ddlLocation.SelectedValue, out region))
            {

            }

            var updatedModel = _operation.Get(RowId).Data;
            updatedModel.Name = txtName.Text;
            updatedModel.Region = region;

            _operation.Update(updatedModel);
        }

        private void RedirectToMainPage()
        {
            Response.Redirect(Page.ResolveClientUrl("~/Countries.aspx"));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RedirectToMainPage();
        }
    }
}