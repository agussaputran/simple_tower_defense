using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
	public void PlayButton()
	{
		SceneManager.LoadScene(1);
	}

	public void YesExitButton()
	{
		Application.Quit();
	}
}
