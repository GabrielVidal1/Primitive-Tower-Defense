using UnityEngine;
using System.Collections;

public class AimingSystem : MonoBehaviour {

    public GameObject pivot;
    public Transform bulletSpawn;


    public float radius;
    public float bulletSpeed;
    public float bulletDamage;
	public string team;

    public float delayBetweenShots;

    private float lastShotTime = 0f;
    private GameObject bulletPrefab;
    public Transform target;

	void Start ()
    {
        GameManager gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        bulletPrefab = gM.bulletPrefab;

	}
	
	public Transform ClosestEnemy ()
    {
		Collider[] entities = Physics.OverlapSphere(transform.position, radius);
        float minDistance = Mathf.Infinity;
        float distance;
        
		target = null;

        foreach (Collider entity in entities)
        {
            if (entity.tag == "Entity")
            {
                if (entity.GetComponent<TeamSystem>().team != team)
                {
                    distance = Vector3.Distance(transform.position, entity.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
						target = entity.gameObject.transform;
                    }
                }
            }
        }

        if (target == null)
            return null;

		pivot.transform.LookAt( new Vector3(target.position.x, .7f, target.position.z ));
        return target;
    }


    public GameObject SummonBullet()
    {
        if (Time.time - lastShotTime > delayBetweenShots && target != null)
        {

            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            bullet.transform.localScale *= bulletDamage;
			Vector3 dir = new Vector3( target.position.x, .2f, target.position.z ) - bulletSpawn.position;
            bullet.GetComponent<Rigidbody>().AddForce(dir.normalized * bulletSpeed);
            bullet.AddComponent<Bullet>();
            bullet.GetComponent<Bullet>().TEAM = team;
            bullet.GetComponent<Bullet>().damage = bulletDamage;
            bullet.GetComponent<Bullet>().Shooter = gameObject;
            lastShotTime = Time.time;
			GetComponent<AudioSource> ().Play ();
            return bullet;
        }
        else
            return null;
    }
}

