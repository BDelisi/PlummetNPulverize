using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class PathfindingTracker : MonoBehaviour
{
    public GameObject player;
    public AstarPath thePath;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        thePath = GetComponent<AstarPath>();

    }
    // Update is called once per frame
    void Update()
    {
        //thePath.graphs[0].Scan();
    }
}
