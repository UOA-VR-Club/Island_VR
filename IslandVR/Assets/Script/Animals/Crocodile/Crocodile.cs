using UnityEngine;
using System;


public class Crocodile : MonoBehaviour 
{
    public int CrocodileHealthPoints = 100;

    /// <summary>
    /// Called whenever a GameObject with Collision attribute hits crocodile.
    /// </summary>
    /// <param name="other">GameObject with Collision component.</param>
    private void OnCollisionEnter(Collision other)
    {
        // TO PUSH BRANCH TO REMOTE REPOSITORY, DO:
        // git push -u origin <branch-name>
        
        // hurt crocodile health on hit
        CrocodileHealthPoints -= 10;

        if (CrocodileHealthPoints <= 0) 
        {
            Destroy(this); 
        }
    }
}