using UnityEngine;
using System.Collections;

public class Camera_Player : MonoBehaviour {
	
	public Player_BeatEmUp player;
	
	public float offset_height = 1.5f;
	
	public float offset_depth = 10f;
	
	public float speed = 10f;
	
	void Awake ()
	{
		player = GameObject.Find("Player").GetComponent<Player_BeatEmUp>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.LookAt(player.transform);
		
		transform.position = player.transform.position + new Vector3(0, offset_height, -offset_depth);
	}
}
