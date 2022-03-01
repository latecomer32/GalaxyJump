using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FauxGravityAttractor : MonoBehaviour
{
  

   public float gravity;
   public bool gravityPowerUp;

    public  void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
           body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
     //     body.rotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;


       


    }


    private void Start()
    {
        StartCoroutine(GravityUp(4.0f));  //시작 시 중력을 순간적으로 강하게 올림
    }

    public void AttractorReset()
    {
        StartCoroutine(GravityUp(4.0f));
    }


   void Update()
    {
     
        if (gravityPowerUp == true)
        {
            gravity = -100f;
         
        }
        else if (gravityPowerUp == false)
        { 
            gravity = -5f;
        }
    }


    IEnumerator GravityUp(float cool)
    {

        while (cool > 1.0f)
        {
            gravityPowerUp = true;
            cool -= Time.deltaTime;
            //     start_time.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }

        gravityPowerUp = false;

    }
}

