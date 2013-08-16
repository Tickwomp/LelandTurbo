using UnityEngine;
using System.Collections;

public class Player_BeatEmUp : MonoBehaviour {
	
	public float speed_horizontal = 10f;
	public float speed_vertical = 10f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
		{
			transform.position += Vector3.right * speed_horizontal;
		}
	}
}