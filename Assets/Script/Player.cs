using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : Character
{
    [SerializeField] private float jumpHeight = 3f;

    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Camera _camera;

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    private float _xRotation = 0f;

    Vector3 _velocity;
    bool _isGrounded;
    
    void Update()
    {
        Movement();
        MouseControls();
    }

    void Movement()
    {
        _isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }

    void MouseControls()
    {
        if(Input.GetMouseButtonDown(0)) RangedAttack();
    }

    public override void RangedAttack()
    {
        //some code that checks and updates the requirements for making a ranged attack.
        if (Time.time < lastAttack + 10) return;
        Debug.Log("Player shot at : " + Time.time);
        lastAttack = Time.time;
        
        //Raycast to get a potential hit.
        Ray ray = new Ray(); 
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 1000f, 100);
        
        Character character = hit.collider.gameObject.GetComponent<Character>();
        if(character == null) return;

        //resolve the hit.
        character.TakeDamage(1);


    }
}