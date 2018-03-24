using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodUI : MonoBehaviour {

    public CanvasGroup cg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BloodIn(float value)
    {
        cg.alpha = value;
    }
    public void BloodOut(float value)
    {
        cg.alpha = value;
    }

    public void BloodInFinsh()
    {
        iTweenEvent.GetEvent(gameObject, "BloodOut").Play();
    }
}
