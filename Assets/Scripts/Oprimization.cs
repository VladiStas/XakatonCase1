using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oprimization : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] game;
    int[] numbers;

    
    
    public virtual void Opt(GameObject[] gm)
    {
        for (int i = 0; i < gm.Length; i++)
        {
            if(gm[i].active == true && (IF(i,3) || IF(i,5)))
                gm[i].SetActive(false);
        
        }
    }

    public virtual bool IF(int ii, int num)
    {
        if (ii % num == 0)
            return true;
        else { return false; }
    }
    private void FixedUpdate()
    {
        Opt(game);
        
    }
}
