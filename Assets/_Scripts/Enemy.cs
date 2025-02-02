using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    public void TakeDamage()
    {
        health--;
        if (health <= 0 )
        {
            Destroy(gameObject);
        }
    }
    
    void OnParticleCollision(GameObject other )
    {
        if (other.CompareTag("Bullets")) {
            TakeDamage();
        }
    }
}
