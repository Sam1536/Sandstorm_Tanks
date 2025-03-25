using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvaEnd : MonoBehaviour
{

    public AudioSource audioSourceM;
    public float musicTime = 201.65f;

    public string sceneGame = "MainMenu";


    // Start is called before the first frame update
    void Start()
    {
        audioSourceM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        End();
    }


    public void End()
    {
        StartCoroutine(EndMusic());
    }

    public void EndTime()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator EndMusic()
    {
        yield return new WaitForSeconds(musicTime);
        SceneManager.LoadScene("MainMenu");
    }
}
