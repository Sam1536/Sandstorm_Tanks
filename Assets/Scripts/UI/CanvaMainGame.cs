using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvaMainGame : MonoBehaviour
{
    [Header("PLayer Health")]
    public Image healthBar;

    [Tooltip("Qual é a cena a ser carregada quando clicar no botão Reset?")]
    public string sceneGame = "MainGame";

    public void BackToManu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(sceneGame);

    }

    public void HealthValue(float health)
    {
        healthBar.fillAmount = health;
         

    }
   
}
