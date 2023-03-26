using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{
    public static Gamecontroller instance;
    
    private static int health = 100;
    private static int maxHealth = 100;
    private static float moveSpeed = 7f;


    public static int Health { get => health; set => health = value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private static Text healthText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Update()
    {
        healthText.text = "Health: " + health; 
    }

    public static void DamagePlayer(int damage)
    {
        health -= damage;
        if(Health <= 0)
        {
            KillPlayer();
        }
    }

    public static void HealPlayer(int healAmount)
    {
        health = Mathf.Min(maxHealth, health + healAmount);
    }

    private static void KillPlayer()
    {

    }
}
