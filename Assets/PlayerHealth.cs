using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public float maxHealth = 10;
   private float health = 10;
   private bool canRecieveDamage = true;
   public float invincilityTimer = 2;

    public delegate void HealthChangedHandler(float newHealth, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        if (canRecieveDamage)
        {
            health -= damage;
            OnHealthChanged?.Invoke(health, -damage);
            canRecieveDamage = false;
            StartCoroutine(InvicibilityTimer(invincilityTimer, ResetInvincibility));    
        }
        
        Debug.Log(health);

    }

     IEnumerator InvicibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        canRecieveDamage = true;
        Debug.Log("reset");
    }
    public void AddHealth(float healthToAdd) 
    {
        health += healthToAdd;
        OnHealthChanged?.Invoke(health, healthToAdd);
        Debug.Log(health);
    }
}
