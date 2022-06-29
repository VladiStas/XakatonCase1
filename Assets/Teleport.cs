using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject[] objs;
    public GameObject image;
    public float distance;
    RaycastHit hit;
    private void Update()
    {
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        Debug.DrawRay(transform.position, ray.direction * distance, Color.yellow);

        if(hit.collider != null)
        {

            TeleportPlayer(); 
            
        }
        else { image.SetActive(false); }

    }

    void TeleportPlayer()
    {

        if (hit.collider.gameObject == objs[0].gameObject)
        {
            image.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = objs[0].transform.position;
                image.SetActive(false);
            }
        }
        else if (hit.collider.gameObject == objs[1].gameObject)
        {
            image.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = objs[1].transform.position;
                image.SetActive(false);
            }
        }
        else if (hit.collider.gameObject == objs[2].gameObject)
        {
            image.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = objs[2].transform.position;
                image.SetActive(false);
            }
        }
        else if (hit.collider.gameObject == objs[3].gameObject)
        {
            image.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = objs[3].transform.position;
                image.SetActive(false);
            }
        }
        else if (hit.collider.gameObject == objs[4].gameObject)
        {
            image.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = objs[4].transform.position;
                image.SetActive(false);
            }
        }
        else if (hit.collider.gameObject == objs[5].gameObject)
        {
            image.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = objs[5].transform.position;
                image.SetActive(false);
            }
        }
        else image.SetActive(false);
       
    }
   

}
