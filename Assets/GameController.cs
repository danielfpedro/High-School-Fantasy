using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [Header("HUD")]
    public GameObject timeChanger;

    public bool isPaused = false;

    public static GameController instance = null;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Dont destroy on reloading the scene
        DontDestroyOnLoad(gameObject);


    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoPause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void DoResume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
        } else
        {
            Time.timeScale = 0f;
        }

        isPaused = !isPaused;
    }
}
