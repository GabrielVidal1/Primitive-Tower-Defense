using UnityEngine;
using System.Collections;

public class StunningTower : MonoBehaviour
{
    public float radius;
    public float delay;
    public float damage;

    private float eventTime;


    void Update()
    {
        if (Time.time - eventTime > delay)
        {
            Collider[] entities = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider entity in entities)
            {
                if (entity.CompareTag("Entity"))
                {
                    GameObject enemy = entity.gameObject;

                    enemy.GetComponent<LifeSystem>().TakeDamage(damage);
                    enemy.GetComponent<Enemy>().Stunned();
                    eventTime = Time.time;
                    return;
                }
            }
        }
    }
}