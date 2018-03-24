using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieButton : MonoBehaviour
{
    public Button pay;
    public Button getout;
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Appear()
    {
        print("call");
        gameObject.SetActive(true);
    }
}
