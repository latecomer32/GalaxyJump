using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
 

    public void back()
     {
            transform.Rotate(new Vector3(30, 180, 0));
     }
   
}
