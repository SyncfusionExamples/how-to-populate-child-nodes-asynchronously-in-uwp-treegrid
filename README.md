# How to Populate Child Nodes Asynchronously in UWP TreeGrid?

This example illustrates how to populate child nodes asynchronously in [UWP TreeGrid](https://www.syncfusion.com/uwp-ui-controls/treegrid) (SfTreeGrid).

You can populate the child nodes asynchronously using **async** and **await** at runtime when retrieving data from web services or any database. This can be performed by [PopulateChildNodes](https://help.syncfusion.com/cr/uwp/Syncfusion.UI.Xaml.TreeGrid.TreeNode.html#Syncfusion_UI_Xaml_TreeGrid_TreeNode_PopulateChildNodes_System_Collections_Generic_IEnumerable_System_Object__) method from [TreeGridRequestTreeItemsEventArgs.ParentNode](https://help.syncfusion.com/cr/uwp/Syncfusion.UI.Xaml.TreeGrid.TreeGridRequestTreeItemsEventArgs.html#Syncfusion_UI_Xaml_TreeGrid_TreeGridRequestTreeItemsEventArgs_ParentNode) property.

``` c#
private async void TreeGrid_RequestTreeItems(object sender, TreeGridRequestTreeItemsEventArgs args)
{
    if (args.ParentItem == null)
    {
        args.ChildItems =  viewModel.Employees.Where(x => x.ReportsTo == -1);
    }
    //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
    else
    {
        EmployeeInfo ems = args.ParentItem as EmployeeInfo;
              
        if (ems != null)
        {
            await Task.Run(async () =>
            {
                await this.treeGrid.Dispatcher.RunAsync(CoreDispatcherPriority.High, async() =>
                {
                    //Get the child items with time delay
                    var childItems = await viewModel.GetEmployees(ems.ID);

                    //Populate the child nodes based on the child items
                    args.ParentNode.PopulateChildNodes(childItems);
                });
                       
            });
        }
    }
}
```