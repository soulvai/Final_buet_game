using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class flamemarbe : MonoBehaviour
    
{
    // Start is called before the first frame update
    Transform mouseWorldPosition;
    Transform mouseWorldPosition2;
    public AudioSource src;
    public AudioClip sfx1;
    public float z;
    
    
    public Transform arrowpoint;
    public GameObject arrow;

    void Start()
    {
          mouseWorldPosition=GameObject.FindGameObjectWithTag("hero").transform;
      mouseWorldPosition2=GameObject.FindGameObjectWithTag("hero2").transform;

      
        
    }
 public void flm(){
            if(Vector3.Distance(mouseWorldPosition.position,arrowpoint.position)<Vector3.Distance(mouseWorldPosition2.position,arrowpoint.position))
            {
            
            Vector3 aimDir = (mouseWorldPosition.position - arrowpoint.position);
            aimDir.y += z;
            aimDir=aimDir.normalized;
            
            src.volume=20f;
            src.Play();
            
            Instantiate(arrow, arrowpoint.position, Quaternion.LookRotation(aimDir, Vector3.up));
        
            }
            else{

            
            Vector3 aimDir = (mouseWorldPosition2.position - arrowpoint.position);
            aimDir.y += z;
            aimDir=aimDir.normalized;
            src.clip=sfx1;
            src.volume=20f;
            src.Play();
            
            Instantiate(arrow, arrowpoint.position, Quaternion.LookRotation(aimDir, Vector3.up));

            
            }
            
            
        
        }



    // Update is called once per frame
    void Update()
    {
        
    }
}
