using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Behavior : MonoBehaviour
{

    public UIManager UIman;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.gc.isLevelStarted = false;
            GameController.gc.isControllable = false;
            GameController.gc.RestoreLight();

            UIman.WinGame();
            
        }
    }
}
