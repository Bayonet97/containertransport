using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace ContainerTransport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<IContainer> exampleContainers = new List<IContainer>();
            exampleContainers.AddRange(new List<IContainer>
            {
                 new Container(30000, ContainerType.Normal),
                 new Container(12000, ContainerType.ValuableAndCooled)
            });

            IDock dock = new Dock(exampleContainers);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ContainerTransportController(dock));

        }
    }
}
