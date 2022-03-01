using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move1 : MonoBehaviour
{
    Transform Tr;
    Transform PlanetTr;
    Transform EnemyTr;
  //   List<Transform> StoneTr = new List<Transform>();
  //  Transform[] StoneTr;

   public GameObject Deathcause;
    GameObject Planetobject;
    GameObject Enemyobject;
    GameObject[] Stoneobj;
 //   List<GameObject> Stoneobj = new List<GameObject>();

    SpawnGenerator SpawnSc;

    //Move1 move1;

    bool startDelay;

    public Image start_time;

    bool jump;

    public float moveSpeed = 5f;
    public float turnSpeed = 540f;

    Vector3 movement;
  
    //  Joystick joystick; 시야 좌우로 움직이는 기능 삭제

    public float jumpPower = 5f;

    public Image jump_Skill;

    public Text coolTimeCounter;
    public float coolTime;
    float currentCoolTime;
    bool jumpdelay;
    bool touchdelay;

    Vector3 smoothMoveVelocity;

    Vector3 startposition;
    Quaternion startQuaternion;

   public float h;
   public float v;
    float[] Stonedist;
    float PlanetRange;
    float EnemyRange;
   Vector3 PlanetTrPosition;

    private void Awake()
    {

        startposition = transform.position;
        startQuaternion = transform.rotation;

        //       joystick = FindObjectOfType<Joystick>(); 시야 좌우로 움직이는 기능 삭제
        StartCoroutine(StartDelay());


        Tr = GetComponent<Transform>();
        PlanetTr = GameObject.FindGameObjectWithTag("Planet").GetComponent<Transform>();
        EnemyTr = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
        //       StoneTr = GameObject.FindGameObjectsWithTag("Stone").GetComponent<Transform>();

        SpawnSc = GameObject.Find("SpawnGenerator").GetComponent<SpawnGenerator>();

        Planetobject = GameObject.Find("Planet");
        Enemyobject = GameObject.Find("Enemy");
        Stoneobj = GameObject.FindGameObjectsWithTag("Stone");
    }


    void Start()
    {
       

       PlanetRange = PlanetTr.localScale.x *0.5f + Tr.localScale.x *0.5f;
       EnemyRange = EnemyTr.localScale.x * 0.6f + Tr.localScale.x * 0.5f;

        PlanetTrPosition = PlanetTr.position;
    }
    

    void Update()
    {


        h = SimpleInput.GetAxis("Horizontal");
        v = SimpleInput.GetAxis("Vertical");


        transform.Translate(0f, 0f, v * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, h * turnSpeed * Time.deltaTime, 0f);




        /*

          //SpawnSc.count
          for (int i = 0 ; i < SpawnSc.count-1; i++)
          {
              Debug.Log("i=" + i);

              Debug.Log(" SpawnSc.props[i].transform.position" + SpawnSc.props[i].transform.position);

              Stonedist[i] = Vector3.Distance(Tr.position, SpawnSc.props[i].transform.position);




              if (Stonedist[i] < 3f)
                  {
                  Debug.Log("show");
                      Stoneobj[i].SetActive(false);
                  }
          }
          */


        /*
        for (int i = 0 ; i < SpawnSc.count ; i++)
        {
           

            if ( SpawnSc.props[i]. < 1f)
            {
                props[i].SetActive( true);
            }

        }
        */



        //        transform.Rotate(0f, joystick.Horizontal * turnSpeed * Time.deltaTime, 0f); 시야좌우로 움직이는 기능 삭제
        //     Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //    Vector3 targetMoveAmount = moveDir * moveSpeed;
        //   Vector3 moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);


        //  movePos = PlayerTr.position;



        /*
             if(Planetdist <=PlanetTr.localScale.x/2 +Tr.localScale.x || Enemydist<= EnemyTr.localScale.x+Tr.localScale.x )
                {
                    if (startDelay == true)
                    {
                        return;
                    }
                    Debug.Log("YOU DIE");
                    gameManager.instance.OnDestroy();
        */


    }

    


        IEnumerator StartDelay()
    {
        /*
        while (cool > 1.0f)
        {
         //   startDelay = true;
            cool -= Time.deltaTime;
            //     start_time.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }
        */

      

        yield return new WaitForSeconds(7f);

       


        startDelay = false;

        while (startDelay == false)
        {
           


            float Planetdist = Vector3.Distance(Tr.position, PlanetTrPosition);
            float Enemydist = Vector3.Distance(Tr.position, EnemyTr.position);

            if (Planetdist <= PlanetRange || Enemydist <= EnemyRange)
            {
                if(Planetdist <= PlanetRange)
                {
                    Deathcause = Planetobject;
                }
                else if(Enemydist <= EnemyRange)
                {
                    Deathcause = Enemyobject;
                }

                Debug.Log("Planet"+ Planetdist);
                Debug.Log("enemy" + Enemydist);

                startDelay = true;
                gameManager.instance.OnDestroy();

            }
            yield return new WaitForFixedUpdate();
        }
       
    
   }
   
    public void JUMP()
    {
        
        if (jumpdelay == true)
        {
            return;
        }
        

        Soundmanager.instance.JUMP_Sound();

        GetComponent<Rigidbody>().AddForce(transform.up * jumpPower);
        StartCoroutine(jumpDelay(2f));
    }

    /*
    private void OnEnable()
    {
        transform.rotation = startQuaternion;
        transform.position = startposition;

      //  state = MoveState.Idle;
      // move1.enabled = false;
    }
    */

    public void MoveReset()
    {
        transform.rotation = startQuaternion;
        transform.position = startposition;
        StartCoroutine(StartDelay());

    }
       
    


  /*

IEnumerator StartDelay(float cool)
{
    while (cool > 1.0f)
    {
        startDelay = true;
        cool -= Time.deltaTime;
        //     start_time.fillAmount = (1.0f / cool);
        yield return new WaitForFixedUpdate();
    }

    startDelay = false;
}
*/

IEnumerator jumpDelay(float cool)
{
    while (cool > 1.0f)
    {
        jumpdelay = true;
        cool -= Time.deltaTime;
        jump_Skill.fillAmount = (1.0f / cool);
        yield return new WaitForFixedUpdate();
    }

    jumpdelay = false;
}
        

}