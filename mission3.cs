using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System;
using UnityEngine.UIElements;
using Unity.Mathematics;
using UnityEngine.Video;



public class mission3 : MonoBehaviour
{
     Transform player;
     public AudioSource src;
     public AudioSource src2;
     
     public AudioClip sfx1,sfx2,sfx3,sfx4,sfx5,sfx6;



    Transform player2;
     public GameObject archer;
     public GameObject archer2;
     public GameObject wizard;
   public Transform destination;
   public Transform destination2;
   
    bool task1=false;
    bool task2=false;
float dis;
float dis2;
public VideoPlayer videoPlayer2;    
        public TMP_Text countdownText; // Assign your Text component in the Inspector
    public GameObject restartMessage; // Assign your Text/Image GameObject in the Inspector
    public GameObject cam;

    float timer;
    public float dis3;
    public float dis4;
    // Start is called before the first frame update
    public float flag=0;
    void Start()
    {   
        archer.SetActive(false);
        wizard.SetActive(false);
        cam.SetActive(true);
       
    videoPlayer2.Play();
        
      videoPlayer2.loopPointReached += OnVideoEnd;
        
    }

    // Update is called once per frame
    
    void OnVideoEnd(VideoPlayer vp)
    {
        wizard.SetActive(true);
        
        archer.SetActive(true);
        cam.SetActive(false);
           src.clip=sfx1;
           src2.clip=sfx6;
           src2.loop=true;
           src2.Play();
           src2.volume=.5f;

           src.Play();
                player=GameObject.FindGameObjectWithTag("hero").transform;
        player2=GameObject.FindGameObjectWithTag("hero2").transform;

        // Enable the gameplay elements after the video ends
        
        
        // Optionally, hide or disable the video object
        videoPlayer2.gameObject.SetActive(false);
    }

    
    
    
    void Update()
    {

// 
// if(timer>2 && timer<4){
 
// }

dis=Vector3.Distance(player.position, destination.position);
dis2=Vector3.Distance(player2.position, destination.position);
 dis3=Vector3.Distance(player.position, destination2.position);
dis4=Vector3.Distance(player2.position, destination2.position);


if(dis<2 && dis2<2){
    task1=true;


}

if(archer2.GetComponent<PlayerHealth>().currentHealth==100){
    task2=true;
}


if (Mathf.Abs(dis - dis2) > 8)
{
    archer.SetActive(false);
    wizard.SetActive(false);
    restartMessage.SetActive(true);
        cam.SetActive(true);
         StartCoroutine(RestartCountdown());
         }
 
if(Mathf.Abs(dis - dis2) > 5 && dis>dis2&& !src.isPlaying) {
    src.Stop();
    src.clip=sfx2;
    src.Play();

}
else if(Mathf.Abs(dis - dis2) > 5 && dis2>dis&& !src.isPlaying){
    src.Stop();
    src.clip=sfx4;
    src.Play();

}

if(task1==true && task2==true){
    src2.Stop();
UnityEngine.SceneManagement.SceneManager.LoadScene("main 5");

} 
if(dis3 < 2 && dis4 < 2 && flag==0)
{
    if (!src.isPlaying) // Check if nothing is currently playing
    {   flag=1;
        src.clip = sfx3;  // Set sfx3
        src.Play();       // Play sfx3
        StartCoroutine(PlayNextClipAfterCurrent(sfx5)); // Start coroutine to play sfx5 after sfx3
    }
}
Debug.Log(task1 + "" + task2);

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
        UnityEngine.SceneManagement.SceneManager.LoadScene("main 4");
    }


private IEnumerator PlayNextClipAfterCurrent(AudioClip nextClip)
{
    // Wait until the current clip (sfx3) finishes
    while (src.isPlaying)
    {
        yield return null;
    }
    
    // Once sfx3 is done, play the next clip (sfx5)
    src.clip = nextClip;
    src.Play();
}




}
