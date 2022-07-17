using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonumetnsInfo : MonoBehaviour
{
    public GameObject[] monuments;
    RaycastHit hitMonument;
    public LayerMask Layer;

    void FixedUpdate()
    {
        for(int i = 0; i < monuments.Length; i++)
        {
            monuments[i].SetActive(false);
        }         
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitMonument, 1000000, Layer);
        Debug.DrawRay(transform.position, ray.direction * 10000, Color.white);  
        if(hitMonument.collider != null)
        {
            if (hitMonument.collider.gameObject.tag == "Monument")
            {
                monuments[0].SetActive(true);
            }
            if (hitMonument.collider.gameObject.tag == "ArenaNew")
            {
                monuments[1].SetActive(true);
            }
            if (hitMonument.collider.gameObject.tag == "ArenaOld")
            {
                monuments[2].SetActive(true);
            }
            if (hitMonument.collider.gameObject.tag == "TV")
            {
                monuments[3].SetActive(true);
            }
            if (hitMonument.collider.gameObject.tag == "Church")
            {
                monuments[4].SetActive(true);
            }
            if (hitMonument.collider.gameObject.tag == "HallOfFlame")
            {
                monuments[5].SetActive(true);
            }
            if (hitMonument.collider.gameObject.tag == "HeroesSquare")
            {
                monuments[6].SetActive(true);
            }
            if (hitMonument.collider.gameObject.tag == "StandToTheDeath")
            {
                monuments[7].SetActive(true);
            }
            if (hitMonument.collider.gameObject.tag == "T34")
            {
                monuments[8].SetActive(true);
            }
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

}
