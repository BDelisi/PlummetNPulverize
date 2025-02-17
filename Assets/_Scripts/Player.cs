using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;

    public Sprite fullHeart;
    public Sprite emptyHeart;
    public UnityEngine.UI.Image[] hearts;

    public float invincibility = 0;

    private Rigidbody2D rb;
    private int health;
    private AudioSource hurt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hurt = GetComponent<AudioSource>();

        health = maxHealth;
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibility > 0)
        {
            invincibility -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (invincibility < 0)
        {
            invincibility = 0;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (rb.velocity.y < -20)
        {
            rb.velocity = new Vector2(rb.velocity.x, -20);
        }
        //Debug.Log(Time.deltaTime);
    }

    public void TakeDamage()
    {
        if (invincibility == 0)
        {
            health--;
            hurt.Play();
            invincibility = .5f;
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            } else
            {
                UpdateHealth();
            }
        }
    }

    private void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealthUp"))
        {
            if (maxHealth > health)
            {
                health++;
                UpdateHealth();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           TakeDamage();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            TakeDamage();
        }
    }

}
