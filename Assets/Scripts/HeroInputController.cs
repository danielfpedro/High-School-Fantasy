﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputController : MonoBehaviour {

    private HeroController m_Character;
    private float h;
    private float v;

    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

    private void Start()
    {
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
        m_Character = GetComponent<HeroController>(); ;
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        m_Move = v * Vector3.forward + h * Vector3.right;

        
    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        m_Character.Move(m_Move, (Input.GetButton("Run")));
    }
}