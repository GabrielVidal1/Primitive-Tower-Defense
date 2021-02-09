using UnityEngine;
using System.Collections;

public class KillEnemyZone : MonoBehaviour {

	void Update () 
	{
		Collider[] entities = Physics.OverlapSphere(transform.position, 1);

		foreach (Collider entity in entities)
		{
			if (entity.tag == "Entity")
			{
				Destroy (entity);
			}
		}
	
	}
}
