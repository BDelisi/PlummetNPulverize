using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float startSpeedMin = 5;
    public float startSpeedMax = 5;
    public float lifespan = 1f;

    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = UnityEngine.Random.Range(startSpeedMin, startSpeedMax) * transform.right;
    }

    private void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Shotgun") && !collision.CompareTag("Background") && !collision.CompareTag("Bullets") && !collision.CompareTag("Player") && !collision.CompareTag("Spawner"))
        {
            Destroy(gameObject);
        }
    }
}
