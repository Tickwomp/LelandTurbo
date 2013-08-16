using UnityEngine;
using System.Collections;

public class beatemup : MonoBehaviour {
	
	public int gravityAcceleration;
	public int horizontalMoveSpeed;
	public int verticalMoveSpeed;
	public int jumpSpeed;
	public float rotationSmoothing = 10f;
	
	private Vector3 velocity = Vector3.zero;
	private float dt;
	private CharacterController controller;
	private Vector3 inputMovementVector;
	private short jumpCount = 0;
	private bool facing = true;
	
	private const bool RIGHT = true;
	private const bool LEFT = false;
	private const float rotEpsilon = .1f;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		dt = Time.deltaTime;
		
		inputMovementVector.x = Input.GetAxisRaw("Horizontal") * horizontalMoveSpeed;
		inputMovementVector.z = Input.GetAxisRaw("Vertical") * verticalMoveSpeed;
		
		if (controller.isGrounded && jumpCount != 0)
			jumpCount = 0;
		
		
		UpdateJump(dt);
		UpdateGravity(dt);
		UpdateRotation(dt);
		UpdatePosition(dt);
		if(Debug.isDebugBuild)
			UpdateDebug(dt);
	}
	
	void UpdateRotation(float dt){
		if (inputMovementVector.x > 0 && !facing){
			facing = RIGHT;
		}
		else if (inputMovementVector.x < 0 && facing){
			facing = LEFT;
		}
		
		switch (facing){
		case RIGHT:
			//Debug.Log("rotating to the right");
			if (Mathf.Abs(transform.rotation.x - 1) >= rotEpsilon)
				transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(Vector3.right),Time.smoothDeltaTime*rotationSmoothing);
			break;
		case LEFT:
			//Debug.Log("rotating to the left");
			if (Mathf.Abs(transform.rotation.x + 1) >= rotEpsilon)
				transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(Vector3.left),Time.smoothDeltaTime*rotationSmoothing);
			break;
		}
		
	}
	
	void UpdateJump(float dt){
		//double jump
		if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 1){
			velocity.y = jumpSpeed;
			jumpCount++;
		}
	}
	
	void UpdateGravity(float dt){
		if (!controller.isGrounded){
			velocity.y -= gravityAcceleration * dt;
		}
	}
	
	void UpdatePosition(float dt){
		velocity.x = inputMovementVector.x;
		velocity.z = inputMovementVector.z;
		controller.Move(velocity*dt);
	}
	
	void UpdateDebug(float dt){
		Debug.DrawRay(transform.position,transform.forward*50,Color.green);
	}
}
