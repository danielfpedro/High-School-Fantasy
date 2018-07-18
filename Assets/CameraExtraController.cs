using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExtraController : MonoBehaviour {

    public float rotationSpeed = 1f;

    public float TargetAngleX;
    public float TargetAngleY;

    public Transform target;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        

        // Make limits on vertical rotation
        TargetAngleY = Mathf.Clamp(TargetAngleY, -90, 90);

        // transform.eulerAngles = new Vector3(0, TargetAngleY, 0);

        if (Input.GetAxis("Right Horizontal") != 0)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Right Horizontal") * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetButton("Submit"))
        {
            //Vector3 newDir = Vector3.RotateTowards(transform.forward, target.forward, rotationSpeed, 0.0f);

            // Move our position a step closer to the target.
            //transform.rotation = Quaternion.LookRotation(newDir);
        }
        /**
        Quaternion pim = transform.rotation;
        pim.y += Mathf.Lerp(pim.y, Input.GetAxis("Right Horizontal") * Time.deltaTime, rotationSmooth);
        transform.rotation = pim;**/
    }
}
