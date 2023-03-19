using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour

{
    private Animator animator;
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
       slider.value = CalculateHealth();

        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if(health <=0)
        {
            // Destroy(gameObject);
            animator.enabled = false;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
