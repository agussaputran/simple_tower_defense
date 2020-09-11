using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour 
{
	float timer = 0;
	void Start () 
	{
		
	}

	void Update () 
	{
		if (Data.isLose)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                SceneManager.LoadScene(2);
            }
        }
	}
}
