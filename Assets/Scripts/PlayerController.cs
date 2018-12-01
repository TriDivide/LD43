using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {


    public float movementSpeed = 1f;
    private Vector2 movementVelocity;
    private Rigidbody2D playerRigidBody;

	// Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementVelocity = moveInput.normalized * movementSpeed;
        
 

        if (Input.GetKeyDown("space")) {
            print("space was pressed");
        }

        if (Input.GetKeyDown("e")) {
            print("e was pressed");
        }

	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "wall") {
            playerRigidBody.velocity = Vector2.zero;
        }

        print("collision detected");
    }

    void FixedUpdate() {
        playerRigidBody.MovePosition(playerRigidBody.position + movementVelocity * Time.fixedDeltaTime);
    }
}
