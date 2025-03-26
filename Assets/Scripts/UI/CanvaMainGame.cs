using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvaMainGame : MonoBehaviour
{
    [Header("PLayer Health")]
    public Image healthBar;
    public AudioSource audioVictory;
    public AudioSource background;
    [SerializeField]private AudioSource audioGameover;

    private TankController tankController;
    private TankWeapon tankWeapon;
    private TankTurret tankTurret;

    [Tooltip("Qual é a cena a ser carregada quando clicar no botão Reset?")]
    public string sceneGame = "MainGame";
    public string sceneEnd = "SceneThanks";

    public float nextScene = 5f;

    [Tooltip("Componente de texto com a contagem de silos destruido")]
    public Text siloCount;

    [Space(10)]
    public GameObject panelGameover;
    public GameObject panelVictory;

    private void Start()
    {
        tankController = FindObjectOfType<TankController>();
        tankWeapon = FindObjectOfType<TankWeapon>();
        tankTurret = FindObjectOfType<TankTurret>();
        audioGameover = FindObjectOfType<AudioSource>();

    }

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
        audioGameover.Play();

    }

    public void ShowVictoryGame()
    {
        panelVictory.SetActive(true);
        audioVictory.Play();
        background.Stop();
        tankController.enabled = false;
        tankWeapon.enabled = false;
        tankTurret.enabled = false;
        StartCoroutine(NextScene());

    }

    public void ChangeSiloUI(int count)
    {
        siloCount.text = count.ToString();
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(nextScene);
        SceneManager.LoadScene(sceneEnd);

    }

}
