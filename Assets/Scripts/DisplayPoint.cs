using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPoint : MonoBehaviour
{
    public Text PointText; // Textコンポーネント
    public GameManager gameManager; // GameManagerスクリプト

    private int point=0; // 変数保持
    void Start()
    {
        gameManager = GameManager.Instance;
        UpdatePointText(); // 初期表示
    }

    
    void Update()
    {
        point=gameManager.Point;
        UpdatePointText();

        // デバッグ用: PキーでCaraKcalを10増加
            if (Input.GetKeyDown(KeyCode.P))
            {
                gameManager.Point += 10;
                Debug.Log("デバック：ポイント追加　現在の値 = " + gameManager.Point);
            }
    }

    void UpdatePointText()
    {
        if (PointText != null)
    {
        PointText.text = point.ToString();// 変数をTextに反映
    }
    else
    {
        Debug.LogError("PointText is not assigned!");
    }
    }
}
