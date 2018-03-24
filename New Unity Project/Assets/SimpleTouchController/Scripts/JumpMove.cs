using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMove : MonoBehaviour {

	bool Ispushed = false;

	void Update()
	{
		
	}

	public void Click()
	{
		Debug.Log ("888");
		Ispushed = true;
	}

	public bool buttom ()
	{
		return Ispushed;
	}

	public void Resetbuttom()
	{
		Ispushed = false;
	}
		
}
