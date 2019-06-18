using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpHeight;

    private Rigidbody RB;
    private Collider coll;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            RB.velocity += Vector3.up * JumpHeight;
        }

        RB.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * Speed, 0f, 0f);
    }

    void FixedUpdate()
    {
        float distToGround = coll.bounds.extents.y;
        grounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
