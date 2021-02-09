using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {


	public bool canSpawn;

	public GameObject DemoTarget;
	public bool isDemo;

	public float delay;

	public GameObject enemyPrefab;
	public Transform spawn;


	private float lastWave = 0f;

	public GameObject TotalEnemyDemo;

	private EnemyWave[] enemyWavePatern;







	private EnemyWave actualWave;

	private float wave;
	private GameManager gM;


	void Start () 
	{

		gM = GameObject.FindWithTag ("GameController").GetComponent<GameManager> ();
		enemyWavePatern = new EnemyWave[ 30 ];

		enemyWavePatern = new EnemyWave[] { new EnemyWave( 1, 1, false, false ), new EnemyWave( 1, 5, false, false ), new EnemyWave( 2, 1, false, false ), new EnemyWave( 1, 10, false, false ), new EnemyWave( 1, 1, true, false ), new EnemyWave( 2, 3, false, false ), new EnemyWave( 3, 1, false, false ), new EnemyWave( 2, 5, false, false ), new EnemyWave( 3, 3, false, false ), new EnemyWave( 1, 2, false, true ), new EnemyWave( 1, 4, true, false ), new EnemyWave( 3, 5, false, false ), new EnemyWave( 1, 3, true, true ), new EnemyWave( 3, 3, false, true ),new EnemyWave( 3, 6, true, false ) };
		wave = 0;

		actualWave = enemyWavePatern[ 0 ];









	
	}

	void Update () 
	{
		if (!canSpawn)
			return;


		if (Time.time - lastWave > delay)
		{
			print ("Cette vague sera composée de " + actualWave.enemyCount + " enemis de niveau " + actualWave.level);

			for (int i = 0; i < actualWave.enemyCount ; i++) 
			{

				GameObject enemy = (GameObject) Instantiate (enemyPrefab, spawn.position, Quaternion.identity);

				enemy.GetComponent<Enemy> ().level = actualWave.level;
				enemy.GetComponent<Enemy> ().isAMinion = actualWave.isMinion;
				enemy.GetComponent<Enemy> ().mage = actualWave.isMage;

				if (isDemo) {
					enemy.GetComponent<Enemy> ().enemyNexus = DemoTarget.transform;
					enemy.GetComponent<NavMeshAgent> ().speed *= 2;
					enemy.transform.SetParent (TotalEnemyDemo.transform);
				}

			}

			if (!isDemo) {

				gM.NextWave ();

				enemyWavePatern [(int)wave].enemyCount *= 5;

				wave++;

				if (wave >= 14)
					wave = 0;

				actualWave = enemyWavePatern [ (int)wave];
			}

			lastWave = Time.time;
		}
	
	}

	public class EnemyWave
	{

		public int level;
		public int enemyCount;
		public bool isMinion;
		public bool isMage;

		public EnemyWave( int level, int enemyCount, bool isMinion, bool isMage )
		{
			this.level = level;
			this.enemyCount = enemyCount;
			this.isMinion = isMinion;
			this.isMage = isMage;
		}


	}









}