using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class mission2 : MonoBehaviour
{


    float cnt=0;
    public GameObject player;
    public GameObject player2;
    public GameObject part1;
    public GameObject part2;
    public AudioSource src;
    public AudioClip sfx1;
    
    
    public GameObject videoplayer;
    public TMP_Text countdownText; // Assign your Text component in the Inspector
    public GameObject restartMessage; // Assign your Text/Image GameObject in the Inspector
    public GameObject cam;
    bool suc=false;
   

    GameObject enemyObject;
     List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {enemyObject = GameObject.FindGameObjectWithTag("gang");
    src.clip=sfx1;
        src.loop=true;
        src.volume = 0.2f;
        src.Play();

        foreach (Transform child in enemyObject.transform)
{
    
    enemies.Add(child.gameObject);
    
}
    }

    // Update is called once per frame
    void Update()
    {
        cnt = 0;

    // Loop through all the enemies to check their health
    foreach (GameObject enemy in enemies)
    {
        // Access the 'dragonhealth' script attached to each enemy
        dragonhealth healthScript = enemy.GetComponent<dragonhealth>();

        // Check if 'currethealth' is 0, and if so, increase the counter
        if (healthScript != null && healthScript.currentHealth == 0)
        {
            cnt++;
        }
    }



        
        if(part1.GetComponent<RockCollision>().collisionValue==1 ||part2.GetComponent<RockCollision>().collisionValue==1){
suc=true;
        }
        

if(player2.GetComponent<PlayerHealth>().currentHealth == 0 && suc!=true  ){

        
        player.SetActive(false);
        restartMessage.SetActive(true);
        cam.SetActive(true);
        enemyObject.SetActive(false);
         StartCoroutine(RestartCountdown());

    
    
    }
    
if(player2.GetComponent<PlayerHealth>().currentHealth == 0 && suc==true || suc==true && cnt==21){

        
        StartCoroutine(DelayAndSwitch());
    
    
    }
    
    
    
    
    
    
    
    }

 private IEnumerator DelayAndSwitch()
    {
        // Wait for 3 seconds
       src.Stop();
        // After the delay, set player inactive and videoplayer active
        player.SetActive(false);
        videoplayer.SetActive(true);
        cam.SetActive(true);
        enemyObject.SetActive(false);
        yield return new WaitForSeconds(16f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("main 4");
    }




private IEnumerator RestartCountdown()
    {
        // Countdown from 3 to 1
        for (int i = 8; i > 0; i--)
        {
            countdownText.text = "The game will restart in " + i;
            yield return new WaitForSeconds(1f); // Wait for 1 second
        }

        // Restart the game or load the scene again (assuming you have a scene named "GameScene")
        // You can also replace "GameScene" with your actual scene name
        UnityEngine.SceneManagement.SceneManager.LoadScene("main 3");
    }




}
