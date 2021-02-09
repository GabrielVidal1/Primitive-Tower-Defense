using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour {

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

	private GameManager gM;



	void Start () 
	{
		gM = GameObject.FindWithTag ("GameController").GetComponent<GameManager>();

		ArcheryCostText.text = gM.ArcheryTowerCost.ToString();
		CanonCostText.text = gM.CanonTowerCost.ToString();
		FireCostText.text = gM.FireTowerCost.ToString();
		IceCostText.text = gM.IceTowerCost.ToString();
		LightningCostText.text = gM.LightningTowerCost.ToString();
		PoisonCostText.text = gM.PoisonTowerCost.ToString();
		MachinGunCostText.text = gM.MachinGunTowerCost.ToString ();

		SelectArcheryTower ();

	}

	void Update () 
	{
		money.text = gM.money.ToString ();


	}
		

	public void ToggleBuildMenu()
	{
		if (isBuildMenuVisible) {
			buildMenuCanvas.SetActive (false);
			isBuildMenuVisible = false;
		} else {
			buildMenuCanvas.SetActive (true);
			isBuildMenuVisible = true;
		}
	}

	public void SelectArcheryTower()
	{
		actualTurret = gM.ArcheryTowerPrefab;
		actualTurretVisualisation = gM.ArcheryTowerPrefabVisualisation;
		towerCost = gM.ArcheryTowerCost;

	}

	public void SelectCanonTower()
	{
		actualTurret = gM.CanonTowerPrefab;
		actualTurretVisualisation = gM.CanonTowerPrefabVisualisation;
		towerCost = gM.CanonTowerCost;
	}

	public void SelectFireTower()
	{
		actualTurret = gM.FireTowerPrefab;
		actualTurretVisualisation = gM.FireTowerPrefabVisualisation;
		towerCost = gM.FireTowerCost;
	}

	public void SelectIceTower()
	{
		actualTurret = gM.IceTowerPrefab;
		actualTurretVisualisation = gM.IceTowerPrefabVisualisation;
		towerCost = gM.IceTowerCost;
	}

	public void SelectLightningTower()
	{
		actualTurret = gM.LightningTowerPrefab;
		actualTurretVisualisation = gM.LightningTowerPrefabVisualisation;
		towerCost = gM.LightningTowerCost;
	}

	public void SelectPoisonTower()
	{
		actualTurret = gM.PoisonTowerPrefab;
		actualTurretVisualisation = gM.PoisonTowerPrefabVisualisation;
		towerCost = gM.PoisonTowerCost;
	}

	public void SelectMachinGunTower()
	{
		actualTurret = gM.MachinGunTowerPrefab;
		actualTurretVisualisation = gM.MachinGunTowerPrefabVisualisation;
		towerCost = gM.MachinGunTowerCost;
	}




	public void SelectDestroyTower()
	{
		actualTurret = null;
		actualTurretVisualisation = gM.DestroyTowerVisualisation;
	}



	public void StartLevel()
	{
		mainMenu.SetActive (false);
		gM.money = 200;

		mainLevel.SetActive (true);

		Destroy (demoLevel);
		AudioListener.volume = 1f;
		mainEnemySpawn.GetComponent<EnemySpawn> ().canSpawn = true;

	}

	/*
	void resizeDemoImage()
	{
		float height = GetComponent<Canvas> ().pixelRect.height - 60.0f;
		float width = GetComponent<Canvas> ().pixelRect.width - 60.0f;

		demoLevelImage.height = height;
		demoLevelImage.width = width;


	}
	*/

	public void ToggleHowToPlayMenu ()
	{
		isHTPMenuVisible = !isHTPMenuVisible;
		HTPMenu.SetActive (isHTPMenuVisible);
	}

	public void ToggleCredits()
	{
		isCreditsVisible = !isCreditsVisible;
		Credits.SetActive (isCreditsVisible);
	}

	public void ToggleWinMenu()
	{
		WinMenu.SetActive (true);
		Time.timeScale = 0f;
	}



}
