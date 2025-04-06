using UnityEngine;

// Created for storing interactables in the inventory
[System.Serializable]
public class Item {
    [SerializeField] public ItemData data { get; private set; }
    public int CurrentStackSize { get; private set; } = 0;
    
    public Item(ItemData data) {
        this.data = data;
        AddToStack();
    }

    public void AddToStack() => CurrentStackSize++;

    public void RemoveFromStack() => CurrentStackSize--;
    
    public virtual void OnUse(Player player) => RemoveFromStack();
}
