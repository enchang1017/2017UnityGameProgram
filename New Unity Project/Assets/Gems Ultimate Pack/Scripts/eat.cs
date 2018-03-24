using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat : MonoBehaviour {
    //public bool Iseat;
    public GameObject p;
    // Use this for initialization
    void Start () {
		//Iseat = false;
	}
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Player") 
		{
			print ("987987");
			//Iseat = true;
			Destroy (p);
		}
	}
}
