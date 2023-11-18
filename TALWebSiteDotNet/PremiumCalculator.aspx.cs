using System;
using System.Web.UI;
using TALWebSiteDotNet.Models;
using TALWebSiteDotNet.Services;

namespace TALWebSiteDotNet
{
    public partial class PremiumCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Service.InitializeHttpClient();
                DataBindOccupations();
                txtAge.Attributes.Add("readonly", "readonly");
                txtMonthlyPremium.Attributes.Add("readonly", "readonly");
            }
        }

        private void DataBindOccupations()
        {
            var occupations = Service.GetOccupations();
            if (occupations != null)
            {
                ddlOccupation.DataSource = occupations;
                ddlOccupation.DataBind();
            }
        }

        protected void ddlOccupation_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayMonthlyPremium();
        }

        protected void ddlOccupation_DataBound(object sender, EventArgs e)
        {
            ddlOccupation.Items.Insert(0, "--SELECT--");
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateAndDisplayMonthlyPremium();
        }

        private void CalculateAndDisplayMonthlyPremium()
        {
            if (ddlOccupation.SelectedIndex > 0 && !string.IsNullOrEmpty(txtAge.Text))
            {
                var factor = Service.GetFactor(Convert.ToInt16(ddlOccupation.SelectedValue));
                if (factor != null)
                {
                    var inputs = new PremiumCalculatorInputs()
                    {
                        Age = Convert.ToInt16(txtAge.Text),
                        OccupationRatingFactor = factor,
                        SI = Convert.ToDecimal(txtSI.Text)
                    };
                    txtMonthlyPremium.Text = Calculator.CalculatePremium(inputs).ToString();
                }
            }
            else txtMonthlyPremium.Text = "";
        }
    }
}