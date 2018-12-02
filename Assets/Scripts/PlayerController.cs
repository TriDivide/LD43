using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour {


    public float movementSpeed = 1f;
    private Vector2 movementVelocity;
    private Rigidbody2D playerRigidBody;

    public Player mCachedPlayer;

    public Image healthBar;

	// Use this for initialization
	void Start () {
        mCachedPlayer = PlayerModel.Instance.GetPlayer();

        if (mCachedPlayer == null) {
            PlayerModel.Instance.CreatePlayer("Test User", Player.ClassType.Fighter);
            mCachedPlayer = PlayerModel.Instance.GetPlayer();

        }
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
            TestTakeDamage();
        }

	}

    private void TestTakeDamage() {
        mCachedPlayer.ReceiveDamage(20f);
        healthBar.fillAmount = mCachedPlayer.health / 100f;


    }

    private void OnTriggerEnter(Collider other) {
        print("colliding");
        if (other.gameObject.CompareTag("door")) {
            print("colliding with door");
        }
    }

    void FixedUpdate() {
        playerRigidBody.MovePosition(playerRigidBody.position + movementVelocity * Time.fixedDeltaTime);
    }
}
