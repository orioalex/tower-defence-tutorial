using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ways : MonoBehaviour
{
    public static Transform[] points;
    public static bool prepared=false;

    void Start()
    {
        //Debug.Log("start");
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
            //Debug.Log(points[i]);
        }
        prepared=true;
        //Instantiate
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
