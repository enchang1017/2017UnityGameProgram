using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{

	public GameObject[] cube1;
	public int MaxAmount = 0;
    private GameObject[] newCube = new GameObject[800];
    public GameObject point1;
	public GameObject point2;
	private int number = 0;
	public int frequency = 1;

	private int totalF, n = 0;
	private int[] cuberange = {0,0,0,1};
    void Start()
    {
		number = 0;
		totalF = frequency;
    }

    void Update ()
	{
		if (Time.time > totalF) {
			//print (number);
			if (n < MaxAmount) {
				int r = cuberange[Random.Range (0, cuberange.Length)];
				newCube [number] = Instantiate (cube1 [r]);
				if (r == 0)
					newCube [number].tag = "exp";
				else if (r == 1)
					newCube [number].tag = "heart";
			
				float z = Random.Range (point1.transform.position.z, point2.transform.position.z);
				float x = Random.Range (point1.transform.position.x, point2.transform.position.x);
				newCube [number].transform.position = new Vector3 (x, point1.transform.position.y, z);  // 位置
				//newCube[i].transform.eulerAngles = new Vector3(-90, -30, 115);
				number++;
				n++;
			}
			totalF += frequency;
			//print ("total" + totalF);
		}
	}
}