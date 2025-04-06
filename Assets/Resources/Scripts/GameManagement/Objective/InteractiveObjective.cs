using UnityEngine;

[CreateAssetMenu(fileName = "NewInteractableObjective", menuName = "Scriptable Objects/Objective/InteractableObjective")]
public class InteractiveObjective : Objective {
    [SerializeField] ItemData itemData;
    [SerializeField] int requiredCount = 1;
    int currentCount = 0;

    void OnEnable() {
        itemData.OnPickUpEvent += Progress;
    }

    public override void Progress() {
        currentCount++;

        if (currentCount >= requiredCount)
            Complete();
    }
}