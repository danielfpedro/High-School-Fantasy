using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    [Header("Ground Movement")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    private Vector3 groundVelocity;
    float desiredMoveMultiplier;

    [Header("Turn")]
    public float turnSpeed = 5.0f;
    [SerializeField] float m_MovingTurnSpeed = 360;
    [SerializeField] float m_StationaryTurnSpeed = 180;

    [Header("Ground check")]
    Vector3 m_GroundNormal;
    public float m_GroundCheckDistance = 0.2f;
    
    // Controle
    private bool m_IsGrounded;
    float m_TurnAmount;
    float m_ForwardAmount;
    private Vector3 m_Move;

    // Components
    private Animator animator;
    private Rigidbody rb;

    // Sidewalk
    public LayerMask sidewalkSensor;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        SidewalkControl();
    }

    public void SidewalkControl()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, fwd * .5f, Color.red);

        if (Physics.Raycast(transform.position, fwd, .5f, sidewalkSensor))
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, .05f);
        }
    }

    /**
    public void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        movementStickAngle = Mathf.Atan2(h, v) * (180 / Mathf.PI);

        desiredTurn = Quaternion.Euler(0, movementStickAngle, 0);

        if (h != 0f || v != 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredTurn, Time.deltaTime * turnSpeed);
        }
    }**/

    public void Move(Vector3 move, bool run = false)
    {
        /**Vector3 newVelocity = rb.velocity;

        float desiredSpeed = walkSpeed;

        if (running)
        {
            desiredSpeed = runSpeed;
        }

        newVelocity.Set(desiredSpeed * h, newVelocity.y, desiredSpeed * v);
        **/


        // move = transform.InverseTransformDirection(move);

        if (move.magnitude > 1f) move.Normalize();
        CheckGroundStatus();
        m_Move = Vector3.ProjectOnPlane(move, m_GroundNormal);

        // m_Move = move;
        // rb.velocity = m_Move;

        m_TurnAmount = Mathf.Atan2(move.x, move.z);
        m_ForwardAmount = move.z;
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
        // transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);

        desiredMoveMultiplier = (run) ? runSpeed : walkSpeed;

        groundVelocity = Vector3.Lerp(groundVelocity, m_Move * desiredMoveMultiplier * 100f * Time.deltaTime, .1f);

        // we preserve the existing y part of the current velocity.
        groundVelocity.y = rb.velocity.y;
        rb.velocity = groundVelocity;

        if (m_Move != Vector3.zero)
        {
            //Vector3 _direction = (move - transform.position).normalized;
            Vector3 _direction = (m_Move).normalized;

            //create the rotation we need to be in to look at the target
            Quaternion _lookRotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * this.turnSpeed);
        }
        // Turn();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
        animator.SetBool("OnGround", m_IsGrounded);
        animator.SetFloat("MovingSpeed", groundVelocity.magnitude);

        animator.speed = 1f;
    }

    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
        {
            m_GroundNormal = hitInfo.normal;
            m_IsGrounded = true;
        }
        else
        {
            m_IsGrounded = false;
            m_GroundNormal = Vector3.up;
        }
    }

}
