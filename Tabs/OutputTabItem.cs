using Frosty.Controls;
using Frosty.Core;
using Frosty.Core.Controls;
using FrostySdk.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IronPythonPlugin.Tabs
{
    //[TemplatePart(Name = PART_RefExplorerToTextBlock, Type = typeof(TextBlock))]
    public class OutputTabItem : FrostyTabItem
    {
        //private const string PART_RefExplorerToTextBlock = "PART_RefExplorerToTextBlock";

        //private FrostyAssetListView refExplorerToList;

        static OutputTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OutputTabItem), new FrameworkPropertyMetadata(typeof(OutputTabItem)));
        }

        public OutputTabItem()
        {
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //refExplorerToList = GetTemplateChild(PART_RefExplorerToListView) as FrostyAssetListView;
        }

        //private void ReferenceTabItem_Loaded(object sender, RoutedEventArgs e)
        //{
        //}
    }
}
