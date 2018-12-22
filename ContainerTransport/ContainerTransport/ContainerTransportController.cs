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

        }

        private void BuildShipButton_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt16(ShipWidthNumericUpDown.Value);
            int length = Convert.ToInt16(ShipLengthNumericUpDown.Value);

            _dock.BuildShip(width, length);
            DisplayShipSlots();
        }

        private void DisplayShipSlots()
        {
            MessageBox.Show(string.Join(Environment.NewLine, _dock.Ship.GetAllSlots()));
        }
    }
}
