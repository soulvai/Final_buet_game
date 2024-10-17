using UnityEngine;

public class Dragu : MonoBehaviour
{
    // Assign the particle system prefab (explosion) in the inspector or dynamically
    public GameObject explosionPrefab; 
    public GameObject explosionPrefab2; 
    
    private Rigidbody bulletRigidbody;
    public float speed;


    // Called when the arrow collides with another object
    private void Awake(){
        bulletRigidbody=GetComponent<Rigidbody>();
    }
    
    private void Start(){
        GameObject explosionInstance2 = Instantiate(explosionPrefab2, transform.position, Quaternion.identity);
        explosionInstance2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); 
        
        
          explosionInstance2.transform.SetParent(transform);
          

        bulletRigidbody.velocity=transform.forward*speed;

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Instantiate the particle system explosion at the point of collision
        if(collision.gameObject.CompareTag("hero") ||collision.gameObject.CompareTag("hero2") ){
            
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(15);
            Debug.Log("hero mair kacche");
            
            Destroy(gameObject);
        
        
        }
        
        else{
        
        if (collision.gameObject.tag!="enemy")
        {
            // Create the explosion effect at the collision point with the same rotation as the object hit
           GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
           explosionInstance.transform.localScale = new Vector3(.8f, .8f, .8f); 
        
        Destroy(explosionInstance, 5f);
        Destroy(gameObject);
      
        }

        // Optionally, destroy the arrow on impact
        
    }
    
    } 

}
