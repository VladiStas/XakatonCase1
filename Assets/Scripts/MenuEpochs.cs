using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuEpochs : MonoBehaviour
{
    private bool OnOff;
    private bool Menu;
    public GameObject[] epochs;
    public GameObject effect;

    private void Start()
    {
        effect.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !Menu && !OnOff)
            OnOff = true;
        else if (Input.GetKeyDown(KeyCode.O) && OnOff && !Menu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            OnOff = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !OnOff && !Menu)
            Menu = true;
        else if (Input.GetKeyDown(KeyCode.Escape) && Menu && !OnOff)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            Menu = false;
        }
            
    }

    private void OnGUI()
    {
        if(OnOff == true)
        {
            effect.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Выберите эпоху:");
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 100, 100, 40), "2022"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                for(int i = 0; i < 28 ; i++)
                {
                    epochs[i].SetActive(true);
                }
                epochs[2].SetActive(false);
                OnOff = false;
                effect.SetActive(false);
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 150, 100, 40), "2002"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                for (int i = 0; i < 28; i++)
                {
                    epochs[i].SetActive(false);
                }
                epochs[2].SetActive(true);            
                OnOff = false;
                effect.SetActive(false);
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 200, 100, 40), "1982")) 
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                epochs[0].SetActive(false);
                epochs[1].SetActive(false);
                epochs[2].SetActive(true);
                OnOff = false;
                effect.SetActive(false);
            }
        }

        if(Menu == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Меню");
            if(GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 100, 100, 40), "Вернуться"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                Menu = false;
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 200, 100, 40), "Настройки"))
            {

            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 150, 100, 40), "Выйти"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
