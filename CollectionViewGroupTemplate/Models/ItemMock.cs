namespace CollectionViewGroupTemplate.Models;

public class ItemMock
{
    public List<Item> Items { get; set; } = new List<Item>();
    public List<ItemGroup> ItemGroups { get; set; } = new List<ItemGroup>();

    public ItemMock()
    {
        Init();
    }

    private void Init()
    {
        var dueDate = DateTime.Now.Date;
        for (int i = 0; i < 200; i++)
        {
            if (i % 5 == 0 && i != 0)
            {
                dueDate = dueDate + TimeSpan.FromDays(1);
            }
            Item item
                = new Item
            {
                Name = "Foo" + $" {i}",
                CreateDate = DateTime.Now.Date - TimeSpan.FromDays(i),
                DueDate = dueDate
            };
            Items.Add(item);
        }

        ProcessGroupItems();
    }

    private void ProcessGroupItems()
    {
        var itemList = Items;
        var now = DateTime.Now.Date;
        var tomorrow = now + TimeSpan.FromDays(1);
        var tomPlusSeven = now + TimeSpan.FromDays(7);
        var todaysItems = itemList.FindAll(x =>
            x.DueDate.Date == now.Date);
        var frem = itemList.RemoveAll(x =>
            x.DueDate.Date == now.Date);
        var nextWeeksItems = itemList.FindAll(x =>
            x.DueDate.Date >= tomorrow.Date &&
            x.DueDate.Date <= tomPlusSeven.Date);
        var srem = itemList.RemoveAll(x =>
            x.DueDate.Date >= tomorrow.Date &&
            x.DueDate.Date <= tomPlusSeven.Date);
        var remainingItems = itemList;
        ItemGroups = new List<ItemGroup>
        {
            new ItemGroup("Today", todaysItems.ToList()),
            new ItemGroup("Next Week", nextWeeksItems.ToList()),
            new ItemGroup("The Rest", remainingItems.ToList())
        };
    }
}
