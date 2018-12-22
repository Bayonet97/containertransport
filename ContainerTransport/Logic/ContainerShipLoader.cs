using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class ContainerShipLoader
    {

        public bool ContainerTooHeavy(IContainer container)
        {
            return container.ContainerWeight > 30000;
        }
    }
}
