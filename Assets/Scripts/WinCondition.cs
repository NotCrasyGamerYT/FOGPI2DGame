using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [Tooltip("Drag the P1Health component here")]
    public P1Health p1Health;
    [Tooltip("Drag the P2Health component here")]
    public P2Health p2Health;

    public GameObject gameUIp1;
    public GameObject gameUIp2;

    // flag so we only announce the win once
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        // Player 1 died → Player 2 wins
        if (p1Health.health <= 0f)
        {
            gameEnded = true;
            OnPlayer2Win();
        }
        // Player 2 died → Player 1 wins
        else if (p2Health.health <= 0f)
        {
            gameEnded = true;
            OnPlayer1Win();
        }
    }

    private void OnPlayer1Win()
    {
        gameUIp1.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnPlayer2Win()
    {
        gameUIp2.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainmenuScene");
    }

    public void Resume()
    {
        gameUIp1.SetActive(false);
        gameUIp1.SetActive(false);
        Time.timeScale = 1f;
        // Optionally: re-lock cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
