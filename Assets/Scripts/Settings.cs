using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEngine.UI.Toggle[] toggle;
    public Dropdown dropdown;
    public GameObject[] gm;
    public GameObject[] day;
    public Material[] skybox_day;
   
    public UnityEngine.UI.Text[] lbl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Toggles();
        DropdownItemSelected(dropdown);
       
    }
    void DropdownItemSelected(Dropdown dropdowns)
    {
        int index = dropdowns.value;
        for (int i = 0; i < dropdown.options.Count; i++)
        {
            if (i == index)
            {
                day[i].SetActive(true);
                RenderSettings.skybox = skybox_day[i];
                if (i == 2)
                    day[2].SetActive(true);
            }
            else if (i != index)
            {
                day[i].SetActive(false);
            }
        }
    }
    void Toggles()
    {
        for (int i = 0; i < toggle.Length; i++)
            if (toggle[i].isOn)
            {
                gm[i].SetActive(true);
                lbl[i].text = "Выкл";
                break;
            }
            else if (!toggle[i].isOn)
            {
                gm[i].SetActive(false);
                lbl[i].text = "Вкл";
                break;
            }
    }
    
   
}
