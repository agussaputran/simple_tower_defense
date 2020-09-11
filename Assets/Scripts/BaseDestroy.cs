using UnityEngine;

public class BaseDestroy : MonoBehaviour 
{
	public bool isPlayer = true;

	void Start () 
	{
		
	}

	void Update () 
	{
		
	}

	private void OnDestroy() 
	{
		if (!Data.isLose)
            if (isPlayer)
            {
                Data.isLose = true;
                Data.isWin = false;
                Debug.Log("Player Lost");
            }
            else
            {
                Data.isLose = true;
                Data.isWin = true;
                Debug.Log("Player Win");
            }
	}
}
