using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class mission6 : MonoBehaviour


{
    public GameObject dragon;
    public GameObject dragon2;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public AudioSource src;
    public AudioClip sfx1;
    public GameObject enemy4;
    public GameObject player;
    public GameObject player2;
    
    public GameObject videoplayer;
    
    public VideoPlayer videoPlayer2;
    public TMP_Text countdownText; // Assign your Text component in the Inspector
    public GameObject restartMessage; // Assign your Text/Image GameObject in the Inspector
     public GameObject cam;
   float flag=0;
        
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        dragon.SetActive(false);
        dragon2.SetActive(false);
        enemy.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        enemy4.SetActive(false);
        
        player2.SetActive(false);
         videoPlayer2.Play();
         cam.SetActive(true);
        
        
      videoPlayer2.loopPointReached += OnVideoEnd;
    

        

        
    }


void OnVideoEnd(VideoPlayer vp)
    {
        
       videoPlayer2.gameObject.SetActive(false);
       flag=1;
       dragon.SetActive(true);
        dragon2.SetActive(true);
        enemy.SetActive(true);
        enemy2.SetActive(true);
        enemy3.SetActive(true);
        enemy4.SetActive(true);
        player2.SetActive(true);
        src.clip=sfx1;
        src.loop=true;
        src.volume=10f;
        src.Play();
        
        cam.SetActive(false);
        
        
        // Optionally, hide or disable the video object
        
    
    }






    // Update is called once per frame
    void Update()
    {
        

if(player.GetComponent<PlayerHealth>().currentHealth<=0 ){

       
       
       if(flag==1){
        
        dragon.SetActive(false);
        dragon2.SetActive(false);
        enemy.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        enemy4.SetActive(false);
        
        
        StartCoroutine(DelayAndSwitch());
       }
}



    }



private IEnumerator DelayAndSwitch()
    {
        // Wait for 3 seconds
        // After the delay, set player inactive and videoplayer active
        src.Stop();
        player2.SetActive(false);
        videoplayer.SetActive(true);
        
        cam.SetActive(true);
        yield return new WaitForSeconds(28f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("main 8");
    
    }





}
