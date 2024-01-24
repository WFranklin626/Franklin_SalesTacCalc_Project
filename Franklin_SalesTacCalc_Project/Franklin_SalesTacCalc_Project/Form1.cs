using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franklin_SalesTacCalc_Project
{
    public partial class frmDealer : Form
    {
        public frmDealer()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            // Get base cost from textbox
            if (decimal.TryParse(txtBase.Text, out decimal baseCost))
            {
                // Get selected warranty
                decimal warrantyCost = 0;
                switch (cmbWarranty.SelectedIndex)
                {
                    case 1:
                        warrantyCost = 1000;
                        break;
                    case 2:
                        warrantyCost = 2000;
                        break;
                    case 3:
                        warrantyCost = 3000;
                        break;
                }

                // Get selected state
                decimal salesTaxRate = 0;
                switch (cmbState.SelectedItem.ToString())
                {
                    case "WA":
                        salesTaxRate = 0.086m;
                        break;
                    case "OR":
                        salesTaxRate = 0;
                        break;
                }

                // Calculate total cost including sales tax and warranty cost
                decimal totalCost = baseCost + warrantyCost + (baseCost * salesTaxRate);

                // Display total cost in label
                lblTotal.Text = $"Total Vehicle cost is {totalCost:C}";

                // Clear error label
                lblError.Text = string.Empty;
            }
            else
            {
                // Show error message in lblError
                lblError.Text = "Please enter a valid base cost.";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all controls and set focus to base cost textbox
            txtBase.Clear();
            cmbWarranty.SelectedIndex = 0;
            cmbState.SelectedIndex = 0;
            lblTotal.Text = string.Empty;
            lblError.Text = string.Empty;  // Clear error label

            // Remove focus from cmbState
            this.ActiveControl = txtBase;
        }
    }
}
