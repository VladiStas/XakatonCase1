using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update

    public Toggle toggle;
    public GameObject gm;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
        {
            gm.SetActive(true);
        }
        else if (!toggle.isOn)
        {
            gm.SetActive(false);        
        }
    }
}
