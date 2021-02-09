using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    public bool isBuildMenuVisible;
    public GameObject buildMenuCanvas;

    public bool isHTPMenuVisible;
    public GameObject HTPMenu;

    public bool isCreditsVisible;
    public GameObject Credits;

    public GameObject mainMenu;
    public GameObject mainEnemySpawn;

    public GameObject mainLevel;

    public GameObject demoLevel;
    public Texture demoLevelImage;

    public GameObject WinMenu;

    public Text ArcheryCostText;
    public Text CanonCostText;
    public Text FireCostText;
    public Text IceCostText;
    public Text LightningCostText;
    public Text PoisonCostText;
    public Text MachinGunCostText;


    public Text money;


    public float towerCost;
    public GameObject actualTurret;
    public GameObject actualTurretVisualisation;


    void Start()
    {
        ArcheryCostText.text = GameManager.singleton.ArcheryTowerCost.ToString();
        CanonCostText.text = GameManager.singleton.CanonTowerCost.ToString();
        FireCostText.text = GameManager.singleton.FireTowerCost.ToString();
        IceCostText.text = GameManager.singleton.IceTowerCost.ToString();
        LightningCostText.text = GameManager.singleton.LightningTowerCost.ToString();
        PoisonCostText.text = GameManager.singleton.PoisonTowerCost.ToString();
        MachinGunCostText.text = GameManager.singleton.MachinGunTowerCost.ToString();

        SelectArcheryTower();
    }

    void Update()
    {
        money.text = GameManager.singleton.money.ToString();
    }


    public void ToggleBuildMenu()
    {
        if (isBuildMenuVisible)
        {
            buildMenuCanvas.SetActive(false);
            isBuildMenuVisible = false;
        }
        else
        {
            buildMenuCanvas.SetActive(true);
            isBuildMenuVisible = true;
        }
    }

    public void SelectArcheryTower()
    {
        actualTurret = GameManager.singleton.ArcheryTowerPrefab;
        actualTurretVisualisation = GameManager.singleton.ArcheryTowerPrefabVisualisation;
        towerCost = GameManager.singleton.ArcheryTowerCost;
    }

    public void SelectCanonTower()
    {
        actualTurret = GameManager.singleton.CanonTowerPrefab;
        actualTurretVisualisation = GameManager.singleton.CanonTowerPrefabVisualisation;
        towerCost = GameManager.singleton.CanonTowerCost;
    }

    public void SelectFireTower()
    {
        actualTurret = GameManager.singleton.FireTowerPrefab;
        actualTurretVisualisation = GameManager.singleton.FireTowerPrefabVisualisation;
        towerCost = GameManager.singleton.FireTowerCost;
    }

    public void SelectIceTower()
    {
        actualTurret = GameManager.singleton.IceTowerPrefab;
        actualTurretVisualisation = GameManager.singleton.IceTowerPrefabVisualisation;
        towerCost = GameManager.singleton.IceTowerCost;
    }

    public void SelectLightningTower()
    {
        actualTurret = GameManager.singleton.LightningTowerPrefab;
        actualTurretVisualisation = GameManager.singleton.LightningTowerPrefabVisualisation;
        towerCost = GameManager.singleton.LightningTowerCost;
    }

    public void SelectPoisonTower()
    {
        actualTurret = GameManager.singleton.PoisonTowerPrefab;
        actualTurretVisualisation = GameManager.singleton.PoisonTowerPrefabVisualisation;
        towerCost = GameManager.singleton.PoisonTowerCost;
    }

    public void SelectMachinGunTower()
    {
        actualTurret = GameManager.singleton.MachinGunTowerPrefab;
        actualTurretVisualisation = GameManager.singleton.MachinGunTowerPrefabVisualisation;
        towerCost = GameManager.singleton.MachinGunTowerCost;
    }


    public void SelectDestroyTower()
    {
        actualTurret = null;
        actualTurretVisualisation = GameManager.singleton.DestroyTowerVisualisation;
    }


    public void StartLevel()
    {
        mainMenu.SetActive(false);
        GameManager.singleton.money = 200;

        mainLevel.SetActive(true);

        Destroy(demoLevel);
        AudioListener.volume = 1f;
        mainEnemySpawn.GetComponent<EnemySpawn>().canSpawn = true;
    }

    public void ToggleHowToPlayMenu()
    {
        isHTPMenuVisible = !isHTPMenuVisible;
        HTPMenu.SetActive(isHTPMenuVisible);
    }

    public void ToggleCredits()
    {
        isCreditsVisible = !isCreditsVisible;
        Credits.SetActive(isCreditsVisible);
    }

    public void ToggleWinMenu()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}