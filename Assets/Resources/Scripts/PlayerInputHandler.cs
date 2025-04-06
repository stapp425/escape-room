using UnityEngine;

public class PlayerInputHandler : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] Transform cameraTransform;

    // Update is called once per frame
    void Update() {
        player.SetRotation(cameraTransform.rotation);
        
        if (Input.GetKey(KeyCode.W)) {
            Vector3 cameraTransformForward = cameraTransform.forward;
            cameraTransformForward.y = 0;
            
            player.Move(cameraTransformForward);
        }

        if (Input.GetKey(KeyCode.A)) {
            Vector3 cameraTransformLeft = -cameraTransform.right;
            cameraTransformLeft.y = 0;

            player.Move(cameraTransformLeft);
        }

        if (Input.GetKey(KeyCode.S)) {
            Vector3 cameraTransformBackward = -cameraTransform.forward;
            cameraTransformBackward.y = 0;

            player.Move(cameraTransformBackward);
        }

        if (Input.GetKey(KeyCode.D)) {
            Vector3 cameraTransformRight = cameraTransform.right;
            cameraTransformRight.y = 0;

            player.Move(cameraTransformRight);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = !Cursor.visible;
        }
    }
}
