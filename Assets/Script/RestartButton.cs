using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // This method can be linked to the button click event
    public void RestartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f; // Resume the game speed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
