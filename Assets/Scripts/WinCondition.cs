using System;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [Tooltip("Drag the P1Health component here")]
    public P1Health p1Health;
    [Tooltip("Drag the P2Health component here")]
    public P2Health p2Health;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        if (p1Health.health <= 0f)
        {
            gameEnded = true;
            OnPlayer2Win();
        }
        else if (p2Health.health <= 0f)
        {
            gameEnded = true;
            OnPlayer1Win();
        }
    }

    private void OnPlayer1Win()
    {
        Debug.Log("🎉 Player 1 Wins! 🎉");
        // TODO: trigger victory UI, animations, scene load, etc.
    }

    private void OnPlayer2Win()
    {
        Debug.Log("🎉 Player 2 Wins! 🎉");
        // TODO: trigger victory UI, animations, scene load, etc.
    }
}
