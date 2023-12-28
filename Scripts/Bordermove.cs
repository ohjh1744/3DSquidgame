using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bordermove : MonoBehaviour
{

    public bool g_start;
    bool b; //ÇÑ¹ø¸¸

    void Update()
    {
        if(g_start && !b)
        {
            disappear();
            b = true;
        }
    }

    void disappear()
    {
        gameObject.SetActive(false);
    }

}
