using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public string TEAM;
	public float damage;
	public GameObject Shooter;


	private float lifeTime;
	private float spawnTime;

	void Start () 
	{
		GameManager gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
		lifeTime = gM.bulletLifeTime;
		spawnTime = Time.time;
	}

	void Update() 
	{
		if (Time.time - spawnTime > lifeTime)
			Destroy (gameObject);
	}

	void OnTriggerEnter( Collider other )
	{
		if (other.tag == "Entity") 
		{
			if (other.GetComponent<TeamSystem> ().team != TEAM) 
			{
				Destroy (gameObject);
				other.gameObject.GetComponent<LifeSystem> ().TakeDamage (damage);
			}
		}
	}







}
