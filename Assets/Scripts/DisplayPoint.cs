using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPoint : MonoBehaviour
{
    public Text PointText; // Textコンポーネント
    public GameManager gameManager; // GameManagerスクリプト

    private int point=0; //RestoreChara_Point(); 変数保持

    private const string CaraPointKey = "CaraPointValue"; //    ポイントの保存キー
    public SaveDataDeleter saveDataDeleter;
    void Start()
    {
        gameManager = GameManager.Instance;  // GameManagerインスタンスを取得
        RestoreChara_Point();                // PlayerPrefsからポイントを復元
        UpdatePointText();                   // 初期表示
        Debug.Log($"[DisplayPoint] デバッグ:現在の値 = {gameManager.Point}"); // 確認ログ
    }



    void Update()
    {

 
                RestoreChara_Point();
                UpdatePointText();
        // デバッグ用: PキーでCaraKcalを10増加
            if (Input.GetKeyDown(KeyCode.P))
            {
                
                gameManager.Point += 10;
                // レベルを保存
                PlayerPrefs.SetInt(CaraPointKey,gameManager.Point); // レベルを保存
                PlayerPrefs.Save(); // 即時保存
                Debug.Log("デバック：ポイント追加　現在の値 = " + gameManager.Point);
                point=gameManager.Point;
                UpdatePointText();

        }
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
