using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mycube : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 3f;
    bool isJumping;
    float horizon;
    float vertical;

    Rigidbody rigdbody;
    Vector3 movement;
    void Awake()
    {
        rigdbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        horizon = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
            isJumping = true;
    }
    void FixedUpdate()
    {
        Run();
        Jump();
    }
    void Run()
    {
        movement.Set(horizon, 0, vertical);
        movement = movement.normalized * speed * Time.deltaTime;

        rigdbody.MovePosition(transform.position + movement);
    }
    void Jump()
    {
        if (!isJumping)
            return;
        //rigdbody.MovePosition(transform.position + Vector3.up);
        rigdbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isJumping = false;
    }

}
