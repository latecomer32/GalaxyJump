using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnGenerator : MonoBehaviour {

    public GameObject[] proPrefabs;

 //   SphereCollider area;

    public int count = 100;

 public   List<GameObject> props = new List<GameObject>();

    // public float radius = area.radius + 5.0f; // 랜덤 오브젝트 생성 구 반지름
    public float radius = 110f; // 랜덤 오브젝트 생성 구 반지름
    private float Ran_Azimuth;
    private float Ran_Elevation;

    public float minAzimuth;
  //  private float _minAzimuth;

    public float maxAzimuth;  //방위, 좌우 각도, θ,Azimuth
  //  private float _maxAzimuth;


    public float minElevation; //양각, 상하 각도, ￠, Φ,Elevation
  //  private float _minElevation;

    public float maxElevation;
    //  private float _maxElevation;

    Vector3 spawnPos;

    void Start()
    {
        //     area = GetComponent<SphereCollider>();

        for (int i = 0; i < count; i++)
        {
            Spawn();
         //  props[i].SetActive(true);
        }

        // area.enabled = false;

    }

  



    void Spawn()
    {
 
      //  _minAzimuth = Mathf.Deg2Rad * minAzimuth;
      //  _maxAzimuth = Mathf.Deg2Rad * maxAzimuth;

      //  _minElevation = Mathf.Deg2Rad * minElevation;
       // _maxElevation = Mathf.Deg2Rad * maxElevation;

        int selection = Random.Range(0, proPrefabs.Length);

        GameObject selectedPrefab = proPrefabs[selection];

        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

        props.Add(instance);
    }



    Vector3 GetRandomPosition()
    {
        Ran_Elevation = Random.Range(minAzimuth, maxAzimuth);
        Ran_Azimuth = Random.Range(minElevation, maxElevation);

        Vector3 basePosition = transform.position;

        float posX = basePosition.x + toCartesian.x;
        float posY = basePosition.y + toCartesian.y;
        float posZ = basePosition.z + toCartesian.z;

       spawnPos = new Vector3(posX,posY,posZ);
        return spawnPos;

    }



    public Vector3 toCartesian
    {
        get
        {
            /*
          float t = radius * Mathf.Cos(Ran_Elevation);
          return new Vector3(t * Mathf.Cos(Ran_Azimuth), radius * Mathf.Sin(Ran_Elevation),
              t * Mathf.Sin(Ran_Azimuth));
               */

            return new Vector3(radius * Mathf.Sin(Ran_Azimuth) * Mathf.Cos(Ran_Elevation),
                                  radius * Mathf.Cos(Ran_Azimuth),
                                  radius * Mathf.Sin(Ran_Azimuth) * Mathf.Sin(Ran_Elevation));
         
            
            // (rSinθCos￠ , rCosθ ,rSinθSin￠)
        }
    }



    public void SpawnReset()
    {
        for (int i = 0; i < props.Count; i++)
        {
            props[i].transform.position = GetRandomPosition();
         //  props[i].SetActive(true);
        

        }

    }          





}








/*
   public Transform pivot;

   [System.Serializable]
   public class SphericalCoordinates
   {

       public float _radius, _azimuth, _elevation;

       public float radius

       {
           get { return _radius; }
           private set
           {
               _radius = Mathf.Clamp(value, _minRadius, _maxRadius);

           }
       }


       public float azimuth
       {
           get { return _azimuth; }
           private set
           {
               _azimuth = Mathf.Repeat(value, _maxAzimuth - _minAzimuth);
           }

       }
       public float elevation
       {
           get { return _elevation; }
           private set
           {
               _elevation = Mathf.Clamp(value, _minElevation, _maxElevation);
           }
       }
       public float _minRadius = 515f;
       public float _maxRadius = 520f;

       public float minAzimuth = 0f;
       private float _minAzimuth;

       public float maxAzimuth = 360f;
       private float _maxAzimuth;

       public float minElevation = 0f;
       private float _minElevation;

       public float maxElevation = 360f;
       private float _maxElevation;

       public SphericalCoordinates() { };

       public SphericalCoordinates(Vector3 cartesianCoordinate)
       {
           _minAzimuth = Mathf.Deg2Rad * minAzimuth;
           _maxAzimuth = Mathf.Deg2Rad * maxAzimuth;

           _minElevation = Mathf.Deg2Rad * minElevation;
           _maxElevation = Mathf.Deg2Rad * maxElevation;

           radius = cartesianCoordinate.magnitude;
           azimuth = Mathf.Atan2(cartesianCoordinate.z, cartesianCoordinate.x);
           elevation = Mathf.Asin(cartesianCoordinate.y / radius);

       }

       public Vector3 toCartesian
       {
           get
           {
               float t = radius * Mathf.Cos(elevation);
               return new Vector3(t * Mathf.Cos(azimuth), radius * Mathf.Sin(elevation),
                   t * Mathf.Sin(azimuth));
           }
       }


       public SphericalCoordinates Rotate(float newAzimuth, float newElevation)
       {
           azimuth += newAzimuth;
           elevation += newElevation;
           return this;
       }

       public SphericalCoordinates TranslateRadius(float x)
       {
           radius += x;
           return this;
       }
   }



       public SphericalCoordinates sphericalCoordinates;

*/





/*구좌표계
sphericalCoordinates = new SphericalCoordinates(transform.position);
transform.position = sphericalCoordinates.toCartesian;
*/











/*
//정해진 오브젝트 랜덤생성
void Start()
{
    StartCoroutine(ObjectRandomGenerator());
}

IEnumerator ObjectRandomGenerator()
{
    GameObject[] tempGO = new GameObject[4];

    tempGO[0] = object1;
    tempGO[1] = object2;
    tempGO[2] = object3;
    tempGO[3] = object4;

    while (true)
    {
        Instantiate(tempGO[Random.range(0, 4)]);
        yield return new WaitForSeconds(5f);
    }
}
*/
