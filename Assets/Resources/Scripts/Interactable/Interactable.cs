using System;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public string interactableName;
    public string interactText;
    public KeyCode interactKey = KeyCode.E;
    public ItemData itemData;
    public event Action OnInteractEvent;
    protected bool isInteractable = true;
    public bool isTouchToInteract = false;
    public bool shouldDestroyOnInteract = false;

    public void OnHover() {
        if (InteractionTextManager.Current.IsActive() || !isInteractable)
            return;

        InteractionTextManager.Current.SetTextVisibility(true);
        InteractionTextManager.Current.SetInteractKey(interactKey.ToString());
        InteractionTextManager.Current.SetTextContent(interactText);
    }
    
    public virtual void Interact(Player player) {
        if (!isInteractable)
            return;

        isInteractable = false;
        InteractionTextManager.Current.SetTextVisibility(false);

        player.inventory.AddItem(itemData);
        
        itemData.OnPickUp();
        OnInteract();
    }

    public virtual void OnInteract() {
        OnInteractEvent?.Invoke();
        
        if (shouldDestroyOnInteract)
            Destroy(gameObject);
    }
}
