using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Health : MonoBehaviour
{
    public int maxHealth;

    public int currentHealth;

    public GameObject healthBarObject;

    public Animator anim;

    //Enemy_Health_Bar healthBar;
    Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        slider = healthBarObject.GetComponent<Slider>();
        //healthBar = healthBarObject.GetComponent<Enemy_Health_Bar>();
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("Death", true);
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "Player_Sword":
                loseHealth(15);
                Debug.Log("Collided");
                break;
        }

        switch (other.tag)
        {
            case "Good_Ball":
                anim.SetTrigger("Hit");
                Debug.Log("Collided");
                break;
        }
    }

    public void loseHealth(int damage)
    {
        currentHealth -= damage;

        SetHealth(currentHealth);
    }
}
