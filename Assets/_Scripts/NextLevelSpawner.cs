using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelSpawner : MonoBehaviour
{
    public GameObject[] levels;

    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasSpawned) 
        {
            Instantiate(levels[Random.Range(0, levels.Length)], transform.position, Quaternion.identity);
            hasSpawned = true;
        }
    }
}
