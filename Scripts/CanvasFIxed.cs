using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFIxed : MonoBehaviour
{
    private Canvas canvas;
    private RectTransform rectTransform;
    void Start()
    {
        canvas = GetComponent<Canvas>(); 
        rectTransform = canvas.GetComponent<RectTransform>();
        
    }
    
    
    void Update()
    {
        rectTransform.anchoredPosition = new Vector2(0, 0); 
    }
}
