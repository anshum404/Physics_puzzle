using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour
{ 


   public DartLauncher launcher; 
   void Start()
   {
             launcher=GameObject.FindGameObjectWithTag("Player").GetComponent<DartLauncher>();
    
   }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dart"))
        {
            launcher.UpdateScore();
            Destroy(gameObject);
        }
    }
}
