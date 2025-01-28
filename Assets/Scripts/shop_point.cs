using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro を使用するための名前空間

public class Shop_Point : MonoBehaviour
{
    public TMP_Text PointText; // Textコンポーネント
    public GameManager gameManager; // GameManagerスクリプト

    private int point=0; // 変数保持
    private const string CaraPointKey = "CaraPointValue"; //    ポイントの保存キー

    void Start()
    {
        gameManager = GameManager.Instance;
        RestoreChara_Point();
        UpdatePointText(); // 初期表示
    }
    private void RestoreChara_Point()
    {
    // キャラクターデータの復元
        if (PlayerPrefs.HasKey(CaraPointKey))
        {
            gameManager.Point = PlayerPrefs.GetInt(CaraPointKey);
            point = gameManager.Point;
        }
        else
        {
            gameManager.Point = 0; // ポイントの初期値
            point = gameManager.Point;
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
