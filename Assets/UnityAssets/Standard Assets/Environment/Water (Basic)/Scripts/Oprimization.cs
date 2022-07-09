using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oprimization : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] game;

    private void Start()
    {
        
      
    }
    void Opt(GameObject[] gm)
    {
        for (int i = 0; i < gm.Length; i++)
        {
            if(gm[i].active == true && (i % 3 == 0 || i %5 ==0))
                gm[i].SetActive(false);
        
        }
    }
    private void FixedUpdate()
    {
        Opt(game);
        
    }
}
