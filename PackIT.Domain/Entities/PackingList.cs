using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Domain;

namespace PackIT.Domain.Entities;

/// <summary>
/// Represents packing list entity
/// </summary>
public class PackingList : AggregateRoot<PackingListId>
{
    /// <summary>
    /// Gets or init id
    /// </summary>
    public new PackingListId Id { get; init; }
    /// <summary>
    /// Represents packing list name
    /// </summary>
    private readonly PackingListName _name;
    /// <summary>
    /// Represents packing list localization
    /// </summary>
    private readonly Localization _localization;
    /// <summary>
    /// Represents packing items list
    /// </summary>
    private readonly LinkedList<PackingItem> _packingItems = new();

    /// <summary>
    /// Initialize new instance of packing list objet
    /// </summary>
    /// <param name="id">The unique identifier of packing list</param>
    /// <param name="name">The name of packing list</param>
    /// <param name="localization">The localization of packing list</param>
    internal PackingList(PackingListId id, PackingListName name, Localization localization)
    {
        Id = id;
        _name = name;
        _localization = localization;
    }

    private PackingList()
    { }

    /// <summary>
    /// Add new packing item into packing list
    /// </summary>
    /// <param name="packingItem">Packing item details</param>
    /// <exception cref="PackingItemAlreadyExistsException">Packing item already exists exception class</exception>
    public void AddPackingItem(PackingItem packingItem)
    {
        // Check for existing item
        var existingItem = _packingItems.Any(x => x.Name == packingItem.Name);

        if (existingItem)
        {
            throw new PackingItemAlreadyExistsException(_name, packingItem.Name);
        }

        _packingItems.AddLast(packingItem);
        AddEvent(new PackingItemAdded(this, packingItem));
    }

    /// <summary>
    /// Add list of packing item
    /// </summary>
    /// <param name="packingItems">Packing item list</param>
    public void AddPackingItems(IEnumerable<PackingItem> packingItems)
    {
        foreach (var item in packingItems)
        {
            AddPackingItem(item);
        }
    }

    /// <summary>
    /// Marked item as packed
    /// </summary>
    /// <param name="itemName">Item name</param>
    public void PackItem(string itemName)
    {
        var item = GetPackingItem(itemName);
        var packedItem = item with { IsPacked = true };

        _packingItems.Find(item)!.Value = packedItem;
        AddEvent(new PackingItemPacked(this, item));
    }

    /// <summary>
    /// Removed item from packing list
    /// </summary>
    /// <param name="itemName">Item name</param>
    public void RemovePackingItem(string itemName)
    {
        var item = GetPackingItem(itemName);
        _packingItems.Remove(item);

        AddEvent(new PackingItemRemoved(this, item));
    }

    /// <summary>
    /// Get packing item by name
    /// </summary>
    /// <param name="itemName">Item name</param>
    /// <returns>Returns packing item</returns>
    /// <exception cref="PackingItemNotFoundException">Packing item not found exception</exception>
    private PackingItem GetPackingItem(string itemName)
    {
        var existingItem = _packingItems.SingleOrDefault(x => x.Name == itemName);

        if (existingItem is null)
        {
            throw new PackingItemNotFoundException(itemName);
        }

        return existingItem;
    }
}
