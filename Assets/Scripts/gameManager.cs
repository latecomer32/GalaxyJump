using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;

    public Text Navytext;

    public Text Enemy_Dis;

    public Text Exit_Dis;

    public Text messageText;

    public bool isRoundActive = false;

    public Enemy enemySc;

   public Move1 moveSc;

    public exit exitSc;

    public FauxGravityAttractor AttractorSc;

    public  GameObject readyPannel;
    public GameObject infoPannel;

    public SpawnGenerator spawngenerator;
   

    Transform ExitTr;
    Transform EnemyTr;
    Transform PlayerTr;

    float enemy_Dis;
    float exit_Dis;

   

    void Awake()
    {
        instance = this;
        StartCoroutine("RoundRoutine");

    //    Application.targetFrameRate = 60;
       
    }

    void Start()
    {

        ExitTr = GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>();
        EnemyTr = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
        PlayerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }




  

    IEnumerator DistanceUI()
    {
        enemy_Dis = Mathf.Ceil(Vector3.Distance(PlayerTr.position, EnemyTr.position));
        exit_Dis = Mathf.Ceil(Vector3.Distance(ExitTr.position, PlayerTr.position));

        yield return new WaitForFixedUpdate();
    }

        void UpdateUI()
    {
        Enemy_Dis.text = "Enemy Distance:" + enemy_Dis;
        Exit_Dis.text = "Exit Distance:" + exit_Dis;

        StartCoroutine(DistanceUI());
    }

 

    public void OnDestroy()
    {
      //  UpdateUI();
        isRoundActive = false;
    }

    public void WinTheGame()
    {
  //      UpdateUI();
        isRoundActive = false;
    }


    void Reset()
    {
        StartCoroutine("RoundRoutine");
        UpdateUI();
        spawngenerator.SpawnReset();
        exitSc.ExitReset();
        moveSc.MoveReset();
        enemySc.enemyReset();
        AttractorSc.AttractorReset();
    }

    IEnumerator RoundRoutine()
    {
        //ready
        Enemy_Dis.enabled = false;
        Exit_Dis.enabled = false;

        infoPannel.SetActive(false);

    Navytext.enabled = false;

        readyPannel.SetActive(true);
        moveSc.enabled = false;

        isRoundActive = false;

        messageText.text = "Ready...";

        yield return new WaitForSeconds(0.6f);

        messageText.text = " 3 !!";
        yield return new WaitForSeconds(0.8f);

        messageText.text = " 2 !!";
        yield return new WaitForSeconds(0.8f);

        messageText.text = " 1 !!";
        yield return new WaitForSeconds(0.8f);

       
        messageText.text = "Jump on the tile";
        yield return new WaitForSeconds(1f);


        //play

        // infoPannel.SetActive(true);

       

        moveSc.enabled = true;
       
        readyPannel.SetActive(false);

        isRoundActive = true;

        yield return new WaitForSeconds(3f);

        Navytext.enabled = true;


        Navytext.text = "Find the Exit!";

        yield return new WaitForSeconds(2f);

        Navytext.enabled = false;

        Enemy_Dis.enabled = true;
        Exit_Dis.enabled = true;

        while (isRoundActive == true)
        {
           

            UpdateUI();
            yield return null;
            
        }


        //end
     //   infoPannel.SetActive(false);
        readyPannel.SetActive(true);
        moveSc.enabled = false;
        Enemy_Dis.enabled = false;
        Exit_Dis.enabled = false;

        if ( exitSc.YOUWIN == true)
        {
            messageText.text = " W I N !!! wait a seconds";
        }

        else
        {
            messageText.text = "You died by:"+moveSc.Deathcause.name;
        }
       

        yield return new WaitForSeconds(2.5f);
        Reset();
           
    }
}
