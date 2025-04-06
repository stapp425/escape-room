using TMPro;
using UnityEngine;

public class InteractionTextManager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI interactTextBox;
    [SerializeField] TextMeshProUGUI interactKeyBox;

    public static InteractionTextManager Current { get; private set; }

    void Awake() {
        if (Current != null && Current == this) {
            Current = null;
            Destroy(Current);
        } else {
            Current = this;
        }

        SetTextVisibility(false);
    }

    public bool IsActive() => gameObject.activeSelf;

    public void SetTextVisibility(bool isActive) => gameObject.SetActive(isActive);

    public void SetTextContent(string text) => interactTextBox.text = text;

    public void SetInteractKey(string text) => interactKeyBox.text = text;
}
