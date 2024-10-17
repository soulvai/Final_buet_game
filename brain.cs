using UnityEngine;
using StarterAssets; // Import the StarterAssets namespace
using UnityEngine.InputSystem;

public class MainScript : MonoBehaviour
{    private PlayerInput _playerInput;
    public StarterAssetsInputs _input;  // Reference to the input system
    public GameObject gameObject1;
    public GameObject gameObject2;
    private void Awake()
    {
        // Get the StarterAssetsInputs component from the GameObject
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        // Check if the Ctrl key (the action you set up) is pressed
        Debug.Log(_input.ischange);
        if (_input.ischange)  // Assuming the Ctrl key is mapped to sprint in StarterAssets
        {
            Debug.Log("00000000");

        if(_input.isAiming){
            gameObject2.SetActive(false);

            gameObject1.SetActive(true);
            Debug.Log("1111111111");
            


        }
        
        else if(_input.isShooting){
            gameObject1.SetActive(false);

            gameObject2.SetActive(true);
            Debug.Log("2222222222");
            
            


        }
        
        
        }
    
    
    }
}