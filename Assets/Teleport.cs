using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject[] objs;
    public float time=0f;
    public GameObject image;
    public float distance;
    float player_distance;
    RaycastHit hit;
    private void Update()
    {
        TeleportPlayer(objs);
    }

    void ActivePoint(GameObject[] gm)
    {
        for (int i = 0; i < gm.Length; i++)
            gm[i].SetActive(true);
    }
    void TeleportPlayer(GameObject[] gm, RaycastHit hit, int i, float distance)
    {

      
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = gm[i].transform.position;
            gm[i].active = false;
            
            image.SetActive(false);
        }
        
            
      
    }

    void TeleportPlayer(GameObject[] gm)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        Debug.DrawRay(transform.position, ray.direction * distance, Color.yellow);
        time += Time.deltaTime;
        Debug.Log($"Time:{time}");
        if (hit.collider != null)
        {
            for (int i = 0; i < objs.Length; i++)
            {

                player_distance = Vector3.Distance(gm[i].transform.position, transform.position);
                if (hit.collider.gameObject == gm[i].gameObject)
                {

                    image.SetActive(true);
                    TeleportPlayer(objs, hit, i, player_distance);

                    if (time> 1f)
                    {
                        ActivePoint(gm);
                        time = 0f;
                    }

                    break;
                }
                else { image.SetActive(false); }

            }

        }
        else { image.SetActive(false); time = 0; }
    }

}
