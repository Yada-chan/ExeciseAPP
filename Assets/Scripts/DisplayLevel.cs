using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// public Text levelText; // 通常の Text を使う場合はこちら


public class DisplayLevel : MonoBehaviour
{
    public Text levelText; // Textコンポーネント
    public GameManager gameManager; // GameManagerスクリプト
    private int threshold = 100; // レベルアップに必要なカロリー

    private int caraLevel=1;

    void Start()
    {
        gameManager = GameManager.Instance;
        UpdateLevelText(); // 初期表示
    }

    void Update()
    {
        // カロリーが閾値を超えた場合、レベルを上げる
        if (gameManager.CaraKcal[gameManager.NowCaraNum] >= threshold)
        {
            gameManager.UpdateCharacterLevel(gameManager.NowCaraNum);
            var caraDate=gameManager.GetCharacterData(gameManager.NowCaraNum);
            caraLevel = caraDate.cara_level;
            UpdateLevelText();
        }
    }

    void UpdateLevelText()
    {
        if (levelText != null)
    {
        levelText.text = caraLevel.ToString();// 変数をTextに反映
    }
    else
    {
        Debug.LogError("LevelText is not assigned!");
    }
    }
}
