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

    private float invincibility = 0;

    // Start is called before the first frame update
    void Start()
    {

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
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (invincibility == 0)
            {
                health--;
                invincibility = 1;
                if (health <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }

}
