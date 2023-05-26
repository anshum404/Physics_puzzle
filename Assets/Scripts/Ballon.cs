using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
  
   // public GameObject balloonPrefab;     // Prefab of the balloon
   // public GameObject red; 
   // public GameObject black; 
   public GameObject[] balloons;

    public float ascentSpeed = 1f;       // Speed at which the balloon goes up

    [SerializeField]
    private Transform[] ballonSpawnPoints = null;

    private void Start()
    {
        InvokeRepeating("AppearBallon", 0.5f, 2f);
    }
    void AppearBallon()
    {
        int rndm = Random.Range(0, ballonSpawnPoints.Length);
         // Instantiate the balloon prefab
         int rand=Random.Range(0,balloons.Length);
         GameObject balloon = Instantiate(balloons[rand], ballonSpawnPoints[rndm].position, Quaternion.identity);

         // Add a constant force to make the balloon go up
         Rigidbody rb = balloon.GetComponent<Rigidbody>();
         rb.AddForce(Vector3.up * ascentSpeed, ForceMode.VelocityChange); 
    }
}
