using UnityEngine.SceneManagement;

public class Exit : RequirementInteractable {
    public override void Interact(Player player) {
        SceneManager.LoadScene("WinScene");
    }
}