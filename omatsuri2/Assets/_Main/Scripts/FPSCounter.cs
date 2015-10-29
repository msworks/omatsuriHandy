﻿using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour {

    float updateInterval = 0.5f;
 
    private float accum = 0.0f; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft ; // Left time for current interval
    public static string FPS;
 
    void Start()
    {
        timeleft = updateInterval;  
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale/Time.deltaTime;
        ++frames;
 
        // Interval ended - update GUI text and start new interval
        if( timeleft <= 0.0 )
        {
            // display two fractional digits (f2 format)
            FPS = "" + (accum / frames).ToString("f2");
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }
}
