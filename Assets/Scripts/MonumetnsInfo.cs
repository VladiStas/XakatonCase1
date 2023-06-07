using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonumetnsInfo : MonoBehaviour
{
    private RaycastHit hitMonument;
    private Camera cameraMain;
    private const string attraction = "Attraction";
    private InformationAboutTheMonuments info;

    private void Start()
    {
        cameraMain = Camera.main;
    }
    void Update()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitMonument);
       
        if (hitMonument.collider.CompareTag(attraction))
        {
           
            info = hitMonument.collider.GetComponent<InformationAboutTheMonuments>();
            info.informations.SetActive(true);
        }
        else info.informations.SetActive(false);
    }
}

    //private void OnGUI()
    //{
    //    if(isMonument)
    //    {
    //        GUI.Box(new Rect((Screen.width - 1700) / 2, (Screen.height - 600) / 2, 300, 600), "Родина-мать зовёт!");
    //        GUI.Label(new Rect((Screen.width - 1680) / 2, (Screen.height - 900) / 2 + 185, 250, 700), "Скульптура «Родина-мать зовёт!» — композиционный центр" +
    //            " памятника-ансамбля «Героям Сталинградской битвы» на Мамаевом кургане в Волгограде. Одна из самых высоких статуй мира, высочайшая статуя России " +
    //            "(без постамента — самая высокая статуя в мире на момент постройки и в течение последующих 22 лет)." +
    //            "Работа скульптора Е. В. Вучетича и инженера Н. В. Никитина представляет собой многометровую фигуру женщины, шагнувшей вперёд с поднятым мечом." +
    //            " Статуя является аллегорическим образом Родины, зовущей своих сыновей на битву с врагом." +
    //            "В 1959—1967 годах по проекту и под непосредственным руководством скульптора был сооружён мемориальный ансамбль героям Сталинградской битвы на Мамаевом кургане в " +
    //            "Волгограде (совместно со скульпторами М. С. Алешенко, В. Е. Матросовым, В. С. Зайковым, Л. М. Майстренко, А. Н. Мельником, В. А. Маруновым, В. С. Новиковым, " +
    //            "А. А. Тюренковым; архитекторами Я. Б. Белопольским, В. А. Дёминым, Ф. М. Лысовым и др.; руководитель группы инженеров — Н. В. Никитин)");
    //    }
    //}


