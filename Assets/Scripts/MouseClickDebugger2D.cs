using UnityEngine;


//メインカメラの位置は（0,0,-10）
public class MouseClickScreenPosition : MonoBehaviour
{
    void Update()
    {
        // 左クリックが押された瞬間を検知
        if (Input.GetMouseButtonDown(0))
        {
            // スクリーン座標を取得
            Vector3 screenPosition = Input.mousePosition;
            Debug.Log("スクリーン座標: " + screenPosition);
        }
    }
}
