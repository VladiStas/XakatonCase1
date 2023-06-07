using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private GameObject image;
    private GameObject pointGame;
    private const string point = "Point";
    private RaycastHit hit;
    private Camera cameraMain;

    private void Start()
    {
        cameraMain = Camera.main;
    }
    private void Update()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.collider == null)
        {
            return;
        }
        if (!hit.collider.CompareTag(point))
        {
            image.SetActive(false);
        }
        else TeleportPlayer();
    }

    private void TeleportPlayer()
    {
        image.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            pointGame = hit.collider.gameObject;
            transform.position = pointGame.transform.position;
            image.SetActive(false);
        }
    }

}