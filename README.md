# How to populate child nodes asynchronously in uwp treegrid?

## About the example

This example illustrates how to populate child nodes asynchronously in `UWP TreeGrid`.

You can populate the child nodes asynchronously using `async` and `await` at runtime when retrieving data from web services or any database. This can be performed by `PopulateChildNodes` method from `TreeGridRequestTreeItemsEventArgs.ParentNode` property.

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