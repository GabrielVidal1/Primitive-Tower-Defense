using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {

	public float lifeTime;
	private float spawnTime;
	private GameObject MainCam;

	void Start () 
	{
		spawnTime = Time.time;
		MainCam = GameObject.FindWithTag ("GameController").GetComponent<GameManager> ().MainCam;
	}

	void Update () 
	{
		if (Time.time - spawnTime > lifeTime) 
		{
			transform.parent.GetComponent<Enemy> ().slowDown = false;
			transform.parent.GetComponent<NavMeshAgent> ().speed *= (1f/.4f);
			Destroy (gameObject);
		}


		transform.LookAt (MainCam.transform);

	}
}
