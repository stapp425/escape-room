using UnityEngine;

public class GameHandler : MonoBehaviour {
    NotificationHandler notificationHandler;
    ObjectiveHandler objectiveHandler;
    
    void Awake() {
        objectiveHandler = GetComponent<ObjectiveHandler>();
    }

    public void OnGameWin() {
        
    }

    public void OnGameLose() {

    }
}
