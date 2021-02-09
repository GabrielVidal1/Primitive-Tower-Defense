using UnityEngine;
using System.Collections;

public class EnemySpawnAnimation : MonoBehaviour {

	
	public Transform sphere1;
	public Transform sphere2;

	void Update () 
	{
		sphere1.Rotate (0, 90f * Time.deltaTime, 0);

		sphere2.Rotate (0, -90f * Time.deltaTime, 0);

	}
}
