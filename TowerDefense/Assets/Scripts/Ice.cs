using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour
{
    public float lifeTime;
    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time;
    }

    void Update()
    {
        if (Time.time - spawnTime > lifeTime)
        {
            transform.parent.GetComponent<Enemy>().slowDown = false;
            transform.parent.GetComponent<UnityEngine.AI.NavMeshAgent>().speed *= (1f / .4f);
            Destroy(gameObject);
        }

        transform.LookAt(GameManager.singleton.MainCam.transform);
    }
}