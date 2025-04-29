// Assets/Scripts/CharacterSelectManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour
{
    [Header("All Available Characters")]
    public CharacterData[] characters;

    [Header("UI References")]
    public Text p1NameText;
    public Text p2NameText;
    public Button p1ConfirmButton;
    public Button p2ConfirmButton;
    public Button startFightButton;

    // static so PlayScene can read them
    public static CharacterData P1Selection;
    public static CharacterData P2Selection;

    private void Start()
    {
        p1ConfirmButton.interactable = false;
        p2ConfirmButton.interactable = false;
        startFightButton.interactable = false;
    }

    // Called by each portrait‐button's OnClick()
    public void SelectForPlayer1(int characterIndex)
    {
        P1Selection = characters[characterIndex];
        p1NameText.text = P1Selection.characterName;
        p1ConfirmButton.interactable = true;
        TryEnableStart();
    }

    public void SelectForPlayer2(int characterIndex)
    {
        P2Selection = characters[characterIndex];
        p2NameText.text = P2Selection.characterName;
        p2ConfirmButton.interactable = true;
        TryEnableStart();
    }

    // Only when both confirmed
    public void OnP1Confirm() => TryEnableStart();
    public void OnP2Confirm() => TryEnableStart();

    private void TryEnableStart()
    {
        if (P1Selection != null && P2Selection != null)
        {
            startFightButton.interactable = true;
        }
    }

    // Hooked to “Start Fight” button
    public void OnStartFight()
    {
        // Persist selection via the static fields, then load the fight
        SceneManager.LoadScene("Game");
    }
}
