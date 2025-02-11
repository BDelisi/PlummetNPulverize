using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class FollowCam : MonoBehaviour
{
    public float speed = 3.0f;
    public float zDistance = 10.0f;
    public float allowableOffset = 3.0f;
    public float yOffset = 0;
    public GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position =  new Vector3(0, player.transform.position.y + yOffset, -1 * zDistance);
    }
    // Update is called once per frame
    void Update()
    {
        if (System.Math.Abs(transform.position.y - (player.transform.position.y + yOffset)) > allowableOffset)
        {
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, player.transform.position.y, -1 * zDistance), speed * Time.deltaTime);
            transform.position = new Vector3(0, player.transform.position.y + yOffset, -1 * zDistance);
        }
    }
}
