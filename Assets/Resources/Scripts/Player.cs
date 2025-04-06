using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float speed;
    
    public InventoryManager inventory;
    CharacterController characterController;

    void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        Interactable interactable = GetViewedInteractable(5);
        
        if (interactable == null) {
            InteractionTextManager.Current.SetTextVisibility(false);
            return;
        }

        if (!interactable.isTouchToInteract) {
            interactable.OnHover();

            if (Input.GetKeyDown(interactable.interactKey))
                interactable.Interact(this);
        }
    }

    // for handling interactables that require collision for interaction
    // using layers instead of traditional tags
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable")) {
            other.gameObject.GetComponent<Interactable>()?.Interact(this);
        }
    }

    // returns an Interactable that is within a distance from this player
    // if none are nearby, then this returns null
    Interactable GetViewedInteractable(float distance) {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance)) {
            if (hit.collider.TryGetComponent(out Interactable interactable)) {
                return interactable;
            }
        }

        return null;
    }

    public void Move(Vector3 direction) {
        characterController.Move(speed * Time.deltaTime * direction.normalized);
    }

    public void SetRotation(Quaternion rotation) {
        // lock rotation to only the y-axis
        Quaternion playerLook = rotation;
        playerLook.x = 0;
        playerLook.z = 0;

        transform.eulerAngles = playerLook.eulerAngles;
    }
}
