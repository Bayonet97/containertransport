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
            // ------------------------------------------------------------ //
            // FOR TESTING. DELETE LATER.
            List<IContainer> exampleContainers = CreateTestContainers();
            // ------------------------------------------------------------ //
            IDock dock = new Dock();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ContainerTransportController(dock));

        }

        // ------------------------------------------------------------ //
        // FOR TESTING. DELETE LATER.
        private static List<IContainer> CreateTestContainers()
        {
            List<IContainer> containers = new List<IContainer>();
            containers.AddRange(new List<IContainer>
            {
                // CREATE TEST CONTAINERS HERE
                 new Container(),
                 new Container()
            });

            return containers;
        }
        // ------------------------------------------------------------ //
    }
}
