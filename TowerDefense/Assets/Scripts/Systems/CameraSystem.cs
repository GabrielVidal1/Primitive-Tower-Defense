using UnityEngine;
using System.Collections;

public class CameraSystem : MonoBehaviour {

	public Transform player;

	private Vector3 camRelativePos;
	private Vector3 camRelativeRot;

	void Start () 
	{

		GameObject gameManager = GameObject.FindWithTag ("GameController");
		GameManager gM = gameManager.GetComponent<GameManager> ();

		camRelativePos = gM.camRelativePos;
		camRelativeRot = gM.camRelativeRot;
		transform.position = player.transform.position + camRelativePos;
		transform.Rotate (camRelativeRot);

		
	}

}
