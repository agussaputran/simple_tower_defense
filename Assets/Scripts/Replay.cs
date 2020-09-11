using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour 
{
    public Text info;

	void Start () 
	{
		 if (Data.isWin)
        {
            info.text = "Congratulations \n You Win!";
        }
        else
        {
            info.text = "GAMEOVER \n You Lose!";
        }
	}

	public void RestartGame()
	{
		Data.isLose = false;
        Data.isWin = false;
        Data.coin = 0;
        SceneManager.LoadScene(1);
	}

	public void Menu()
	{
		Data.isLose = false;
        Data.isWin = false;
        Data.coin = 0;
        SceneManager.LoadScene(0);
	}
}
