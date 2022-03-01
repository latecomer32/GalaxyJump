using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{

    /*
    
    private void OnCollisionStay(Collision col)
    {


        if (col.collider.tag == "enemy")
        {

            Destroy(gameObject, 0);
        }

    }
    */
  


        private void OnBecameVisible()
    {

        gameObject.GetComponent<Renderer>().enabled = true;
         // gameObject.SetActive(true);
        Debug.Log("dd");
    }

    private void OnBecameInvisible()
    {
        gameObject.GetComponent<Renderer>().enabled = false;

        //  gameObject.SetActive(false);
        Debug.Log("ddd");

    }
}
