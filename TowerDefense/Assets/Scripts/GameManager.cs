using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{

	public float money;


	public Scene MainScene;


	public float unitsPerLife;
	public float bulletLifeTime;
	public float delayBetweenTwoWaves;
	public float respawnDelay;

	public Vector3 camRelativePos;
	public Vector3 camRelativeRot;

    public Material lifeBarMaterial;
	public Material ArmorBarMaterial;

	public GameObject MainCam;

	public GameObject ArcheryTowerPrefab;
	public GameObject ArcheryTowerPrefabVisualisation;
	public float ArcheryTowerCost;

	public GameObject CanonTowerPrefab;
	public GameObject CanonTowerPrefabVisualisation;
	public float CanonTowerCost;

	public GameObject FireTowerPrefab;
	public GameObject FireTowerPrefabVisualisation;
	public float FireTowerCost;

	public GameObject IceTowerPrefab;
	public GameObject IceTowerPrefabVisualisation;
	public float IceTowerCost;

	public GameObject LightningTowerPrefab;
	public GameObject LightningTowerPrefabVisualisation;
	public float LightningTowerCost;

	public GameObject PoisonTowerPrefab;
	public GameObject PoisonTowerPrefabVisualisation;
	public float PoisonTowerCost;

	public GameObject MachinGunTowerPrefab;
	public GameObject MachinGunTowerPrefabVisualisation;
	public float MachinGunTowerCost;

	public GameObject DestroyTowerVisualisation;



    public GameObject bulletPrefab;
	public GameObject gunSbirePrefab;

	public Transform Nexus;


	public Slider nexusLifeBar;
	public float nexusLife = 10f;
	private float initialNexusLife;

	public GameObject perduButton;


	public float wave;


	void Start()
	{
		initialNexusLife = nexusLife;

		AudioListener.volume = .1f;

	}








	void Update() 
	{

		Collider[] entities = Physics.OverlapSphere(transform.position, 2);

		foreach (Collider entity in entities)
		{
			if (entity.tag == "Entity")
			{
				
				nexusLife--;
				nexusLifeBar.GetComponent<Slider> ().value = (nexusLife / initialNexusLife);
				Destroy (entity.gameObject);
			}
		}


		if (nexusLife <= 0) 
		{
			perduButton.SetActive (true);
			Time.timeScale = 0.05f;
		}


		if (wave >= 30f) 
		{
			print ("coucou");
			GameObject.FindWithTag ("Canvas").GetComponent<MainCanvas> ().ToggleWinMenu ();
		}





	}
		


	public void Quit ()
	{
		Application.Quit ();
	}

	public void Restart()
	{
		SceneManager.LoadScene (MainScene.name);
	}


	public void NextWave()
	{
		wave++;
	}




		
}
