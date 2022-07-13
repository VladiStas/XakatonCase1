using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuEpochs : Oprimization
{
    private bool OnOff;
    public bool Menu;
    public bool MenuSettings;
    public GameObject[] epochs;
    public GameObject effect;
    public GameObject star;
    public GameObject[] epochsYears;
    public GameObject[] monuments;
    public GameObject[] DontDestroy;
    public Oprimization optimiz = new Oprimization();
    public Camera cum;
    public int[] numbers;
    public float timer = 0;
    public float time = 0;
    public FirstPersonLook look;

    public GameObject[] settings;
    public Material[] skyboxes;
    // Переменные для настроек
    private bool toggleClouds = true; // Облака
    private bool toggleStars = true; // Звезды
    private bool toggleSounds = true; // Звезды
    public float sliderZoom = 0.0f; // Дальность видимости

    public DayCycleManager dayNight;

    private void Start()
    {
        Time.timeScale = 1f;
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
            if (gm[i].active && (IF(i, numbers[num1]) || IF(i, numbers[num2]) || IF(i, numbers[num3]) || IF(i, numbers[num4])))
                gm[i].SetActive(false);

        }
    }

    void Update()
    {
        // Debug.Log(toggleClouds); // проверка на true false toggle

        if (Input.GetKeyDown(KeyCode.X))
            star.SetActive(false);
        if (Input.GetKeyDown(KeyCode.C))
            star.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Z) && !Menu && !OnOff && !MenuSettings)
        {
            OnOff = true;
            look.sensitivity = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && OnOff && !Menu && !MenuSettings)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            look.sensitivity = 2f;
            OnOff = false;
            effect.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !OnOff && !Menu && !MenuSettings)
        {
            Menu = true;
            look.sensitivity = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Menu && !OnOff && !MenuSettings)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            look.sensitivity = 2f;
            Menu = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !OnOff && !Menu && MenuSettings)
        {
            MenuSettings = false;
            Menu = true;
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

    void Epochs(bool active, int numEpochs, bool activeEpochs, bool activeMonuments, string epohs)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ChangeEpoch(2, active);
        for (int i = 0; i < epochsYears.Length; i++)
            epochsYears[i].SetActive(false);
        epochsYears[numEpochs].SetActive(activeEpochs);
        for (int i = 0; i < monuments.Length; i++)
            monuments[i].SetActive(activeMonuments);
        OnOff = false;
        Opt(game, true);
        // Opt(game);
        timer = 1;
        look.sensitivity = 2f;

    }


    private void OnGUI()
    {
        if (OnOff)
        {
            effect.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 600) / 2, 300, 600), "Выберите эпоху:");
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + -50, 100, 40), "2022"))
            {
                Epochs(true, 0, true, true, "2022");
                Opt(game);
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 0, 100, 40), "2002"))
            {
                Epochs(false, 0, true, true, "2002");
                Opt(game);
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 50, 100, 40), "1982"))
            {

                Epochs(false, 0, true, true, "1982");
                Opt(game, numbers, 3, 5, 7);

            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 100, 100, 40), "1962"))
            {

                Epochs(false, 0, true, true, "1962");
                Opt(game, numbers, 3, 4, 5, 7);

            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 150, 100, 40), "1942"))
            {

                Epochs(false, 0, true, false, "1942");
                Opt(game, numbers, 3, 4, 5, 7);

                epochsYears[1].SetActive(true);

            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 200, 100, 40), "1922"))
            {

                Epochs(false, 0, true, false, "1922");
                Opt(game, numbers, 2, 3, 5, 7);

            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 250, 100, 40), "1902"))
            {

                Epochs(false, 0, false, false, "1902");
                Opt(game, numbers, 3, 4, 5, 7);

                epochsYears[2].SetActive(true);
                epochsYears[3].SetActive(true);
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 300, 100, 40), "1882"))
            {

                Epochs(false, 0, false, false, "1882");
                Opt(game, numbers, 3, 4, 5, 7);

                epochsYears[2].SetActive(true);

            }

        }

        if (Menu)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Меню");
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 100, 100, 40), "Вернуться"))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                Menu = false;
                look.sensitivity = 2f;
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 200, 100, 40), "Настройки")) // При нажатии на кнопку Настройки
            {
                Menu = false; // Выключается меню
                MenuSettings = true; // Включается окно настроек
            }
            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 150, 100, 40), "Выйти"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                for (int i = 0; i < DontDestroy.Length; i++)
                    Destroy(DontDestroy[i]);
            }
        }

        if (MenuSettings)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GUI.Box(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 300, 300), "Настройки");

            toggleClouds = GUI.Toggle(new Rect((Screen.width - 280) / 2, (Screen.height - 400) / 2 + 100, 100, 30), toggleClouds, "Облака");// toggle облаков
            CheckBoxSettings(toggleClouds, 0, true);

            toggleStars = GUI.Toggle(new Rect((Screen.width - 280) / 2, (Screen.height - 400) / 2 + 130, 100, 30), toggleStars, "Звезды"); // toggle звезд
            toggleSounds = GUI.Toggle(new Rect((Screen.width - 280) / 2, (Screen.height - 400) / 2 + 160, 100, 30), toggleSounds, "Звуки"); // toggle звуков
            CheckBoxSettings(toggleStars, 1, true);
            CheckBoxSettings(toggleSounds, 2, true);
            GUI.Label(new Rect((Screen.width - 280) / 2, (Screen.height - 400) / 2 + 185, 100, 30), "Прорисовка");
            sliderZoom = GUI.HorizontalSlider(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 190, 100, 30), sliderZoom, 1f, 5f); // slider прорисовки
            SliderZoom();
            GUI.Label(new Rect((Screen.width - 280) / 2, (Screen.height - 400) / 2 + 218, 100, 30), "Время суток");
            if (GUI.Button(new Rect((Screen.width - 105) / 2, (Screen.height - 400) / 2 + 215, 50, 30), "День"))
            {
                dayNight.TimeOfDay = 0.3f;
                dayNight.DayDuration = 1200000;
            }
            if (GUI.Button(new Rect((Screen.width + 4) / 2, (Screen.height - 400) / 2 + 215, 50, 30), "Ночь"))
            {
                dayNight.TimeOfDay = 0.7f;
                dayNight.DayDuration = 1200000;
            }
            if (GUI.Button(new Rect((Screen.width + 110) / 2, (Screen.height - 400) / 2 + 215, 90, 30), "Поочередно"))
            {
                dayNight.TimeOfDay = 0f;
                dayNight.DayDuration = 300;
            }

            if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2 + 300, 100, 40), "Назад")) // При нажатии на кнопку Назад
            {
                Menu = true; // Включается меню
                MenuSettings = false; // Выключается окно настроек
            }
        }
    }
    void CheckBoxSettings(bool chkbox, int index, bool active)
    {
        if (chkbox)
        {
            SettingsGame(index, active);
        }
        else SettingsGame(index, !active);
    }
    void SettingsGame(int index, bool active)
    {

        settings[index].SetActive(active);
    }


    void SliderZoom()
    {
        if (sliderZoom == 1)
            cum.farClipPlane = 1000;
        if (sliderZoom > 1 && sliderZoom <= 2)
            cum.farClipPlane = 2000;
        if (sliderZoom > 2 && sliderZoom <= 3)
            cum.farClipPlane = 3000;
        if (sliderZoom > 3 && sliderZoom <= 4)
            cum.farClipPlane = 4000;
        if (sliderZoom > 4 && sliderZoom <= 5)
            cum.farClipPlane = 5000;
    }
}