using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	public Transform playerposition;
	private Vector3 Offset;
	// Use this for initialization
	void Start () {
		Offset = transform.position - playerposition.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Offset + playerposition.position ;
	}
}
