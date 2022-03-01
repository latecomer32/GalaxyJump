using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform tr;
    Transform PlayerTr;
    FauxGravityAttractor fauxAttractor;



     float speed=0.045f;
    public float damping = 10f;
   int jumpPower= 20;
    bool enemyjumpdelay;

  

    bool isAttack = false;

   // Vector3 movePos;

    Vector3 startposition;
    Quaternion startQuaternion;


    void Start()
    {
        startposition = transform.position;
        startQuaternion = transform.rotation;


        tr = GetComponent<Transform>();
        PlayerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       

        fauxAttractor = GameObject.Find("Planet").GetComponent<FauxGravityAttractor>();

        // StartCoroutine(EnemyjumpDelay(4f));
    }


    public void enemyReset()
    {
        transform.rotation = startQuaternion;
        transform.position = startposition;
    }


    void Update()
    {
    //    float dist = Vector3.Distance(tr.position, PlayerTr.position);
  

     //   movePos = PlayerTr.position;

        Debug.Log("speed = " + speed);

      //  transform.LookAt(PlayerTr);

        tr.position = Vector3.MoveTowards(tr.position, PlayerTr.position, speed);




        /*
               Vector3 gravityUp = (tr.position - transform.position).normalized;
               Vector3 bodyUp = tr.up;

              tr.GetComponent<Rigidbody>().AddForce(gravityUp * fauxAttractor.gravity);

               Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * tr.rotation;


               Quaternion AAA = Quaternion.Slerp(tr.rotation, targetRotation, 50 * Time.deltaTime);
               Vector3 AAAA = AAA.eulerAngles;


               Quaternion BBB = Quaternion.LookRotation(PlayerTr.position - tr.position);



               tr.rotation = Quaternion.Euler( new Vector3(AAAA.x + BBB.x, AAAA.y + BBB.y, AAAA.z + BBB.z));

               tr.rotation = Quaternion.Slerp(tr.rotation, targetRotation, 50 * Time.deltaTime);
       */



        /*
            Quaternion rot = Quaternion.LookRotation(PlayerTr.position - tr.position);

            tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);


        Vector3 dirToTarget = PlayerTr.position - tr.position;
        Vector3 look = Vector3.Slerp(tr.forward, dirToTarget.normalized, Time.deltaTime);
        look.Normalize();
       float angleH = Mathf.Acos(Vector3.Dot(Vector3.forward, look)) * Mathf.Rad2Deg;
       float angleV = Mathf.Acos(Vector3.Dot(Vector3.up, look)) * Mathf.Rad2Deg;

        if ((angleH < 10.0f && angleH > -10.0f) && (angleV > 10.0f && angleV < 10.0f))
            tr.rotation = Quaternion.LookRotation(look, Vector3.up);





       tr.Translate(Vector3.forward * Time.deltaTime * speed);




     Vector3 vec = PlayerTr.position - tr.position;

     vec.Normalize();

     Quaternion rot = Quaternion.LookRotation(vec);

     //tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
    tr.rotation= rot;





       if (dist <= 2f)
     {
         isAttack = true;
         Debug.Log("You Attacked");
     }

     else
     {
         movePos = PlayerTr.position;
     }

    if (dist < 5f)
    {
        speed = 5f;
    }

    else  if (dist <= 35f)
    {
       speed = 10f;
    }

    else if (dist <= 50f)
    {
       speed = 25f;

    }
    else if (dist <= 100f)
    {
       speed = 35f;
    }
    else
    {
       speed = 50f;

    }



    if (enemyjumpdelay == true)
    {
       return;
    }
    GetComponent<Rigidbody>().AddForce(transform.up * jumpPower);
    */
    }




    /*

  IEnumerator EnemyjumpDelay(float cool)
  {
      while (cool > 1.0f)
      {
          enemyjumpdelay = true;

          cool -= Time.deltaTime;
          //     start_time.fillAmount = (1.0f / cool);
          yield return new WaitForFixedUpdate();
      }
      enemyjumpdelay = false;


  }


  private void OnCollisionEnter(Collision col)
  {


      if (col.collider.tag == "Stone")
      {

          if (enemyjumpdelay == true)
          {
              return;
          }


          GetComponent<Rigidbody>().AddForce(transform.up * jumpPower);

          StartCoroutine(EnemyjumpDelay(2f));
      }

  }
  */

}

