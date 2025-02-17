using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;

    private GameObject player;
    private GameObject gameManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        GetComponent<AIDestinationSetter>().target = player.transform;
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0 )
        {
            gameManager.GetComponent<PauseGame>().playDeath();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullets"))
        {
            TakeDamage();
        }
    }
}
