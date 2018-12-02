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

    private bool canSacrifice = false;

    private GameObject selectedDoor;

    private bool reachedExit = false;


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
        
        if (mCachedPlayer.health <= 0) {
            Destroy(gameObject);
        }
 

        if (Input.GetKeyDown("space")) {
            print("space was pressed");
        }

        if (Input.GetKeyDown("e") && canSacrifice) {
            print("e was pressed");
            performSacrifice(40f);
            Destroy(this.selectedDoor);
        }

        if (Input.GetKeyDown("e") && reachedExit) {
            print("finished the level");
        }

	}

    private void performSacrifice(float sacrificeAmount) {
        mCachedPlayer.ReceiveDamage(sacrificeAmount);
        healthBar.fillAmount = mCachedPlayer.health / 100f;


    }

    private void OnTriggerExit2D(Collider2D collision) {
        print("leaving collision"); 
        if (collision.gameObject.tag == "door") {
            canSacrifice = false;
            selectedDoor = null;
        }
        else if (collision.gameObject.tag == "exit") {
            reachedExit = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        print("colliding");
        if (collision.gameObject.tag == "door") {
            print("collided with door");
            canSacrifice = true;
            selectedDoor = collision.gameObject;
        }

        if (collision.gameObject.tag == "exit") {
            print("collided with exit");
            reachedExit = true;
        }
    }

    void FixedUpdate() {
        playerRigidBody.MovePosition(playerRigidBody.position + movementVelocity * Time.fixedDeltaTime);
    }
}
