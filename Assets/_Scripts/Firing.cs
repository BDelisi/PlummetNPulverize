using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class Firing : MonoBehaviour
{
    public int ammoLeft = 3;
    public float firerate = .25f;
    public float recoil = 4f;
    public int amount = 5;
    public float spread;
    public KeyCode shoot;
    public GameObject particles;

    private GameObject player;
    private AudioSource shotgunSound;
    private float cd = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shotgunSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        else if (cd < 0)
        {
            cd = 0;
        }

        if (Input.GetKeyDown(shoot) || Input.GetMouseButtonDown(0))
        {
            if (cd == 0 && ammoLeft > 0)
            {
                cd = firerate;
                ammoLeft--;
                player.GetComponent<Rigidbody2D>().velocity += new Vector2(math.cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * -1, math.sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * -2f) * recoil;
                shotgunSound.Play();
                for (int i = 0; i < amount; i++)
                {
                    GameObject temp = Instantiate(particles, transform.position, transform.rotation * quaternion.Euler(0, 0, UnityEngine.Random.Range(spread * -1, spread)));
                }
            }
        }
    }

}
