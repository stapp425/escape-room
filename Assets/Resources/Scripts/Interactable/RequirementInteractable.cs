using System;
using System.Collections.Generic;

public class RequirementInteractable : Interactable, INotifier {
    public List<ItemData> requiredItems;
    public bool shouldRemoveGivenItemsOnPickup;
    public event Action OnInteractFailureEvent;

    public override void Interact(Player player) {
        List<ItemData> missingItems = GetMissingItems(player.inventory.ItemDatas);

        if (missingItems.Count > 0) {
            InteractFailure(player);
            return;
        }

        base.Interact(player);
    }

    public virtual void InteractFailure(Player player) {
        List<ItemData> itemDataList = GetMissingItems(player.inventory.ItemDatas);
        
        Notify(new Notification() {
            title = "Requirements Not Met",
            message = $"You are missing the following items: \n[{ItemData.ToItemList(itemDataList)}]"
        });

        OnInteractFailure();
    }

    protected virtual void OnInteractFailure() {
        OnInteractFailureEvent?.Invoke();
    }

    protected List<ItemData> GetMissingItems(List<ItemData> givenItems) {
        List<ItemData> missingItems = new();

        foreach (ItemData requiredItem in requiredItems) {
            if (!givenItems.Contains(requiredItem))
                missingItems.Add(requiredItem);
        }

        return missingItems;
    }

    public void Notify(Notification notification) => NotificationHandler.Current.QueueNotification(notification);
}
