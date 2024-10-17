using UnityEngine;

public class SUMMATIONCollision : MonoBehaviour
{
    // Assign the particle system prefab (explosion) in the inspector or dynamically
    public GameObject explosionPrefab; 
    private Rigidbody bulletRigidbody;
    public float speed=3000f;
     public float scaleIncreaseRate = 20f; // How fast the object scales
    public float rotationSpeed = 90f; // Degrees per second for Y-axis rotation

    // Called when the arrow collides with another object
    private void Awake(){
        bulletRigidbody=GetComponent<Rigidbody>();
        Debug.Log("romanalskjdhflkasdhf");
    }
    
    private void Start(){

bulletRigidbody.velocity=transform.forward*speed;

    }

 private void Update()
    {
        // Continuously increase the size of the object
        transform.localScale += Vector3.one * scaleIncreaseRate * Time.deltaTime;

        // Continuously rotate the object around the Y-axis by 90 degrees per second
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }



    private void OnCollisionEnter(Collision collision)
    {
        // Instantiate the particle system explosion at the point of collision
        if (explosionPrefab != null)
        {
            // Create the explosion effect at the collision point with the same rotation as the object hit
           GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosionInstance, 5f);
        }

        // Optionally, destroy the arrow on impact
        Destroy(gameObject,5f);
        
    }
}
