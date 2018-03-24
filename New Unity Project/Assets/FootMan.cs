using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootMan : MonoBehaviour {

    public int hp;
    [Range(0, 100)]
    public int Maxhp = 100;

    public Text hpText;
    public Slider hpSlider;
    public ParticleSystem bloodEFX;
    public GameObject Player;

    private Collider atkSphereEnemy;
    private Animator anim;
    // Use this for initialization


    void Awake () {
        hp = Maxhp;
        anim = GetComponent<Animator>();
        atkSphereEnemy = GetComponentInChildren<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        hp = Mathf.Clamp(hp, 0, 100);
        hpText.text = hp + "/" + Maxhp;

        hpSlider.value = hp;

        if (hp <= 0)
        {
            DieStart();
        }
    }

    public void PlayBloodEFX()
    {
        bloodEFX.Play();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "AtkSphere")
        {
            print("我被打拉");
            anim.SetTrigger("GetHit");
            PlayBloodEFX();
            hp = hp - 40;
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    void DieStart()
    {
        anim.SetTrigger("Die");
    }

    public void AtkSphereEnemyOpen()
    {
        //print("hit");
        atkSphereEnemy.enabled = true;
    }
    public void AtkSphereEnemyEnd()
    {
        //print("hit");
        atkSphereEnemy.enabled = false;
    }

    public void dieover()
    {
        Player.GetComponent<PlayerMoveController>().killCount();
        Die();
    }
}
