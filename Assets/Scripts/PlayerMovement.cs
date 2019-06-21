using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jumpHeight;

    PlayerManager PM;
    Rigidbody RB;
    Collider coll;
    bool grounded;

    void Start() {
        PM = GetComponent<PlayerManager>();
        RB = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump") && grounded) {
            RB.velocity += Vector3.up * jumpHeight;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, 0f);
        RB.position += move;
        if (move.x > 0) {
            PM.xdir = 1;
        }
        if (move.x < 0) {
            PM.xdir = -1;
        }
    }

    void FixedUpdate() {
        float distToGround = coll.bounds.extents.y;
        grounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        if (transform.position.y < -20) {
            // fallen
            PM.Restart();
        }
    }
}
