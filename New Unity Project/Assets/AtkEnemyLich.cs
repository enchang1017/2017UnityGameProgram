using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtkEnemyLich : MonoBehaviour
{

    public int hp;
    [Range(0, 120)]
    public int Maxhp = 120;

    public Text hpText;
    public Slider hpSlider;
    public ParticleSystem bloodEFX;
    public ParticleSystem attack;
    public GameObject Player;

    private Collider atkSphereEnemy;
    private Animator anim;
    // Use this for initialization


    void Awake()
    {
        attack.Stop();
        hp = Maxhp;
        anim = GetComponent<Animator>();
        atkSphereEnemy = GetComponentInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = Mathf.Clamp(hp, 0, 120);
        hpText.text = hp + "/" + Maxhp;

        hpSlider.value = hp;

        if (hp <= 0)
        {
            DieStart();
        }
        else
        {
            anim.SetBool("attack",true);
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
        attack.Play();
        atkSphereEnemy.enabled = true;
    }
    public void AtkSphereEnemyEnd()
    {
        //print("hit");
        attack.Stop();
        atkSphereEnemy.enabled = false;
    }

    public void dieover()
    {
        Player.GetComponent<PlayerMoveController>().killCount();
        Die();
    }
}
