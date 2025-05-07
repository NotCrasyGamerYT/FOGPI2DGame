using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Tooltip("Assign your Pause Menu UI Panel here")]
    public GameObject pauseMenuUI;

    private bool isPaused = false;
    private PlayerControls controls;

    public MovementP1 movementP1;
    public MovementP2 movementP2;

    private void Awake()
    {
        controls = new PlayerControls();
        // Make sure you have a "Pause" action bound to <Keyboard>/escape and <Gamepad>/start
        controls.UI.Pause.performed += ctx => TogglePause();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void TogglePause()
    {
        if (isPaused) Resume();
        else Pause();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        // Optionally: unlock cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        movementP1.enabled = false;
        movementP2.enabled = false;

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        // Optionally: re-lock cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        movementP1.enabled = true;
        movementP2.enabled = true;

    }

    public void RestartLevel()
    {
        // Un-pause so timeScale is reset
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainmenuScene");
    }
}
