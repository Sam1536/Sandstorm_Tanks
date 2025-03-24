using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaMainMenu : MonoBehaviour
{
    public string mainGameName = "mainGame";

    public void LoadGame()
    {
        SceneManager.LoadScene(mainGameName);
    }

    public void Exit()
    {
        Application.Quit();
        //Debug.Log("Saindo...");
    }
}
