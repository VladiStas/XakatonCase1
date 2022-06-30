using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obj.SetActive(false);
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(true);   
    }
}
