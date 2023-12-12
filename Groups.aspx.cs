using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldCupManagementSystem.Models;
using WorldCupManagementSystem.Operations.Abstract;
using WorldCupManagementSystem.Operations.Concrete;

namespace WorldCupManagementSystem
{
    public partial class Groups : System.Web.UI.Page
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        IGroupOperation groupOperation = new GroupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private void BindGroups()
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var data = groupOperation.GetAll().Data.Select(x => new
            {
                Name = x.Name,
                CountryList = JsonConvert.SerializeObject(x.Participants, settings)
            });
            rptGroups.DataSource = data;
            rptGroups.DataBind();

            for (int i = 0; i < rptGroups.Items.Count; i++)
            {
                var countryData =JsonConvert.DeserializeObject<List<Country>>((rptGroups.Items[i].FindControl("hfCountries") as HiddenField).Value);
                var eachRow = (rptGroups.Items[i].FindControl("rptCountry") as Repeater).DataSource = countryData.Select(x => new
                {
                    Name = x.Name
                });
                (rptGroups.Items[i].FindControl("rptCountry") as Repeater).DataBind();
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            GeneratorManager.Instance.GenerateGroups();
            BindGroups();
        }
    }
}