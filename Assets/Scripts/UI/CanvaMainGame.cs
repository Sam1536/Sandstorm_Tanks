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

    [Tooltip("Componente de texto com a contagem de silos destruido")]
    public Text siloCount;

    [Space(10)]
    public GameObject panelGameover;
    public GameObject panelVictory;

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

    public void ShowGameOver()
    {
        panelGameover.SetActive(true);
    }

    public void ShowVictoryGame()
    {
        panelVictory.SetActive(true);
    }

    public void ChangeSiloUI(int count)
    {
        siloCount.text = count.ToString();
    }
   
}
