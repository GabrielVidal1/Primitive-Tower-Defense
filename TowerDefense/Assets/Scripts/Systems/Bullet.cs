using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    void Start()
    {
        Destroy(gameObject, GameManager.singleton.bulletLifeTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Entity"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<LifeSystem>().TakeDamage(damage);
        }
    }
}