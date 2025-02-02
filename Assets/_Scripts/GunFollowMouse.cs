using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunFollowMouse : MonoBehaviour
{
    public GameObject Player;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - Player.transform.position.y, mousePos.x - Player.transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad; // Offset this by 90 Degrees

        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);

        transform.position = Player.transform.position + transform.rotation * new Vector3(.70f, 0, 0f);
        //Debug.Log(transform.rotation.z);
        if (Math.Abs(transform.rotation.z) > .7f )
        {
            Player.GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().flipY = true;
        } else
        {
            Player.GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}
