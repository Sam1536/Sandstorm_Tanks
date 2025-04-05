using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankTurret : MonoBehaviour
{

    public float rotationSpeed = 5.0f;

    public Transform turrent;

    private RaycastHit hit;

    private TankController tankController;

    public Transform crosshairUI; // Arraste o GameObject da mira aqui pelo Unity



    private void Start()
    {
        tankController = this.GetComponent<TankController>();
    }


    private void FixedUpdate()
    {

        if (!tankController.control)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }
     
        Vector3 point = hit.point - turrent.position;
        point.y = 0;

        Quaternion toRotation = Quaternion.LookRotation(point);

        turrent.rotation = Quaternion.Lerp(turrent.rotation, toRotation, rotationSpeed * Time.deltaTime);

        //Atualiza a posição da mira
        if (crosshairUI != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(hit.point);
            crosshairUI.position = screenPos;
            return;
        }


    }

}
