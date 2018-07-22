using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixExaustController : MonoBehaviour {

    public float speed;
    private Animator animator;
    public GameObject helix;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetFloat("SpeedMultiplier", Random.Range(0.8f, 1f));

        speed = Random.Range(.2f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
        helix.transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime * speed);
    }
}
