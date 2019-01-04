using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerTransport
{
    public partial class ContainerTransportController : Form
    {
        private readonly IDock _dock;
        public ContainerTransportController(IDock dock)
        {
            _dock = dock;
            InitializeComponent();
        }

        private void ContainerTransportController_Load(object sender, EventArgs e)
        {
            WeightNumericUpDown.Controls[0].Visible = false; // Disable arrows on the numeric updown
            ContainerTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Disables input and makes it look neater
            ContainerTypeComboBox.SelectedIndex = 0;  // Selected type defaults to normal
        }

        private void BuildShipButton_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(ShipWidthNumericUpDown.Value);
            int length = Convert.ToInt32(ShipLengthNumericUpDown.Value);
            int shipWeight = Convert.ToInt32(ShipMaxWeightNumericUpDown.Value);

            _dock.BuildShip(shipWeight, width, length);
            ContainerPlacerBox.Visible = true;
            ShipBuilderBox.Visible = false;
            DisplayShipSlots();
        }

        private void DisplayShipSlots()
        {
            MessageBox.Show(_dock.Ship.ToString());
        }

        private void AddContainerButton_Click(object sender, EventArgs e)
        {
            ContainerType type = (ContainerType)ContainerTypeComboBox.SelectedIndex;
            double weight = Convert.ToInt16(WeightNumericUpDown.Value);

            _dock.AddNewUnorderedContainer(weight, type);
            UpdateUnorderedContainerListBox();

            AddResultLabel.Text = _dock.AddContainerResultString;
        }

        private void UpdateUnorderedContainerListBox()
        {
            UnorderedContainersListbox.Items.Clear();
            foreach (Logic.IContainer container in _dock.UnorderedContainers)
            {
                UnorderedContainersListbox.Items.Add(container.ToString());
            }
        }

        private void PlaceContainerButton_Click(object sender, EventArgs e)
        {
            IContainerShipLoader containerShipLoader = new ContainerShipLoader(_dock);

            containerShipLoader.InitiateLoading();
            if(containerShipLoader.LoadContainerResultString.Count != 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, containerShipLoader.LoadContainerResultString));
            }           
            List<string> allSlots = new List<string>();
            foreach(ISlot slot in _dock.Ship.Slots)
            {
               allSlots.Add(slot.ToString());
            }
            
            MessageBox.Show(string.Join(Environment.NewLine, allSlots));
            MessageBox.Show(containerShipLoader.ShipBalanceSafetyOutput());
        }
    }
}
