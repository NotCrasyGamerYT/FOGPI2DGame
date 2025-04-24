using System;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public P1Health P1Health;
    public P2Health P2Health;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (P1Health = null)
        {
            Debug.Log("P2 Wins");
        }
    }
}
