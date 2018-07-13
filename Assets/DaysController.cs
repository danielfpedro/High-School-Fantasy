using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DaysController : MonoBehaviour {

    static public float time;
    public TimeSpan currentTime;
    public Light sun;
    public Transform sunTransform;
    public Text timeText;
    public int days;

    public float intensity;
    public Color day = Color.white;
    public Color night = Color.black;

    public int speed;

	// Use this for initialization
	void Start () {
        time = 2 * 3600;
	}
	
	// Update is called once per frame
	void Update () {
        ChangeTime();
	}

    public void ChangeTime()
    {
        time += Time.deltaTime * speed;
        if (time > 86400)
        {
            days++;
            time = 0;
        }
        currentTime = TimeSpan.FromSeconds(time);
        string[] tempTime = currentTime.ToString().Split(":"[0]);

        timeText.text = tempTime[0] + ":" + tempTime[1];
        sunTransform.rotation = Quaternion.Euler(new Vector3((time - 21600)/86400*360, 0f, 0f));
        if (time < 43200)
        {
            intensity = 1 - (43200 - time) / 43200;
        } else
        {
            intensity = 1 - ((43200 - time) / 43200 * -1);
        }

        RenderSettings.ambientSkyColor = Color.Lerp(night, day, intensity * intensity);
        
        sun.intensity = intensity * 2f;
    }

    static public void SetTime(float seconds)
    {
        time = seconds;
    }
}
