using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    private bool isDead;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player health: " + health);
        Healthbar.Instance.UpdateHealthBarValue(health);

        if(health <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            GameManager.instance.GameOver();
            Debug.Log("Dead");
        }

    }
}