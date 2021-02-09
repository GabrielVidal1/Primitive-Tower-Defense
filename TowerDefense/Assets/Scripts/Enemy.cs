using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public bool isAMinion;

    public int level;

    public GameObject level2Attributes;

    public GameObject level3Attributes;

    public GameObject mageAttributes;

    public GameObject stunnedParticle;

    public float moneyDropOnDeath = 5f;

    public bool mage;

    public bool onFire = false;
    public bool slowDown = false;
    public bool poisonned = false;

    private bool stunned = false;
    public Transform enemyNexus;


    private float fireEventTime;
    public float PoisonEventTime;

    private UnityEngine.AI.NavMeshAgent agent;
    private Transform target;

    private float stunnedTime;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyNexus = GameManager.singleton.Nexus;

        if (level >= 2)
        {
            level2Attributes.SetActive(true);
            GetComponent<LifeSystem>().totalLife = 10;
            GetComponent<LifeSystem>().UpdateLifeBar();
            transform.localScale *= 1.3f;
            agent.speed *= 1.1f;
            moneyDropOnDeath *= 2f;
        }

        if (level >= 3)
        {
            level3Attributes.SetActive(true);
            GetComponent<LifeSystem>().totalLife = 20;
            GetComponent<LifeSystem>().UpdateLifeBar();
            transform.localScale *= 1.3f;
            agent.speed *= 1.2f;
            moneyDropOnDeath *= 2f;
        }


        if (isAMinion)
        {
            GetComponent<LifeSystem>().totalLife /= 1.5f;
            GetComponent<LifeSystem>().UpdateLifeBar();
            transform.localScale *= .5f;
            agent.speed *= 2;
            moneyDropOnDeath *= 1.5f;
        }
        else if (mage)
        {
            moneyDropOnDeath *= 4f / 3f;
            mageAttributes.SetActive(true);
            GetComponent<UnityEngine.AI.NavMeshAgent>().speed *= .8f;
        }
    }

    void Update()
    {
        if (mage)
        {
            poisonned = false;
            onFire = false;
            slowDown = false;
        }


        agent.SetDestination(enemyNexus.position);

        if (Time.time - PoisonEventTime > 3f && poisonned)
        {
            poisonned = false;
        }

        if (Time.time - fireEventTime > 5f && stunned)
        {
            stunned = false;
            agent.speed /= 0.001f;
        }
    }


    public void Stunned()
    {
        GameObject particles = (GameObject) Instantiate(stunnedParticle, transform.position, Quaternion.identity);
        particles.transform.position += Vector3.up;
        particles.transform.SetParent(transform);
        Destroy(particles, 5f);
        stunned = true;
        fireEventTime = Time.time;
        agent.speed *= 0.001f;
    }
}