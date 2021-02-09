using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
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
            transform.parent.GetComponent<Enemy>().onFire = false;
            Destroy(gameObject);
        }

        transform.LookAt(GameManager.singleton.MainCam.transform);
    }
}