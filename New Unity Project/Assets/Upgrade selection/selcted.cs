using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selcted : MonoBehaviour {
	Animator ani;
	public GameObject[] weaponObjects;
	public GameObject upgrade;
	public GameObject Player;
	public GameObject[] other;
	private int w;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChooseOb(){
		if (gameObject.GetComponent<Image> ().sprite.name == "weapon0") {
			print ("w0");
			w = 0;
		}
		else if (gameObject.GetComponent<Image> ().sprite.name == "weapon1") {
			print ("w1");
			w = 1;
		}
		else if (gameObject.GetComponent<Image> ().sprite.name == "weapon2") {
			print ("w2");
			w = 2;
		}
		Player.GetComponent<PlayerMoveController> ().thing = weaponObjects[w];
		Close ();
		other [0].GetComponent<selcted> ().Close ();
		other [1].GetComponent<selcted> ().Close ();
	}

	public void Open() {
		ani.SetBool ("Open",true);
	}

	public void Close() {
		ani.SetBool ("Open",false);
	}
}
