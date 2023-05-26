using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class DartLauncher : MonoBehaviour
{
    public GameObject dartPrefab;        // Prefab of the dart
    public Transform target;             // Transform of the floating target

    public Slider forceSlider;           // Reference to the slider for controlling the launch force
    public float minForce = 10f;         // Minimum launch force
    public float maxForce = 100f;
    public GameObject GameOver;
    public AudioSource audio;
    

    private float launchSpeed ;      // Launch speed of the dart
    int score=0;


    private int dartCount = 25;
    //public TMP_Text speedValue;
    public TMP_Text scoretext;
    public TMP_Text remainimgDarts;
     public TMP_Text endscoretext;
    

    private void Start()
    {
        OnForceSliderValueChanged();
        //speedValue.text = "" + ((int)launchSpeed);
       

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            OnForceSliderValueChanged();
            SetTarget();
            if(dartCount>=1)
                LaunchDart();
        }

        if (dartCount == 0)
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
            endscoretext.text=""+score;
            //load end game
        }
    }

    private void SetTarget()
    {
        // Create a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        // Perform a raycast to detect the collision point with the ground plane
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Set the target as the point where the mouse is clicked
            target = hit.transform;
            
        }
    }

    public void OnForceSliderValueChanged()
    {
        // Update the launch force based on the slider value
        launchSpeed = Mathf.Lerp(minForce, maxForce, forceSlider.value);
        //speedValue.text = "" + ((int)launchSpeed);
    }

    void LaunchDart()
    {

        dartCount--;

        remainimgDarts.text=""+dartCount;

        // Instantiate the dart prefab
        GameObject dart = Instantiate(dartPrefab, transform.position, Quaternion.identity);

         audio.Play();

        // Calculate the launch direction towards the target
        Vector3 launchDirection = (target.position - transform.position).normalized;

        // Calculate the launch velocity based on the launch speed and launch direction
        Vector3 launchVelocity = launchSpeed * launchDirection;

        // Get the Rigidbody component of the dart
        Rigidbody rb = dart.GetComponent<Rigidbody>();
       

        // Apply the launch velocity to the Rigidbody component
        rb.velocity = launchVelocity;

        

        Destroy(dart,5f);
    }

    public void UpdateScore()
    {
        //update score
            Debug.Log("Checking");
            score++;
            scoretext.text=""+score;
    }
}
