using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    Move1 move1Sc;
 //   bool Running;

   
    void Start()
    {
        move1Sc = GameObject.Find("Player_start").GetComponent<Move1>();
    }

    /*
      private void OnCollisionStay(Collision col)
      {

          if (move1Sc.v > 0 || move1Sc.h > 0)
          {
              Soundmanager.instance.STEP_Sound();

              Debug.Log("Sound22");
          }

          Debug.Log("Sound");
      }
      */

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag ("Stone") || col.CompareTag("enemy") || col.CompareTag("Exit"))
        { 

        if (move1Sc.v > 0 || move1Sc.h > 0)
        {
                Soundmanager.instance.STEP_Sound();
        }

    }
    }
}
