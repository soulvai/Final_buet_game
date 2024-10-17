using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlCheck : MonoBehaviour


{

    public GameObject cam1;
    public GameObject locam1;
    public GameObject char1;
    
    public GameObject cam2;
    public GameObject locam2;
    public GameObject char2;
     private PlayerInput char1Input;
    private PlayerInput char2Input;

    
    
void Start()
    {
        // Get the PlayerInput components from char1 and char2 at the start
        char1Input = char1.GetComponent<PlayerInput>();
        char2Input = char2.GetComponent<PlayerInput>();
    }
    
    
    void Update()
    {
        // Check if the Ctrl key is held down
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            // Check if the right mouse button is pressed
            if (Input.GetMouseButtonDown(2)) // 1 is for the right mouse button
            {
                
                cam1.SetActive(true);
                locam1.SetActive(true);
                // char1.SetActive(true);
                char1Input.enabled = true;
                // Set control scheme to "Keyboard&Mouse" for char1
                char1Input.SwitchCurrentControlScheme("KeyboardMouse", Keyboard.current, Mouse.current);

                cam2.SetActive(false);
                locam2.SetActive(false);
                // char2.SetActive(false);
                 char2Input.enabled = false;

         }
        
        
        
            else if (Input.GetMouseButtonDown(0)) // 1 is for the right mouse button
            {
                
                cam2.SetActive(true);
                locam2.SetActive(true);
                // char2.SetActive(true);
                 char2Input.enabled = true;
                // Set control scheme to "Keyboard&Mouse" for char2
                char2Input.SwitchCurrentControlScheme("KeyboardMouse", Keyboard.current,Mouse.current);

                
                cam1.SetActive(false);
                locam1.SetActive(false);
                // char1.SetActive(false);
                char1Input.enabled = false;
            
            
            }
        
        
        
        
        }
    
      
    
    
    }
}
