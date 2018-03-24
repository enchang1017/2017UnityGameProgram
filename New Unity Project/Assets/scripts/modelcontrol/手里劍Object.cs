using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 手里劍Object : MonoBehaviour {
    public GameObject p;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Destroy (gameObject, 2);
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy"||col.tag=="ground")
        {
            print("我操你馬");
            Destroy(p);
        }
    }
}
