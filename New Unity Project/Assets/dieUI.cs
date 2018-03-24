using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dieUI : MonoBehaviour
{

    public CanvasGroup cg;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DieScene(float value)
    {
        cg.alpha = value;
    }

}
