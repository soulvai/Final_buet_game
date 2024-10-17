using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    // This method will be called when another collider enters the trigger
    private bool isNearCar = false;
     
    public GameObject car;
    public GameObject playerCamera;
    public GameObject carCamera;
    private Rigidbody carRb;  // Reference to the car's Rigidbody

    public float exitSpeedThreshold = 0.5f; // Set a threshold speed to allow exiting the car
    
     void Start()
    {
        carRb = car.GetComponent<Rigidbody>(); // Get the Rigidbody component of the car
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("hero2"))
        {
        
        isNearCar=true;
        
        
        }
    }

void Update()
    {
        if (isNearCar && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Activating car controls");

            // Activate car's controller script
            car.GetComponent<CarController>().enabled = true;
            playerCamera.transform.SetParent(car.transform);

            // Activate car's sound script
            // car.GetComponent<CarSound>().enabled = true;

            // Activate car's audio source
            // car.GetComponent<AudioSource>().enabled = true;

            // Switch camera to car
            // playerCamera.enabled = false;
            carCamera.SetActive(true);
            playerCamera.SetActive(false);
            car.GetComponent<AudioSource>().enabled = true;
            
        
        }
    
    if (isNearCar && Input.GetKeyDown(KeyCode.G))
        {
            if (carRb.velocity.magnitude < exitSpeedThreshold)
            {
            // Activate car's controller script
            car.GetComponent<CarController>().enabled = false;
            playerCamera.transform.SetParent(null);
            carRb.velocity = Vector3.zero;

            carCamera.SetActive(false);
            playerCamera.SetActive(true);
            car.GetComponent<AudioSource>().enabled = false;
            }
        
        }
    
    
    
    
    
    
    }






}