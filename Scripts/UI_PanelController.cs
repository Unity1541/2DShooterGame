using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
public class UI_PanelController : MonoBehaviour
{
    public GameObject []panels;
    public void ShowPanel(int panelNumber)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == panelNumber)
            {
                panels[i].SetActive(true); // 啟用指定面板
            }
           
        }
    }

    public void ClosePanel(int panelNumber)
    {
         for (int i = 0; i < panels.Length; i++)
        {
            if (i == panelNumber)
            {
                panels[i].SetActive(false); // 啟用指定面板
            }
        }
    }
}
