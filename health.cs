using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Player health variables
    public int maxHealth = 100; // Maximum health
    public int currentHealth;   // Current health
    public healthbar healthbar;

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
        if (currentHealth < 0)
        {
            currentHealth = 0;
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
        healthbar.SetSlider(currentHealth);
        // Optionally, you can check if the player is dead here
        
    
    
    }







}
