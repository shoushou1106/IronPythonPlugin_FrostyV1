using Frosty.Core;
using IronPythonPlugin.Windows;

namespace IronPythonPlugin.Extensions
{
    public class DebugMenuExtension : MenuExtension
    {
        // The top level menu item to place this menu item into.
        public override string TopLevelMenuName => "Scripts";

        // The name of the menu item.
        public override string MenuItemName => "ipy debug 1";

        // The action to perform when the menu item is clicked
        public override RelayCommand MenuItemClicked => new RelayCommand((o) =>
        {
            Debug1Window debug1Window = new Debug1Window();
            debug1Window.Show();
        });
    }
}
