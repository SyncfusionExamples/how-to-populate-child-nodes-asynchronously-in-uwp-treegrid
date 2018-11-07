using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OnDemandLoading
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ViewModel viewModel = new ViewModel();
        public MainPage()
        {
            this.InitializeComponent();
            treeGrid.Loaded += TreeGrid_Loaded;
            treeGrid.Unloaded += TreeGrid_Unloaded;
        }

        private void TreeGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            treeGrid.RequestTreeItems -= TreeGrid_RequestTreeItems;
            this.treeGrid.RepopulateTree();
        }

        private async void TreeGrid_Loaded(object sender, RoutedEventArgs e)
        {
            treeGrid.RequestTreeItems += TreeGrid_RequestTreeItems;
            this.treeGrid.RepopulateTree();
        }

        System.Threading.AutoResetEvent autoreset = new System.Threading.AutoResetEvent(false);
        private async void TreeGrid_RequestTreeItems(object sender, TreeGridRequestTreeItemsEventArgs args)
        {
            if (args.ParentItem == null)
            {
                args.ChildItems =  viewModel.Employees.Where(x => x.ReportsTo == -1);
            }
            //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
            else
            {
                //get the children of the parent object 
                EmployeeInfo emp = args.ParentItem as EmployeeInfo;
              
                if (emp != null)
                {
                    await Task.Run(async () =>
                    {
                        var childItems = await viewModel.GetEmployees(emp.ID);
                        await this.treeGrid.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                        {
                            args.ParentNode.PopulateChildNodes(childItems);
                        });
                    });
                 }
            }
        }
   }
}
