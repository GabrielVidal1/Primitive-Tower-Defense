using UnityEngine;
using System.Collections;

public class LifeSystem : MonoBehaviour
{
    public float totalLife;
    public float LifeRegenerationPerSecond;

    public float lifeBarHeight;
    public float coinsDroppedOnDeath;
    private float initialLife;

    private float unitsPerLife;
    private Material lifeBarMaterial;
    private GameObject lifeBar;
    private bool hasBeenAttacked;

    private bool hasArmor;
    private ArmorSystem armor;

    void Start()
    {
        armor = GetComponent<ArmorSystem>();
        initialLife = totalLife;
        unitsPerLife = GameManager.singleton.unitsPerLife;
        lifeBarMaterial = GameManager.singleton.lifeBarMaterial;

        if (armor != null)
            hasArmor = true;

        CreateBar();
        if (hasArmor)
        {
            armor.CreateArmorBar();
            armor.UpdateArmorBar();
        }
    }


    void Update()
    {
        if (hasBeenAttacked)
        {
            hasBeenAttacked = false;

            if (hasArmor)
                armor.UpdateArmorBar();

            UpdateLifeBar();
        }

        lifeBar.transform.LookAt(GameManager.singleton.transform);
    }

    void CreateBar()
    {
        lifeBar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        lifeBar.transform.localScale = new Vector3(totalLife * unitsPerLife, .1f, .1f);
        lifeBar.transform.position =
            new Vector3(transform.position.x, transform.position.y + lifeBarHeight, transform.position.z);
        lifeBar.GetComponent<Renderer>().material = lifeBarMaterial;
        lifeBar.transform.SetParent(gameObject.transform);
        lifeBar.name = "LifeBar";
        lifeBar.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        Destroy(lifeBar.GetComponent<BoxCollider>());
    }


    public void UpdateLifeBar()
    {
        lifeBar.transform.localScale = new Vector3(totalLife * unitsPerLife, .1f, .1f);
        lifeBar.transform.LookAt(GameManager.singleton.transform);
        if (hasArmor)
        {
            armor.UpdateArmorBar();
        }
    }


    public void TakeDamage(float damage)
    {
        hasBeenAttacked = true;
        if (hasArmor)
        {
            armor.totalArmor -= damage;
            if (armor.totalArmor < 0f)
            {
                damage = -armor.totalArmor;
                armor.totalArmor = 0f;
            }
            else
            {
                damage = 0f;
            }
        }

        totalLife -= damage;

        if (totalLife < 0f)
            Die();
    }


    void Die()
    {
        Destroy(gameObject);
        GameManager.singleton.money += GetComponent<Enemy>().moneyDropOnDeath;
    }

    public void Regeneration()
    {
        totalLife = initialLife;
    }
}