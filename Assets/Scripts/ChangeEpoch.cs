using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEpoch : MonoBehaviour
{

    public GameObject[] epochs;

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            kek();
        }
    }
    private void kek()
    {
        Debug.Log("ggg");
        epochs[0].SetActive(false);
        epochs[1].SetActive(true);

    }

}
