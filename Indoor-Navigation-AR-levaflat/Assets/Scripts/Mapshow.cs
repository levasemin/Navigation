using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapshow : MonoBehaviour
{
    public GameObject map;
    private bool show = true;
    public void Show()
    {
        switch (show)
        {
            case true:
                show = false;
                map.gameObject.SetActive(show);
                break;
            case false:
                show = true;
                map.gameObject.SetActive(show);
                break;
        }
    }
}