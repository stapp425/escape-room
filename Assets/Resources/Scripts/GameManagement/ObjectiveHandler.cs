using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveHandler : MonoBehaviour {
    [SerializeField] TextMeshProUGUI textObject;
    [SerializeField] List<Objective> objectives;
    int activeObjectiveIndex = 0;
    Objective ActiveObjective => objectives[activeObjectiveIndex];

    void Awake() {
        foreach (Objective o in objectives) {
            o.OnObjectiveCompletionEvent += OnObjectiveCompletion;
        }

        textObject.text = ActiveObjective.description;
    }

    public void AddObjective(Objective objective) {
        if (!objectives.Contains(objective)) {
            objectives.Add(objective);
        }
    }

    void OnObjectiveCompletion(Objective objective) {
        if (!objectives.Contains(objective))
            return;
            
        activeObjectiveIndex++;
        
        // If there is no next objective (there is no objective left)
        if (activeObjectiveIndex >= objectives.Count) {
            textObject.text = "";
            textObject.gameObject.SetActive(false);
            
            return;
        }

        // Next objective is not null and is contained in objectives
        textObject.gameObject.SetActive(true);
        textObject.text = ActiveObjective.description;
    }
}
