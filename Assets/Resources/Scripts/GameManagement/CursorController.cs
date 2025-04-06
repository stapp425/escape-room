using UnityEngine;

public static class CursorController {
    public static void SetCursorVisibility(bool isVisible) {
        Cursor.visible = isVisible;
    }

    public static void SetCursorLockState(bool isLocked) {
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
