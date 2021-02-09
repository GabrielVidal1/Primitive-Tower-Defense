using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public Material canBuild;
	public Material cannotBuild;
	public Material idle;



	private GameObject turretPrefab;
	private GameObject turretVisualisationPrefab;


	private GameManager gM;
	private GameObject effectZone;

	private MainCanvas canvas;

	private float cost;

	public bool isEmpty;

	private bool canVisualisation = true;

	private int[] wavePatern = new int[ 1 ];


	void Start ()
	{
		canvas = GameObject.FindWithTag ("Canvas").GetComponent<MainCanvas>();
		gM = GameObject.FindWithTag ("GameController").GetComponent<GameManager> ();
		
	}




	void Update()
	{


		turretPrefab = canvas.actualTurret;
		turretVisualisationPrefab = canvas.actualTurretVisualisation;
		cost = canvas.towerCost;

	}






	void OnMouseOver () 
	{
		if (isEmpty ) {
			GetComponent<Renderer> ().material = canBuild;

			if (canVisualisation) 
			{
				GameObject turretVisualisation = (GameObject) Instantiate (turretVisualisationPrefab, transform.position, Quaternion.identity);
				turretVisualisation.transform.SetParent (gameObject.transform);
				canVisualisation = false;
				
			}

		} else {
			GetComponent<Renderer> ().material = cannotBuild;
			if (turretPrefab == null) 
			{
				GameObject turretVisualisation = (GameObject) Instantiate (turretVisualisationPrefab, transform.position, Quaternion.identity);
				turretVisualisation.transform.SetParent (gameObject.transform);
				canVisualisation = false;

			}
		}
	}

	void OnMouseExit ()
	{
		GetComponent<Renderer> ().material = idle;

		foreach (Transform child in transform)
			if (child.tag == "Visualisation")
				Destroy (child.gameObject);
		
		canVisualisation = true;
	}

	void OnMouseDown () 
	{
		if (isEmpty) {

			foreach (Transform child in transform)
				if (child.tag == "Visualisation")
					Destroy (child.gameObject);


			if (gM.money >= cost) 
			{
				GameObject turret = (GameObject)Instantiate (turretPrefab, transform.position, Quaternion.identity);
				turret.transform.SetParent (transform);
				isEmpty = false;
				gM.money -= cost;
			}


		} else if (turretPrefab == null) 
		{

			foreach (Transform child in transform)
				if (child.tag == "Turret")
					Destroy (child.gameObject);
			isEmpty = true;


		}
			



	}

	public void BuildTurret()
	{
		GameObject turret = (GameObject)Instantiate (turretPrefab, transform.position, Quaternion.identity);





	}

}
