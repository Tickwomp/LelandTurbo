using UnityEngine;
using System.Collections;

public class Enemy_Test1 : MonoBehaviour {
	
	public LT_Character character;
	
	public int horizontalMoveSpeed = 9;
	public int verticalMoveSpeed = 6;
	
	public int jumpSpeed = 20;
	public int jumpsMax = 0;
	
	
	void Awake ()
	{
		character = gameObject.GetComponent<LT_Character>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
