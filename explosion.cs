using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    // Assign the particle system prefab (explosion) in the inspector or dynamically
    public GameObject explosionPrefab; 
    private Rigidbody bulletRigidbody;
    public float speed=3000f;

    // Called when the arrow collides with another object
    private void Awake(){
        bulletRigidbody=GetComponent<Rigidbody>();
    }
    
    private void Start(){

bulletRigidbody.velocity=transform.forward*speed;

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Instantiate the particle system explosion at the point of collision
        if(collision.gameObject.CompareTag("hero")){
            Debug.Log("roman");
        }
        
        else if(collision.gameObject.CompareTag("enemy")){

            collision.gameObject.GetComponent<dragonhealth>().TakeDamage(10);
            Destroy(gameObject);
            
        }
        
        else{
        if (explosionPrefab != null)
        {
            // Create the explosion effect at the collision point with the same rotation as the object hit
           GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosionInstance, 5f);
        
        Destroy(gameObject);
        
        }

        // Optionally, destroy the arrow on impact
        // Destroy(gameObject);
        
    }
    
    } 

}
