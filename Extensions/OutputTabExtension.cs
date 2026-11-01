using Frosty.Controls;
using Frosty.Core;
using IronPythonPlugin.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IronPythonPlugin.Extensions
{
    public class OutputTabExtension : TabExtension
    {
        public override string TabItemName => "IronPython Output";

        public override FrostyTabItem TabContent => new OutputTabItem();
    }
}
