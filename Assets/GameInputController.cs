using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Select") && !GameController.instance.timeChanger.activeSelf)
        {
            GameController.instance.timeChanger.SetActive(true);
            Debug.Log("Openning Time Changer");
        }
        if (Input.GetButtonDown("Pause"))
        {
            GameController.instance.TogglePause();
            Debug.Log("The game has been paused");
        }

        if (Input.GetButtonDown("Select"))
        {
            GameController.instance.timeChanger.SetActive(!GameController.instance.isPaused);
            GameController.instance.TogglePause();
        }
    }
}
