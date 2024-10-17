using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class mission4 : MonoBehaviour
{

    public GameObject player1;
    public GameObject archer;
       public GameObject wizard;
   
    public GameObject player2;
    public AudioSource src;
    public AudioClip sfx1;
    public GameObject dragon;
    public TMP_Text countdownText; // Assign your Text component in the Inspector
    public GameObject restartMessage; // Assign your Text/Image GameObject in the Inspector
    public GameObject cam;
    public VideoPlayer videoPlayer2;    
    
    int flag=0;
    // Start is called before the first frame update
    void Start()
    {
        
        archer.SetActive(false);
        wizard.SetActive(false);
        dragon.SetActive(false);
        
        cam.SetActive(true);
       
    videoPlayer2.Play();
        
      videoPlayer2.loopPointReached += OnVideoEnd;
        
        }


void OnVideoEnd(VideoPlayer vp)
    {
        wizard.SetActive(true);
        
        archer.SetActive(true);
        dragon.SetActive(true);
        flag=1;
        src.clip=sfx1;
        src.loop=true;
        src.volume=.2f;
        src.Play();
        
        cam.SetActive(false);
        
        
        // Enable the gameplay elements after the video ends
        
        
        // Optionally, hide or disable the video object
        videoPlayer2.gameObject.SetActive(false);
    }





    // Update is called once per frame
    void Update()
    {
        if(player1.GetComponent<PlayerHealth>().currentHealth<=0 || player2.GetComponent<PlayerHealth>().currentHealth<=0 && dragon.GetComponent<dragonhealth>().currentHealth>0 ){
        if(flag==1){
        player1.SetActive(false);
        player2.SetActive(false);
        dragon.SetActive(false);
        restartMessage.SetActive(true);
        cam.SetActive(true);
         StartCoroutine(RestartCountdown());
        }
        }

    
    if(player1.GetComponent<PlayerHealth>().currentHealth>0 && player2.GetComponent<PlayerHealth>().currentHealth>0 && dragon.GetComponent<dragonhealth>().currentHealth<=0){
src.Stop();
                UnityEngine.SceneManagement.SceneManager.LoadScene("main 6");

    }
    
    
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("main 5");
    }






}
