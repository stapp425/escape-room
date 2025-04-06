using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject {
    public string title;
    public string description;
    public Sprite image;
    public GameObject gameObject;
    public event Action OnPickUpEvent;

    public void OnPickUp() => OnPickUpEvent?.Invoke();
    
    public static string ToItemList(List<ItemData> items) => string.Join(", ", items.Select(i => i.title));
}
