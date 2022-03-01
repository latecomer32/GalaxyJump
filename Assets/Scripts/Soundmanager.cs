using System.Collections;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{

    public AudioClip JumpSound;
    public AudioClip StepSound;
   public AudioSource myAudio;

    public static Soundmanager instance;

    private void Awake()
    {
        if (Soundmanager.instance == null)
        { Soundmanager.instance = this; }
           
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

   
   public void JUMP_Sound()
    {
        //  myAudio.PlayOneShot(JumpSound);

        myAudio.clip = this.JumpSound;
        this.myAudio.volume = 0.3f;
        myAudio.Play();

    }
    
    
    public void STEP_Sound()
    {
      //  myAudio.PlayOneShot(StepSound);

        myAudio.clip = this.StepSound;
        this.myAudio.volume = 1f;
        myAudio.Play();
    }
    
}
