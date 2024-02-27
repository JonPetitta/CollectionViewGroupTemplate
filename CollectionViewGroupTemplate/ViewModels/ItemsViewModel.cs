using CollectionViewGroupTemplate.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CollectionViewGroupTemplate.ViewModels;

public class ItemsViewModel : ObservableObject
{
    public ObservableCollection<ItemGroup> ItemGroups { get; } = new();

    public ObservableCollection<Item> Items { get; } = new();

    public ItemsViewModel()
    {
        var itemMock = new ItemMock();

        foreach (var item in itemMock.Items)
        {
            Items.Add(item);
        }

        foreach (var item in itemMock.ItemGroups)
        {
            ItemGroups.Add(item);
        }
    }
}
