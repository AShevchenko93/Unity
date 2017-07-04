using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	public GameObject Setting;

	public void StartGame()
    {
		Application.LoadLevel (1);
    }
    public void LoadGame()
    {

    }
    public void Settings()
    {
		Setting.SetActive (!Setting.activeSelf);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
