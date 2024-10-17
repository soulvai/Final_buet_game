using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI; 

public class dragonhealth : MonoBehaviour
{
    public int maxHealth = 200; // Maximum health
    public int currentHealth;   // Current health
    public healthbar healthbar;
    public Animator anim;
  public NavMeshAgent capsuleCollider;   // Reference to NavMeshAgent

    // Reference to the UI Text element to display health
    
    private void Start()
    {
        // Set current health to maximum health at the start
        currentHealth = maxHealth;
        
        // Update the health UI
        healthbar.SetSliderMax(maxHealth);
      
      
      
        // healthbar.SetSlider(50);
        // currentHealth = 50;
        
   
   
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        // Reduce the current health by the damage value
        currentHealth -= damage;
        
        // Make sure health doesn't drop below zero
        if (currentHealth <= 0)
        {     
        
           capsuleCollider.enabled = false;
        currentHealth = 0;
            anim.SetTrigger("die");
         
            
        }
        else{
            anim.SetTrigger("damage");
            

        }
        
        // Update the health UI
        healthbar.SetSlider(currentHealth);
        // Optionally, you can check if the player is dead here
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead");
            // You can call a method here for handling death, like restarting the game or respawning.
        }
    }

    public void Increasehealth(int damage)
    {
        // Reduce the current health by the damage value
        currentHealth += damage;

        // Make sure health doesn't drop below zero
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }

        // Update the health UI
        // healthbar.SetSlider(currentHealth);
        // Optionally, you can check if the player is dead here
    }
}
