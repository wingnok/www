using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{
    public float healAmount = 10;
    private bool cooldownheal = false;
    public float coolDown;

    public Image healthBar;

    public static Gamecontroller instance;
    
    private static float health = 100;
    private static float maxHealth = 100;
    private static float moveSpeed = 7f;


    public static float Health { get => health; set => health = value; }
    public static float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private static Text healthText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        healthText = GameObject.Find("HealthText").GetComponent<Text>();
    }


     void Update()
    {
        healthText.text = ("100/ "+health);

        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        
    }

  




    public static void DamagePlayer(float damage)
    {
        health -= damage;
        if(Health <= 0)
        {
            KillPlayer();
        }
    }

    public void HealPlayer()
    {
        if (!cooldownheal)
        {
            health = Mathf.Min(maxHealth, health + 10);
            StartCoroutine(CoolDown());
        }
    }

    private IEnumerator CoolDown()
    {
        cooldownheal = true;
        yield return new WaitForSeconds(coolDown);
        cooldownheal = false;
    }




    private static void KillPlayer()
    {

    }
}
