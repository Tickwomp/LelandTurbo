using UnityEngine;
using System.Collections;

public class Player_BeatEmUp : MonoBehaviour {
	
	public LT_Character character;
	
	public int horizontalMoveSpeed = 9;
	public int verticalMoveSpeed = 6;
	
	public int jumpSpeed = 20;
	public int jumpsMax = 2;
	
	void Awake ()
	{
		character = gameObject.GetComponent<LT_Character>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		character.inputMovementVector.x = Input.GetAxisRaw("Horizontal") * horizontalMoveSpeed;
		character.inputMovementVector.z = Input.GetAxisRaw("Vertical") * verticalMoveSpeed;
		
		if (Input.GetKeyDown(KeyCode.Space))
			character.Jump(jumpsMax, jumpSpeed);
		
	}
}