using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveController : MonoBehaviour {


    [Header("Player Attributes")]
    public int hp;
    [Range(0, 100)]
    public int hpMax = 100;
    public int exp;
    public int expMax;
    public int level_text = 1;
    

    [Header("Play UI Components")]
    public Text hpText;
    public Image hpBar;
    public CanvasGroup cg;
    public Image expbar;
    public Text level;
    public CanvasGroup DieScene;
    [Space(15)]
    public ParticleSystem upgrade;
    public ParticleSystem killthree;
    public ParticleSystem killfive;
    public ParticleSystem killseven;
    public ParticleSystem killten;



    public float MoveSpeed = 5.0f;
    private Animator move;
    public GameObject UpgradeSelection;
    public GameObject DieButton;
    // PUBLIC
    public SimpleTouchController leftController;
	public SimpleTouchController rightController;
	public Button jumpController;
	public float speedMovements = 16f;
	public float speedContinuousLook = 100f;
	public float speedProgressiveLook = 3000f;
	public float m_shootingForce = 300;
	public bool m_isTrigger;
	public GameObject thing;
	public float fireRate = 0.5F;
	public bool is_attacked = false;
	public float playerHP = 100f;
	public bool Isground;

	// PRIVATE
	private float nextFire = 0.0F;
	private Rigidbody _rigidbody;
	private Vector3 localEulRot;
	private Vector2 prevRightTouchPos;
	private Animator ani;
    private int kill = 0;

	void Awake()
	{
        killten.Stop();
        upgrade.Stop();
        killthree.Stop();
        killfive.Stop();
        killseven.Stop();
        killten.Stop();
        expMax = 100;
		playerHP = 100f;
		_rigidbody = GetComponent<Rigidbody>();
		ani = GetComponent<Animator> ();
        move = GetComponent<Animator>();
        hp = hpMax;
        hpBar.fillAmount = (float)hp / (float)hpMax;
        exp = 0;
        expbar.fillAmount = (float)exp / (float)exp;
        //rightController.TouchEvent += RightController_TouchEvent;
        //rightController.TouchStateEvent += RightController_TouchStateEvent;
    }
	/*
	public bool ContinuousRightController
	{
		set{continuousRightController = value;}
	}

	void RightController_TouchStateEvent (bool touchPresent)
	{
		if(!continuousRightController)
		{
			prevRightTouchPos = Vector2.zero;
		}
	}
*/
	void RightController_TouchEvent()
	{
		if (rightController.GetTouchPosition.x != 0 && rightController.GetTouchPosition.y != 0 && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Debug.Log ("Shooting.");
			Rigidbody rigidbody = thing.GetComponent<Rigidbody> ();
			if (rigidbody ) {
				GameObject go = Instantiate (thing) as GameObject;
				//go.AddComponent<Rigidbody> ();
				if (rightController.GetTouchPosition.x > 0.2f && Mathf.Abs (rightController.GetTouchPosition.y) < 0.3f) {
					transform.eulerAngles = new Vector3(0,90,0);
					go.transform.position = gameObject.transform.position + new Vector3 (3f, 3f, 0);
					go.GetComponent<Rigidbody> ().AddForce (new Vector3 (m_shootingForce, 0, 0));
				} 
				else if (rightController.GetTouchPosition.x < -0.2f && Mathf.Abs (rightController.GetTouchPosition.y) < 0.3f) {
					transform.eulerAngles = new Vector3(0,270,0);
					go.transform.position = gameObject.transform.position + new Vector3 (-3f, 3f, 0);
					go.GetComponent<Rigidbody> ().AddForce (new Vector3 (-m_shootingForce, 0, 0));
				} 
				else if (rightController.GetTouchPosition.y < 0.0f && Mathf.Abs (rightController.GetTouchPosition.x) < 0.3f && rightController.GetTouchPosition.y !=0) {
					transform.eulerAngles = new Vector3(0,180,0);					
					go.transform.position = gameObject.transform.position + new Vector3 (0, 3f, -3f);
					go.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, -m_shootingForce));
				}
				else if (rightController.GetTouchPosition.y > 0.2f && Mathf.Abs (rightController.GetTouchPosition.x) < 0.3f && rightController.GetTouchPosition.y !=0) {
					transform.eulerAngles = new Vector3(0,0,0);
					go.transform.position = gameObject.transform.position + new Vector3 (0, 3f, 3f);
					go.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, m_shootingForce));
				}
				else if (rightController.GetTouchPosition.y > 0f && rightController.GetTouchPosition.x > 0f) {
					transform.eulerAngles = new Vector3(0,45,0);
					go.transform.position = gameObject.transform.position + new Vector3 (2.1f, 3f, 2.1f);
					go.GetComponent<Rigidbody> ().AddForce (new Vector3 (0.7f*m_shootingForce, 0, 0.7f*m_shootingForce));
				}
				else if (rightController.GetTouchPosition.y > 0f && rightController.GetTouchPosition.x < 0f) {
					transform.eulerAngles = new Vector3(0,315,0);
					go.transform.position = gameObject.transform.position + new Vector3 (-2.1f, 3f, 2.1f);
					go.GetComponent<Rigidbody> ().AddForce (new Vector3 (-0.7f*m_shootingForce, 0, 0.7f*m_shootingForce));
				}
				else if (rightController.GetTouchPosition.y < 0f && rightController.GetTouchPosition.x < 0f) {
					transform.eulerAngles = new Vector3(0,225,0);
					go.transform.position = gameObject.transform.position + new Vector3 (-2.1f, 3f, -2.1f);
					go.GetComponent<Rigidbody> ().AddForce (new Vector3 (-0.7f*m_shootingForce, 0, -0.7f*m_shootingForce));
				}
				else if (rightController.GetTouchPosition.y < 0f && rightController.GetTouchPosition.x > 0f) {
					transform.eulerAngles = new Vector3(0,135,0);
					go.transform.position = gameObject.transform.position + new Vector3 (2.1f, 3f, -2.1f);
					go.GetComponent<Rigidbody> ().AddForce (new Vector3 (0.7f*m_shootingForce, 0, -0.7f*m_shootingForce));
				}
				go.GetComponent<Collider> ().isTrigger = m_isTrigger;
				Destroy (go, 2);
			} else {
				Debug.LogError ("Shooting object need to assign Rigidbody component.");
			}
		}
        hpBar.fillAmount = (float)hp / (float)hpMax;
    }

	void Update()
	{
		// move
		_rigidbody.MovePosition(transform.position + ((new Vector3(0,0,1) * leftController.GetTouchPosition.y * Time.deltaTime * speedMovements) +
			(new Vector3(1,0,0) * leftController.GetTouchPosition.x * Time.deltaTime * speedMovements)));
		//jump
		if (jumpController.GetComponent<JumpMove>().buttom() && Isground == true) {
			//_rigidbody.MovePosition (transform.position + new Vector3(0,2,0));
			_rigidbody.AddForce(new Vector3(0,220,0));
			jumpController.GetComponent<JumpMove>().Resetbuttom();
		}
	//	Debug.Log("Y：" + leftController.GetTouchPosition.y);
	//	Debug.Log("X: " + leftController.GetTouchPosition.x);
		if (transform.position != (transform.position + (new Vector3(0,0,1) * leftController.GetTouchPosition.y * Time.deltaTime * speedMovements) + 
			(new Vector3(1,0,0) * leftController.GetTouchPosition.x * Time.deltaTime * speedMovements))) {
            //print("喻恆笨蛋");
            ani.SetFloat("MoveSpeed", 5.0f);
		}
		else ani.SetFloat("MoveSpeed", 0f);

        RightController_TouchEvent ();
        expbar.fillAmount = (float)exp / (float)expMax;
        //Debug.Log (playerHP);
        /*if(continuousRightController)
		{
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - rightController.GetTouchPosition.y * Time.deltaTime * speedContinuousLook,
				transform.localEulerAngles.y + rightController.GetTouchPosition.x * Time.deltaTime * speedContinuousLook,
				0f);
		}*/
        level.text = level_text+"";
    }

    void upgradeEffect()
    {
        upgrade.Play();
    }
    void KillTenEffect()
    {
        killten.Play();
        killseven.Stop();
    }

    void KillThreeEffect()
    {
        killthree.Play();
    }

    void KillFiveEffect()
    {
        killfive.Play();
        killthree.Stop();
    }

    void KillSevenEffect()
    {
        killseven.Play();
        killfive.Stop();
    }

    void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "enemy") 
		{
			is_attacked = true;
			playerHP -= 5f;
		}
		if (col.collider.tag == "ground") 
		{
			Isground = true;
		}
	}

	void OnCollisionStay(Collision col)
	{
		if (col.collider.tag == "ground") 
		{
			//Debug.Log("gg");
			Isground = true;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "enemy") 
		{
			is_attacked = false;
		}
		if (col.collider.tag == "ground") 
		{
			Isground = false;
		}
	}
     void OnTriggerEnter(Collider col)
    {

        if (col.tag == "AtkSphereEnemy")
        {
            if (hp > 0)
            {
                move.SetTrigger("hit");
                hp = Mathf.Clamp(hp - 30, 0, hpMax);
                iTweenEvent.GetEvent(cg.gameObject, "BloodIn").Play();
                if (hp <= 0)
                {
                    move.SetBool("die", true);
                    this.enabled = false;
                    iTweenEvent.GetEvent(DieScene.gameObject, "DieScene").Play();
                    DieButton.GetComponent<DieButton>().Appear();
                }
            }
            hpBar.fillAmount = (float)hp / (float)hpMax;
        }
        else if (col.tag == "AtkSphereFootMan")
        {
            if (hp > 0)
            {
                move.SetTrigger("hit");
                hp = Mathf.Clamp(hp - 10, 0, hpMax);
                iTweenEvent.GetEvent(cg.gameObject, "BloodIn").Play();
                if (hp <= 0)
                {
                    move.SetBool("die", true);
                    this.enabled = false;
                    iTweenEvent.GetEvent(DieScene.gameObject, "DieScene").Play();
                    DieButton.GetComponent<DieButton>().Appear();
                }
            }
            hpBar.fillAmount = (float)hp / (float)hpMax;
        }
        else if (col.tag == "AtkSphereLich")
        {
            if (hp > 0)
            {
                move.SetTrigger("hit");
                hp = Mathf.Clamp(hp - 20, 0, hpMax);
                iTweenEvent.GetEvent(cg.gameObject, "BloodIn").Play();
                if (hp <= 0)
                {
                    move.SetBool("die", true);
                    this.enabled = false;
                    iTweenEvent.GetEvent(DieScene.gameObject, "DieScene").Play();
                    DieButton.GetComponent<DieButton>().Appear();
                }
            }
            hpBar.fillAmount = (float)hp / (float)hpMax;
        }
        else if (col.tag=="AtkSphereHunter") {
            if (hp > 0)
            {
                move.SetTrigger("hit");
                hp = Mathf.Clamp(hp - 20, 0, hpMax);
                iTweenEvent.GetEvent(cg.gameObject, "BloodIn").Play();
                if (hp <= 0)
                {
                    move.SetBool("die", true);
                    this.enabled = false;
                    iTweenEvent.GetEvent(DieScene.gameObject, "DieScene").Play();
                    DieButton.GetComponent<DieButton>().Appear();

                }
            }
            hpBar.fillAmount = (float)hp / (float)hpMax;
        }
        else if (col.tag == "heart")
        {
            print("補");
            hp = Mathf.Clamp(hp + 20, 0, hpMax);
            hpBar.fillAmount = (float)hp / (float)hpMax;
        }
        else if (col.tag == "exp")
        {
            print("吃吃吃");
            exp += 40;
            
            if (exp >= expMax)
            {
                upgradeEffect();
                level_text += 1;
                exp = 0;
                expMax += 50;
                print(expMax);
                UpgradeSelection.GetComponent<selection>().Appear();
            }
            expbar.fillAmount = (float)exp / (float)expMax;

        }
    }

    public void killCount()
    {
        kill+=1;
        print("kill:"+kill);
        if (kill >= 10)
        {
            KillTenEffect();
        }
        else if (kill >= 7)
        {
            KillSevenEffect();
        }
        else if (kill >= 5)
        {
            KillFiveEffect();
        }
        else if (kill >= 3)
        {
            KillThreeEffect();
        }
        
        
        
    }
}
