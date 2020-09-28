using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthParent : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Slider slider;

    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        //healthBar.SetHealth(currentHealth);
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;
        //healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
            Destroy(this.gameObject);
    }
}
