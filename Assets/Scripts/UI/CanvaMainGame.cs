using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvaMainGame : MonoBehaviour
{
    [Header("PLayer Health")]
    public Image healthBar;

    public void BackToManu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HealthValue(float health)
    {
        healthBar.fillAmount = health;
         

    }
   
}
