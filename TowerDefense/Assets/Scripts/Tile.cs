using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public Material canBuild;
    public Material cannotBuild;
    public Material idle;


    private GameObject turretPrefab;
    private GameObject turretVisualisationPrefab;


    private GameObject effectZone;

    private MainCanvas canvas;

    private float cost;

    public bool isEmpty;

    private bool canVisualisation = true;

    private int[] wavePatern = new int[1];


    void Start()
    {
        canvas = GameObject.FindWithTag("Canvas").GetComponent<MainCanvas>();
    }


    void Update()
    {
        turretPrefab = canvas.actualTurret;
        turretVisualisationPrefab = canvas.actualTurretVisualisation;
        cost = canvas.towerCost;
    }


    void OnMouseOver()
    {
        if (turretVisualisationPrefab == null) return;

        if (isEmpty)
        {
            GetComponent<Renderer>().material = canBuild;

            if (canVisualisation)
            {
                GameObject turretVisualisation =
                    (GameObject) Instantiate(turretVisualisationPrefab, transform.position, Quaternion.identity);
                turretVisualisation.transform.SetParent(gameObject.transform);
                canVisualisation = false;
            }
        }
        else
        {
            GetComponent<Renderer>().material = cannotBuild;
            if (turretPrefab == null)
            {
                GameObject turretVisualisation =
                    (GameObject) Instantiate(turretVisualisationPrefab, transform.position, Quaternion.identity);
                turretVisualisation.transform.SetParent(gameObject.transform);
                canVisualisation = false;
            }
        }
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = idle;

        foreach (Transform child in transform)
            if (child.CompareTag("Visualisation"))
                Destroy(child.gameObject);

        canVisualisation = true;
    }

    void OnMouseDown()
    {
        if (isEmpty)
        {
            foreach (Transform child in transform)
                if (child.CompareTag("Visualisation"))
                    Destroy(child.gameObject);


            if (GameManager.singleton.money >= cost)
            {
                GameObject turret = (GameObject) Instantiate(turretPrefab, transform.position, Quaternion.identity);
                turret.transform.SetParent(transform);
                isEmpty = false;
                GameManager.singleton.money -= cost;
            }
        }
        else if (turretPrefab == null)
        {
            foreach (Transform child in transform)
                if (child.CompareTag("Turret"))
                    Destroy(child.gameObject);
            isEmpty = true;
        }
    }

    public void BuildTurret()
    {
        GameObject turret = (GameObject) Instantiate(turretPrefab, transform.position, Quaternion.identity);
    }
}