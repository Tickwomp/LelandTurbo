using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
	
	public Transform target;
	
	private Vector3 newPosition;
	
	void Awake()
	{
		target = GameObject.Find("Player").transform;
	}
	
	void Start(){
		newPosition = new Vector3(0,transform.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		newPosition.x = target.position.x;
		transform.position = newPosition;
	}
}
