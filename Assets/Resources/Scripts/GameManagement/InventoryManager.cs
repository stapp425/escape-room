using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Scriptable Objects/Inventory")]
public class InventoryManager : ScriptableObject {
    // A non-duplicated, easy access for getting items
    readonly Dictionary<ItemData, Item> itemsToData = new();

    public List<Item> Items => itemsToData.Values.ToList();
    public List<ItemData> ItemDatas => itemsToData.Keys.ToList();

    public void AddItem(ItemData itemData) {
        if (itemsToData.TryGetValue(itemData, out Item foundItem)) {
            foundItem.AddToStack();
        } else {
            itemsToData.Add(itemData, new Item(itemData));
        }
    }

    public void RemoveItem(ItemData itemData) {
        if (itemsToData.TryGetValue(itemData, out Item foundItem)) {
            foundItem.RemoveFromStack();

            if (foundItem.CurrentStackSize == 0) {
                itemsToData.Remove(itemData);
            }
        }
    }
}
