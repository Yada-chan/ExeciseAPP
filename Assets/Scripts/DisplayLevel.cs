using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayLevel : MonoBehaviour
{
    public Text levelText; // Textコンポーネント
    public GameManager gameManager; // GameManagerスクリプト
    private int threshold = 100; // レベルアップに必要なカロリー

    private int level=1;

    void Start()
    {
        gameManager = GameManager.Instance;
        UpdateLevelText(); // 初期表示
    }

    void Update()
    {
        // カロリーが閾値を超えた場合、レベルを上げる
        if (gameManager.CaraKcal[0] >= threshold)
        {
            gameManager.Level++;
            level=gameManager.Level;
            UpdateLevelText();
        }
    }

    void UpdateLevelText()
    {
        if (levelText != null)
    {
        levelText.text = level.ToString();// 変数をTextに反映
    }
    else
    {
        Debug.LogError("LevelText is not assigned!");
    }
    }
}
