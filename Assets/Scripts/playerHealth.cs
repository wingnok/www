using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{
    
    public Image healthBar;
    public int maxHealth;


    public void Health(int health)
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }




}
