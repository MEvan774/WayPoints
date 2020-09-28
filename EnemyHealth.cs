using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthParent
{

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 30;
        currentHealth = maxHealth;
        slider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TakeDamage(10);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
