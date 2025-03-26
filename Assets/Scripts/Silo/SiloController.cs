using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiloController : MonoBehaviour
{
    private int total = 0;

    public CanvaMainGame canvaMain;


    // Start is called before the first frame update
    void Start()
    {
        total = gameObject.transform.childCount;
        ChangeUI();

        //Debug.Log(total);
    }

    public void SetDestroy()
    {
        total -= 1;

        if(total == 0)
        {
            StartCoroutine(Victory());
        }

        ChangeUI();
    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(5);
        canvaMain.ShowVictoryGame();


    }

    private void ChangeUI()
    {
        canvaMain.ChangeSiloUI(total);
    }
}
