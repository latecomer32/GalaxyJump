using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{

    public bool YOUWIN = false;



    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            YOUWIN = true;

            Debug.Log("YOU WIN");

            gameManager.instance.WinTheGame();
        }

    }

    public void ExitReset()
    {
        YOUWIN = false;
    }

}
