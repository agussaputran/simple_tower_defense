using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour 
{
    public GameObject enemy;
    public float delaySpawnEnemy = 6f;

	float timer = 0;

	void Start () 
	{
		
	}

	void Update () 
	{
		timer += Time.deltaTime;
        if(timer > delaySpawnEnemy)
        {
            Instantiate(enemy, new Vector3(Random.Range(2f, 4f), Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
            timer = 0;
        }
	}
}
