using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private LayerMask enemyMask;

    [SerializeField] private Camera _camera;

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    [SerializeField] private GameObject bulletHole;

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
        if(Input.GetMouseButton(0)) RangedAttack();
    }

    public override void RangedAttack()
    {
        //some code that checks and updates the requirements for making a ranged attack.
        if (Time.time < lastAttack + .5f) return;
        Debug.Log("Player shot at : " + Time.time);
        lastAttack = Time.time;
        
        //Raycast to get a potential hit.
        Ray ray = new Ray(_camera.transform.position,_camera.transform.forward); 
        RaycastHit hit;
        
        rays.Add(ray);

        Physics.Raycast(ray, out hit, 1000f);
        
        if(hit.collider == null) return;
        Character character = hit.collider.gameObject.GetComponent<Character>();
        if (character == null)
        {
            GameObject hole = Instantiate(bulletHole,hit.point+new Vector3(hit.normal.x*.02f,hit.normal.y*.02f,hit.normal.z*.02f),Quaternion.LookRotation(-hit.normal));
            return;
        }

        //resolve the hit.
        character.TakeDamage(1,this);


    }

    private List<Ray> rays = new List<Ray>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Ray ray in rays)
        {
            Gizmos.DrawRay(ray);
        }
    }
}