using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour {

    [Header("Player Attributes")]
    public int hp;
    [Range(0, 100)]
    public int hpMax = 100;

    [Header("Play UI Components")]
    public Text hpText;
    public Image hpBar;
    public CanvasGroup cg;

    [Space(15)]

    public float MoveSpeed = 5.0f;
    private Animator move;

    // Use this for initialization
    void Start () {
        move = GetComponent<Animator>();
        hp = hpMax;
        hpBar.fillAmount = (float)hp / (float)hpMax;
	}
	
	// Update is called once per frame
	void Update () {

        

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
            
            move.SetFloat("MoveSpeed", 5.0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * MoveSpeed);
            move.SetFloat("MoveSpeed", 5.0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
            move.SetFloat("MoveSpeed", 5.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
            move.SetFloat("MoveSpeed", 5.0f);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed);
            move.SetFloat("MoveSpeed", 10.0f);
        }
        else
        {
            move.SetFloat("MoveSpeed", 0f);
        }
        hpBar.fillAmount = (float)hp / (float)hpMax;
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.tag == "AtkSphereEnemy")
        {
            if (hp > 0)
            {
                move.SetTrigger("hit");
                hp = Mathf.Clamp(hp-30,0,hpMax);
                iTweenEvent.GetEvent(cg.gameObject, "BloodIn").Play();
                if (hp <= 0)
                {
                    move.SetBool("die", true);
                    this.enabled=false;
                }
            }
            hpBar.fillAmount = (float)hp / (float)hpMax;
        }
    }
}
