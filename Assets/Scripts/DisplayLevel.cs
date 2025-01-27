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
    private const string CaraLevelKey = "CaraLevelValue"; // レベルの保存キー

    void Start()
    {
        gameManager = GameManager.Instance;
        RestoreChara_Level();
        UpdateLevelText(); // 初期表示
    }

    void Update()
    {
        // 「Delete」キーが押されたらセーブデータを削除
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeleteSaveDataFunction();
            RestoreChara_Level();
            UpdateLevelText();
        }
        // カロリーが閾値を超えた場合、レベルを上げる
        if (gameManager.CaraKcal[gameManager.NowCaraNum] >= threshold)
        {
            gameManager.UpdateCharacterLevel(gameManager.NowCaraNum);
            var caraData=gameManager.GetCharacterData(gameManager.NowCaraNum);
            // ゲームデータを更新
            gameManager.SetCharacterData(gameManager.NowCaraNum, caraData.caraName, caraData.cara_level); // 更新されたデータを戻す
            // レベルを保存
            PlayerPrefs.SetInt(CaraLevelKey, caraData.cara_level); // レベルを保存
            PlayerPrefs.Save(); // 即時保存

            caraLevel = caraData.cara_level;
            UpdateLevelText();
        }
    }

    void DeleteSaveDataFunction()
    {
        // セーブデータを削除する
        if (PlayerPrefs.HasKey(CaraLevelKey))
        {
            PlayerPrefs.DeleteKey(CaraLevelKey);
            PlayerPrefs.Save(); // 即時保存
            Debug.Log("Level Save data deleted.");
        }
        else
        {
            Debug.Log("No save data found to delete.");
        }
    }

    private void RestoreChara_Level()
    {
    // キャラクターデータの復元
        var caraData = gameManager.GetCharacterData(gameManager.NowCaraNum);
        if (PlayerPrefs.HasKey(CaraLevelKey))
        {
            caraData.cara_level = PlayerPrefs.GetInt(CaraLevelKey);
            caraLevel = caraData.cara_level;
        }
        else
        {
            caraData.cara_level = 1; // レベルの初期値
            caraLevel = caraData.cara_level;
        }

        // 初期データをセット
        gameManager.SetCharacterData(gameManager.NowCaraNum, caraData.caraName, caraData.cara_level);
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


