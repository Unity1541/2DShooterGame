using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    public RectTransform rectTransform;
    public Vector2 back_ground_Transform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        back_ground_Transform = this.rectTransform.anchoredPosition;
    }    
// 1.rectTransform.anchoredPosition:
// 相對位置：表示相對於父 RectTransform 的錨點（Anchor Point）的位置。
// 適用於 UI 元素：anchoredPosition 是用於 UI 元素的常見屬性，因為它通常是在 Canvas 中處理相對於父元素的偏移量。
// 2D 平面（x 和 y）：只考慮 2D 平面的 x 和 y 軸，不包含 z 軸。
// 用於調整 UI 位置：適合用來調整 UI 元素在父容器中的相對位置。

// 2.rectTransform.position:
// 世界座標：表示 UI 元素在世界空間中的絕對位置。
// 包含 z 軸：它包含了 x、y 和 z 軸的位置。
// 用於一般空間定位：如果需要在世界座標中定位一個 UI 元素（例如在 3D 空間中放置 UI 元素），position 更適合。
// 使用時機
// anchoredPosition：當你需要設定或獲取 UI 元素在 Canvas 或父物件中的相對位置時。
// position：當你需要知道 UI 元素在整個世界空間中的絕對位置時，這通常適用於混合 3D 物件和 UI 的情境。

    void Update()
    {
        if (rectTransform.anchoredPosition.y<-950f)
        {
            this.rectTransform.anchoredPosition = back_ground_Transform;
        }
    }
}
