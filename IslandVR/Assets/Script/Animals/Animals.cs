using UnityEngine;
using System;


public class Animals : MonoBehaviour 
{
    public int AnimalHealthPoints = 100;

    /// <summary>
    /// Called whenever a GameObject with Collision attribute hits an animal.
    /// </summary>
    /// <param name="other">GameObject with Collision component.</param>
    private void OnCollisionEnter(Collision other)
    {        
        // hurt crocodile health on hit
        AnimalHealthPoints -= 10;

        if (AnimalHealthPoints <= 0) 
        {
            Die(); 
        }
    }

    /// <summary>
    /// Called whenever health points go below 0.
    /// </summary>
    private void Die() 
    {
        Destroy(this);
    }
}