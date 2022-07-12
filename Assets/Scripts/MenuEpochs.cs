using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuEpochs : Oprimization
{
    private bool OnOff;
    private bool Menu;
    public GameObject[] epochs;
    public GameObject effect;
    public GameObject[] epochsYears;
    public Oprimization optimiz = new Oprimization();
    public Camera cum;
    public int[] numbers;
    public float timer=0;
    public float time=0;
    public FirstPersonLook look;
    private void Start()
    {
        look.sensitivity = 2f;
        effect.SetActive(false);
        
    }
    public override void Opt(GameObject[] gm)
    {
        base.Opt(gm);
    }
    public void Opt(GameObject[] gm, bool ok)
    {
        for (int i = 0; i < gm.Length; i++)
        {
            gm[i].SetActive(true);
            
        }
    }
    public void Opt(GameObject[] gm, int[] numbers, int num1, int num2)
    {    
        for (int i = 0; i < gm.Length; i++)
        {
            if (gm[i].active && (IF(i, numbers[num1]) || IF(i, numbers[num2])))
                gm[i].SetActive(false);

        }
    }
    public void Opt(GameObject[] gm, int[] numbers, int num1, int num2, int num3)
    {
        for (int i = 0; i < gm.Length; i++)
        {
            if (gm[i].active && (IF(i, numbers[num1]) || IF(i, numbers[num2]) || IF(i, numbers[num3])))
                gm[i].SetActive(false);

        }
    }
    public void Opt(GameObject[] gm, int[] numbers, int num1, int num2, int num3, int num4)
    {
        for (int i = 0; i < gm.Length; i++)
        {
            if (gm[i].active && (IF(i, numbers[num1]) || IF(i, numbers[num2]) || IF(i, numbers[num3])|| IF(i, numbers[num4])))
                gm[i].SetActive(false);

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !Menu && !OnOff)
        {
            OnOff = true;
            look.sensitivity = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && OnOff && !Menu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            look.sensitivity = 2f;
            OnOff = false;
            effect.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !OnOff && !Menu)
        {
            Menu = true;
            look.sensitivity = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Menu && !OnOff)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            look.sensitivity = 2f;
            Menu = false;
        }

        if (timer == 1)
        { 
            time += Time.deltaTime;
            if (time > 1f)
            {
                effect.SetActive(false);
                timer = 0;
                time = 0;
            }
        }
       
       
    }

    void ChangeEpoch(int num, bool active)
    {
        for (int i = 0; i < epochs.Length; i++)
        {
            epochs[i].SetActive(active);
        }
        epochs[num].SetActive(!active);
    }
    

    private void OnGUI()
    {
        if(OnOff == true)
        {
            effect.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 600) / 2, 300, 600), "Выберите эпоху:");
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + -50, 100, 40), "2022"))
            {
               
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ChangeEpoch(2,true);
                for (int i = 1; i < epochsYears.Length; i++)
                    epochsYears[i].SetActive(false);
                epochsYears[0].SetActive(true);
                OnOff = false;
                Opt(game, true);
                Opt(game);
                timer = 1;
                look.sensitivity = 2f;
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 0 , 100, 40), "2002"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                for (int i = 1; i < epochsYears.Length; i++)
                    epochsYears[i].SetActive(false);
                epochsYears[0].SetActive(true);
                Opt(game, true);
                Opt(game);
                ChangeEpoch(2,false);   
                OnOff = false;
                timer = 1;
                look.sensitivity = 2f;
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 50, 100, 40), "1982")) 
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ChangeEpoch(2, false);
                for (int i = 1; i < epochsYears.Length; i++)
                    epochsYears[i].SetActive(false);
                epochsYears[0].SetActive(true);
                Opt(game, true);
                Opt(game, numbers, 3, 5, 7);
                OnOff = false;
                timer = 1;
                look.sensitivity = 2f;
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 100, 100, 40), "1962"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ChangeEpoch(2, false);
                for (int i = 1; i < epochsYears.Length; i++)
                    epochsYears[i].SetActive(false);
                epochsYears[0].SetActive(true);
                Opt(game, true);
                Opt(game, numbers, 3,4, 5, 7);
                OnOff = false;
                timer = 1;
                look.sensitivity = 2f;
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 150, 100, 40), "1942"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ChangeEpoch(2, false);
                Opt(game, true);
                Opt(game, numbers, 3, 4, 5, 7);
                for (int i = 1; i < epochsYears.Length; i++)
                    epochsYears[i].SetActive(false);
                epochsYears[0].SetActive(true);
                epochsYears[1].SetActive(true);
                OnOff = false;
                timer = 1;
                look.sensitivity = 2f;
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 200, 100, 40), "1922"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ChangeEpoch(2, false);
                Opt(game, true);
                Opt(game, numbers, 3, 4, 5, 7);
                for (int i = 1; i < epochsYears.Length; i++)
                    epochsYears[i].SetActive(false);
                epochsYears[0].SetActive(false);
                OnOff = false;
                timer = 1;
                look.sensitivity = 2f;
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 250, 100, 40), "1902"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ChangeEpoch(2, false);
                Opt(game, true);
                Opt(game, numbers, 3, 4, 5, 7);
                for (int i = 0; i < epochsYears.Length; i++)
                    epochsYears[i].SetActive(false);
                epochsYears[0].SetActive(false);
                OnOff = false;
                timer = 1;
                look.sensitivity = 2f;
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 300, 100, 40), "1882"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ChangeEpoch(2, false);
                Opt(game, true);
                Opt(game, numbers, 3, 4, 5, 7);
                for (int i = 1; i < epochsYears.Length; i++)
                    epochsYears[i].SetActive(false);
                epochsYears[0].SetActive(false);
                epochsYears[2].SetActive(true);
                OnOff = false;
                timer = 1;
                look.sensitivity = 2f;
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
                look.sensitivity = 2f;
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
