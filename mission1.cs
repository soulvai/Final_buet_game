using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

using TMPro;
public class mission1 : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> enemies = new List<GameObject>();
    float cnt=0;
    public GameObject player;
    public AudioSource src;
    public AudioClip sfx1;
    public GameObject player2;
    public VideoPlayer videoPlayer2;    
    
    
    public GameObject videoplayer;
    public TMP_Text countdownText; // Assign your Text component in the Inspector
    public GameObject restartMessage; // Assign your Text/Image GameObject in the Inspector
    public GameObject cam;
GameObject enemyObject;
    void Start()
    {
        
     enemyObject = GameObject.FindGameObjectWithTag("gang");
        enemyObject.SetActive(false);    
         player.SetActive(false);
        cam.SetActive(true);
     videoPlayer2.Play();
        
      videoPlayer2.loopPointReached += OnVideoEnd;

    }



void OnVideoEnd(VideoPlayer vp)
    {enemyObject.SetActive(true);
        player.SetActive(true);
        cam.SetActive(false);
        src.clip=sfx1;
        src.loop=true;
        src.volume = 0.2f;
        src.Play();
        
        // Enable the gameplay elements after the video ends
        
        foreach (Transform child in enemyObject.transform)
{
    
    enemies.Add(child.gameObject);
    
}
        // Optionally, hide or disable the video object
        videoPlayer2.gameObject.SetActive(false);
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
    if(cnt==4){

        StartCoroutine(DelayAndSwitch());
    }
    
    if(player2.GetComponent<PlayerHealth>().currentHealth == 0){

        enemyObject.SetActive(false);
        player.SetActive(false);
        restartMessage.SetActive(true);
        cam.SetActive(true);
         StartCoroutine(RestartCountdown());

    
    
    }
    
    
    
    }


 private IEnumerator DelayAndSwitch()
    {
        // Wait for 3 seconds
        src.Stop();
        yield return new WaitForSeconds(5f);
        

        // After the delay, set player inactive and videoplayer active
        player.SetActive(false);
        videoplayer.SetActive(true);
        cam.SetActive(true);
        yield return new WaitForSeconds(10f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("main 3");
    
    }

private IEnumerator RestartCountdown()
    {
        // Countdown from 3 to 1
        for (int i = 5; i > 0; i--)
        {
            countdownText.text = "The game will restart in " + i;
            yield return new WaitForSeconds(1f); // Wait for 1 second
        }

        // Restart the game or load the scene again (assuming you have a scene named "GameScene")
        // You can also replace "GameScene" with your actual scene name
        UnityEngine.SceneManagement.SceneManager.LoadScene("main 2");
    
    
    }


}
