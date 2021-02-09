using UnityEngine;
using System.Collections;

public class ZoneTurret : MonoBehaviour {

	public string team;
	public GameObject particleAnimation;

	public float slowDownEnemy;

	public float radius;
	public float damagePerSecond;

	public bool iceTurret;
	public bool FireTurret;
	public bool PoisonTurret;

	void Start ()
	{
		GameManager gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		Collider[] entities = Physics.OverlapSphere(transform.position, radius);

		foreach (Collider entity in entities)
		{
			if (entity.tag == "Entity")
			{

				if (!entity.GetComponent<Enemy> ().mage)
				{



					if (entity.GetComponent<TeamSystem> ().team != team) {

						if (!entity.GetComponent<Enemy> ().onFire && FireTurret) {
							entity.GetComponent<Enemy> ().onFire = true;
							GameObject particle = (GameObject)Instantiate (particleAnimation, entity.transform.position, Quaternion.identity);
							particle.transform.SetParent (entity.transform);
							particle.transform.LookAt (GameObject.FindWithTag ("GameController").GetComponent<GameManager> ().MainCam.transform);
						}


						if (slowDownEnemy > 0 && !entity.GetComponent<Enemy> ().slowDown && iceTurret) {
							entity.GetComponent<UnityEngine.AI.NavMeshAgent> ().speed *= slowDownEnemy;
							entity.GetComponent<Enemy> ().slowDown = true;
							GameObject particle = (GameObject)Instantiate (particleAnimation, entity.transform.position, Quaternion.identity);
							particle.transform.SetParent (entity.transform);
							particle.transform.LookAt (GameObject.FindWithTag ("GameController").GetComponent<GameManager> ().MainCam.transform);
						}

						if (PoisonTurret) {
							entity.GetComponent<LifeSystem> ().TakeDamage (damagePerSecond * Time.deltaTime);

							if (!entity.GetComponent<Enemy> ().poisonned) {
								GameObject particle = (GameObject)Instantiate (particleAnimation, entity.transform.position, Quaternion.identity);
								particle.transform.SetParent (entity.transform);
								Destroy (particle, 3f);
								entity.GetComponent<Enemy> ().poisonned = true;
								entity.GetComponent<Enemy> ().PoisonEventTime = Time.time;
							}
						}
						



						entity.GetComponent<LifeSystem> ().TakeDamage (damagePerSecond * Time.deltaTime);
					}
				}
			}
		}

	
	}
}
