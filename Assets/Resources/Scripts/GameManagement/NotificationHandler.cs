using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationHandler : MonoBehaviour {
    [SerializeField] float notificationShowDuration;
    readonly Queue<Notification> activeNotifications = new();
    readonly List<Notification> recentlyShownNotifications = new();
    [SerializeField] TextMeshProUGUI notificationTextObject;
    public static NotificationHandler Current { get; private set; }
    
    void Awake() {
        if (Current != null && Current == this) {
            Destroy(Current);
            Current = null;
        } else {
            Current = this;
        }

        gameObject.SetActive(false);
    }

    IEnumerator ShowNotification(float duration) {
        while (activeNotifications.Count > 0) {
            Notification notif = activeNotifications.Dequeue();
            recentlyShownNotifications.Add(notif);
            
            // notificationTextObject.text = notif.message;
            Debug.Log(notif.message);

            yield return new WaitForSeconds(duration);
        }

        // after all notifications have been displayed, disable the game object
        gameObject.SetActive(false);
    }

    public void QueueNotification(Notification notification) {
        activeNotifications.Enqueue(notification);

        if (activeNotifications.Count == 1) {
            gameObject.SetActive(true);
            StartCoroutine(ShowNotification(notificationShowDuration));
        }
    }
}
