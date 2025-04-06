using System;
using UnityEngine;

public abstract class Objective : ScriptableObject {
    public string description;
    [HideInInspector] bool isComplete = false;
    public event Action<Objective> OnObjectiveCompletionEvent;

    public virtual void Complete() {
        SetCompletionStatus(true);

        OnObjectiveCompletionEvent?.Invoke(this);
    }

    public bool SetCompletionStatus(bool isComplete) => this.isComplete = isComplete; 

    public bool IsComplete() => isComplete;

    public abstract void Progress();
}