using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week3Homework.model;
using Week3Homework.model.Items;

namespace Week3Homework
{
    public partial class Details : Form
    {
        /// <summary>
        /// Logic part should not be integrated with
        /// UI part, I know. 
        /// I am just tired. 
        /// And I know, todo syntax is not like that
        /// but my regex is depends on that for highlights 
        /// so for me todos like that.
        /// </summary>
        //!TODO: Add Logic part
        private Order currentOrder;
        
        private static List<Order> dailyCompletedOrders = new List<Order>();
        
        private const float TaxRate = 0.10f; 

        public Details()
        {
            InitializeComponent();

            currentOrder = new Order();
            tip_tip.SetToolTip(enterTip, "Please enter desired amount of tip here.");

            SetupListViews();
            ShowEditView();
        }

        private void SetupListViews()
        {
            orderView.View = View.Details;
            orderView.FullRowSelect = true;
            orderView.Columns.Add("Item Name", 110);
            orderView.Columns.Add("Price", 60);

            orderView2.View = View.Details;
            orderView2.FullRowSelect = true;
            orderView2.Columns.Add("Item Name", 120);
            orderView2.Columns.Add("Price", 65);
        }

        private void RefreshOrderDisplay()
        {
            orderView.Items.Clear();
            orderView2.Items.Clear();

            float subtotalValue = 0f;

            foreach (var item in currentOrder.Items)
            {
                var listViewItem = new ListViewItem(item.GetName());
                // :D 
                listViewItem.SubItems.Add(item.GetPrice().ToString("0.00"));

                orderView.Items.Add((ListViewItem)listViewItem.Clone());
                orderView2.Items.Add((ListViewItem)listViewItem.Clone());

                subtotalValue += item.GetPrice();
            }

            float taxValue = subtotalValue * TaxRate;
            float tipValue = 0f;
            float.TryParse(enterTip.Text, out tipValue);
            float totalValue = subtotalValue + taxValue + tipValue;

            subtotal.Text = subtotalValue.ToString("0.00");
            tax.Text = taxValue.ToString("0.00");
            total.Text = totalValue.ToString("0.00");
            orderNumber.Text = currentOrder.Uuid.ToString().Substring(0, 8).ToUpper();
        }

        private void ShowEditView()
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void ShowCompleteView()
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            RefreshOrderDisplay();
        }

        private void AddItemToOrder(Item item)
        {
            currentOrder.Items.Add(item);
            RefreshOrderDisplay();
        }

        /// <summary>
        /// I am not happy with it. I think its againts DRY principles.
        /// OMG it writes params itself, I like it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void americanoS_Click(object sender, EventArgs e) => AddItemToOrder(new Americano(DrinkSize.Small));
        private void americanoM_Click(object sender, EventArgs e) => AddItemToOrder(new Americano(DrinkSize.Medium));
        private void americanoL_Click(object sender, EventArgs e) => AddItemToOrder(new Americano(DrinkSize.Large));

        private void latteS_Click(object sender, EventArgs e) => AddItemToOrder(new Latte(DrinkSize.Small));
        private void latteM_Click(object sender, EventArgs e) => AddItemToOrder(new Latte(DrinkSize.Medium));
        private void latteL_Click(object sender, EventArgs e) => AddItemToOrder(new Latte(DrinkSize.Large));

        private void teaS_Click(object sender, EventArgs e) => AddItemToOrder(new Tea(DrinkSize.Small));
        private void teaM_Click(object sender, EventArgs e) => AddItemToOrder(new Tea(DrinkSize.Medium));
        private void teaL_Click(object sender, EventArgs e) => AddItemToOrder(new Tea(DrinkSize.Large));

        private void removeItem_Click(object sender, EventArgs e)
        {
            if (orderView.SelectedIndices.Count > 0)
            {
                int index = orderView.SelectedIndices[0];
                currentOrder.Items.RemoveAt(index);
                RefreshOrderDisplay();
            }
            else
            {
                MessageBox.Show("Please select an item from the list to remove.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editOrder_Click(object sender, EventArgs e) => ShowEditView();

        private void continueOrder_Click(object sender, EventArgs e)
        {
            if (currentOrder.Items.Count == 0)
            {
                MessageBox.Show("The order is currently empty.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowCompleteView();
        }

        private void takePayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tableNumber.Text) || string.IsNullOrWhiteSpace(employee.Text))
            {
                MessageBox.Show("Please fill in both the Table Number and Employee name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float.TryParse(enterTip.Text, out float tipVal);
            float.TryParse(total.Text, out float totalVal);

            currentOrder.CompleteOrder(tableNumber.Text, employee.Text, tipVal, totalVal);
            
            dailyCompletedOrders.Add(currentOrder);

            MessageBox.Show($"Payment processed successfully!\nTotal Paid: {total.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            /// <summary>
            /// Reset for a fresh order
            /// </summary>
            currentOrder = new Order();
            tableNumber.Clear();
            employee.Clear();
            enterTip.Clear();
            RefreshOrderDisplay();
            ShowEditView();
        }

        private void newDesk_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear the entire order?", "Clear Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                currentOrder = new Order();
                tableNumber.Clear();
                employee.Clear();
                enterTip.Clear();
                RefreshOrderDisplay();
            }
        }

        /// <summary>
        /// There is a bug
        /// If u took sooo much orders, it became kinda 
        /// too long to read :
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //!TODO: fix reported bug.
        private void endOfDay_Click(object sender, EventArgs e)
        {
            if (dailyCompletedOrders.Count == 0)
            {
                MessageBox.Show("No completed orders for today.", "End of Day Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder report = new StringBuilder();
            report.AppendLine("======= END OF DAY ======");
            report.AppendLine($"Total Orders: {dailyCompletedOrders.Count}\n");

            float grandTotalRevenue = 0f;
            float grandTotalTips = 0f;

            foreach (var ord in dailyCompletedOrders)
            {
                string shortId = ord.Uuid.ToString().Substring(0, 6).ToUpper();
                report.AppendLine($"Order ID: {shortId} | Table: {ord.TableNumber} | Employee: {ord.Employee}");
                report.AppendLine($"Time: {ord.CompletedAt?.ToLocalTime():g}");
                report.AppendLine("Items:");
                
                foreach (var item in ord.Items)
                {
                    report.AppendLine($"   - {item.GetName()} ({item.GetPrice():0.00})");
                }

                report.AppendLine($"Tip: {ord.Tip:0.00} | Total: {ord.TotalAmount:0.00}");
                report.AppendLine("----------------------------------------");

                grandTotalRevenue += ord.TotalAmount;
                grandTotalTips += ord.Tip;
            }

            report.AppendLine($"\nTOTAL REVENUE: {grandTotalRevenue:0.00}");
            report.AppendLine($"TOTAL No TAX(TIP): {grandTotalTips:0.00}");

            MessageBox.Show(report.ToString(), "Daily Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tip_Changed(object sender, EventArgs e) => RefreshOrderDisplay();
    }
}
