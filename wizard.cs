using UnityEngine;

public class Wizard : MonoBehaviour
{
    // Assign the particle system prefab (explosion) in the inspector or dynamically
    public GameObject explosionPrefab; 
    public GameObject explosionPrefab2; 
    
    private Rigidbody bulletRigidbody;
    public int givedamage=30;
    public float speed=3000f;

    // Called when the arrow collides with another object
    private void Awake(){
        bulletRigidbody=GetComponent<Rigidbody>();
    }
    
    private void Start(){
        GameObject explosionInstance2 = Instantiate(explosionPrefab2, transform.position, Quaternion.identity);
        
         explosionInstance2.transform.SetParent(transform);
          explosionInstance2.transform.rotation = Quaternion.identity;


        bulletRigidbody.velocity=transform.forward*speed;

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Instantiate the particle system explosion at the point of collision
        if(collision.gameObject.CompareTag("hero")){
            
            collision.gameObject.GetComponent<PlayerHealth>().Increasehealth(100);
            Debug.Log("health bare");
            GameObject explosionInstance2 = Instantiate(explosionPrefab2, transform.position, Quaternion.identity);
            explosionInstance2.transform.localScale = new Vector3(.5f, .5f, .5f);
            explosionInstance2.transform.rotation = Quaternion.Euler(0, 90, 0);
   
            Destroy(explosionInstance2, 1f);
        
            Destroy(gameObject);
        
        }

        
        else{

         if (collision.gameObject.tag=="enemy"){
        collision.gameObject.GetComponent<dragonhealth>().TakeDamage(givedamage);
   GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
   
   explosionInstance.transform.localScale = new Vector3(.8f, .8f, .8f); 
        
        Destroy(explosionInstance, 5f);
        
            Destroy(gameObject);
            

        }



        else
        {
            // Create the explosion effect at the collision point with the same rotation as the object hit
           GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        
        Destroy(explosionInstance, 5f);
        }

        // Optionally, destroy the arrow on impact
        Destroy(gameObject);
        
    }
    
    } 

}
