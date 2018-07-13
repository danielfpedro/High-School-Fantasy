using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeTimeController : MonoBehaviour {

    public Slider slider;
    public Text timeDisplay;
    public TimeSpan currentTime;

    void OnEnable() {
        float timeInHours = DaysController.time / 3.600f;
        currentTime = TimeSpan.FromSeconds(DaysController.time);
        slider.value = currentTime.Hours * 2f;
        if (currentTime.Minutes >= 30)
        {
            slider.value += 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            DaysController.SetTime((float)currentTime.TotalSeconds);
            GameController.instance.TogglePause();
            gameObject.SetActive(false);
        }

        timeDisplay.text = string.Format("{0:D2}:{1:D2}", currentTime.Hours, currentTime.Minutes);
    }

    public void SetCurrentTime()
    {
        currentTime = TimeSpan.FromHours(slider.value * .5f);
    }

    public void Bimbo()
    {
        Debug.Log("HII");
        // slider.value += 1f;
    }
}
