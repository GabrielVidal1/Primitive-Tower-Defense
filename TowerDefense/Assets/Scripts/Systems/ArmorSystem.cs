﻿using UnityEngine;
using System.Collections;

public class ArmorSystem : MonoBehaviour
{
    public float totalArmor;
    public float ArmorRegenerationPerSecond;

    private Material ArmorBarMaterial;
    private float initialArmor;
    private float unitsPerArmor;
    private float ArmorBarHeight;

    private GameObject ArmorBar;

    void Update()
    {
        if (totalArmor < initialArmor)
        {
            Regeneration();
            UpdateArmorBar();
        }
    }


    void Start()
    {
        initialArmor = totalArmor;

        unitsPerArmor = GameManager.singleton.unitsPerLife;
        ArmorBarMaterial = GameManager.singleton.ArmorBarMaterial;

        LifeSystem life = GetComponent<LifeSystem>();

        ArmorBarHeight = life.lifeBarHeight + .11f;
    }


    public void CreateArmorBar()
    {
        print("CreateBarEXECUTé pour le gameobject " + name);
        ArmorBar = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ArmorBar.transform.localScale = new Vector3(totalArmor * unitsPerArmor, .1f, .1f);
        ArmorBar.transform.position = new Vector3(transform.position.x, transform.position.y + ArmorBarHeight + 0.11f,
            transform.position.z);
        ArmorBar.GetComponent<Renderer>().material = ArmorBarMaterial;
        ArmorBar.transform.SetParent(gameObject.transform);
        ArmorBar.name = "ArmorBar";
        ArmorBar.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        Destroy(ArmorBar.GetComponent<BoxCollider>());
    }


    public void UpdateArmorBar()
    {
        ArmorBar.transform.localScale = new Vector3(totalArmor * unitsPerArmor, .1f, .1f);
        ArmorBar.transform.LookAt(GameManager.singleton.MainCam.transform);
    }

    void Regeneration()
    {
        totalArmor += ArmorRegenerationPerSecond * Time.deltaTime;
        if (totalArmor > initialArmor)
            totalArmor = initialArmor;
    }

    public void Respawn()
    {
        totalArmor = initialArmor;
    }
}