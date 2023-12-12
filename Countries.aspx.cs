using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WorldCupManagementSystem.Constants;
using WorldCupManagementSystem.Models;
using WorldCupManagementSystem.Operations.Abstract;
using WorldCupManagementSystem.Operations.Concrete;

namespace WorldCupManagementSystem
{
    public partial class Countries : System.Web.UI.Page
    {
        ICountryOperation _operation = new CountryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTable();
            }
        }

        private void BindTable()
        {
            var data = _operation.GetAll().Data.Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                Location = x.Region,
                Group = x.Group?.Name
            });
            rptData.DataSource = data;
            rptData.DataBind();
        }

        protected void rptData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EDIt":
                    Response.Redirect(Page.ResolveClientUrl("~/AddOrEditCountry.aspx?ID=" + int.Parse(e.CommandArgument.ToString())));
                    break;
                case "DELETE":
                    DeleteData(int.Parse(e.CommandArgument.ToString()));
                    break;
                default:
                    break;
            }
        }

        private void DeleteData(int id)
        {
            _operation.Delete(id);
            BindTable();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/AddOrEditCountry.aspx"));
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            List<Country> countries = new List<Country>
            {
                new Country { Name = "United States", Region = Regions.Europe },
                new Country { Name = "Canada", Region = Regions.Europe },
                new Country { Name = "United Kingdom", Region = Regions.Europe },
                new Country { Name = "Australia", Region = Regions.Australia },
                new Country { Name = "France", Region = Regions.Europe },
                new Country { Name = "Germany", Region = Regions.Europe },
                new Country { Name = "Japan", Region = Regions.Asia },
                new Country { Name = "China", Region = Regions.Asia },
                new Country { Name = "Brazil", Region = Regions.America },
                new Country { Name = "India", Region = Regions.Asia },
                new Country { Name = "Mexico", Region = Regions.America },
                new Country { Name = "Argentina", Region = Regions.America },
                new Country { Name = "South Korea", Region = Regions.Asia },
                new Country { Name = "Russia", Region = Regions.Europe },
                new Country { Name = "Italy", Region = Regions.Europe },
                new Country { Name = "Spain", Region = Regions.Europe },
                new Country { Name = "Netherlands", Region = Regions.Europe },
                new Country { Name = "South Africa", Region = Regions.Africa },
                new Country { Name = "Switzerland", Region = Regions.Europe },
                new Country { Name = "Sweden", Region = Regions.Europe },
                new Country { Name = "Norway", Region = Regions.Europe },
                new Country { Name = "Denmark", Region = Regions.Europe },
                new Country { Name = "Singapore", Region = Regions.Asia },
                new Country { Name = "New Zealand", Region = Regions.Australia },
                new Country { Name = "Greece", Region = Regions.Europe },
                new Country { Name = "Turkey", Region = Regions.Europe },
                new Country { Name = "Egypt", Region = Regions.Africa },
                new Country { Name = "Saudi Arabia", Region = Regions.Asia },
                new Country { Name = "Thailand", Region = Regions.Asia },
                new Country { Name = "Malaysia", Region = Regions.Asia },
                new Country { Name = "Vietnam", Region = Regions.Asia },
                new Country { Name = "Azerbaijan", Region = Regions.Asia }
            };

            foreach (var item in countries)
            {
                item.ID = _operation.GetNextId().Data;
                _operation.Add(item);
            }

            BindTable();
        }
    }
}