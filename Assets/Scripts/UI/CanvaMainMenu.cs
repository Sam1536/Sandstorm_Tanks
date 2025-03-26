using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaMainMenu : MonoBehaviour
{
    public string mainGameName = "mainGame";
    public GameObject panelCOntrol;

    public void LoadGame()
    {
        SceneManager.LoadScene(mainGameName);
    }


    public void ShowControl()
    {
        panelCOntrol.SetActive(true);
    } 
    
    public void HideControl()
    {
        panelCOntrol.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        //Debug.Log("Saindo...");
    }
}
