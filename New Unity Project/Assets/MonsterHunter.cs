using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHunter : MonoBehaviour {

    public int hp;
    [Range(0, 100)]
    public int Maxhp = 100;

    public Text hpText;
    public Slider hpSlider;
    public ParticleSystem bloodEFX;

    private Animator anim;
    private Collider atkSphereEnemy;

    public GameObject Player;

    // Use this for initialization
    void Awake()
    {
        hp = Maxhp;
        anim = GetComponent<Animator>();
        atkSphereEnemy = GetComponentInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
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
            print("我被打拉111");
            anim.SetTrigger("GetHit");
            PlayBloodEFX();
            hp = hp - 20;
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


    public void AtkStart()
    {
        atkSphereEnemy.enabled = true;
    }
    public void AtkStop()
    {
        atkSphereEnemy.enabled = false;
    }

    public void deleteobject()
    {
        Player.GetComponent<PlayerMoveController>().killCount();
        Die();
    }
}