using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int health = 3;

    public Sprite fullHeart;
    public Sprite emptyHeart;
    public UnityEngine.UI.Image[] hearts;

    public float invincibility = 0;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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

    // Update is called once per frame
    void Update()
    {
        if (invincibility > 0)
        {
            invincibility -= Time.deltaTime;
        }
        else if (invincibility < 0)
        {
            invincibility = 0;
        }

        if (rb.velocity.y < -20)
        {
            rb.velocity = new Vector2(rb.velocity.x, -20);
        }
    }

    public void TakeDamage()
    {
        if (invincibility == 0)
        {
            health--;
            invincibility = 1;
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            } else
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
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           TakeDamage();
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            TakeDamage();
        }
    }

}
