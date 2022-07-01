using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public GameObject collider;
   // private void OnTriggerEnter(Collider other)
   // {
    //    if (other.CompareTag("Player"))
    //    {
    //        obj.SetActive(true);
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(true);
        collider.SetActive(false);
    }
}
