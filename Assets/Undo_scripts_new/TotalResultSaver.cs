using System;
using System.Collections.Generic;
using UnityEngine;

public class TotalResultSaver : MonoBehaviour
{
    public List<SimpleCounter> counters; // カウンタを手動で設定
    public GameManager gameManager; // GameManagerスクリプトを参照

    private const string CaraPointKey = "CaraPointValue";
    private int point;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameManager.Instance; // GameManagerのインスタンスを取得
        }

        if (gameManager == null)
        {
            Debug.LogError("[TotalResultSaver] GameManagerのインスタンスが見つかりません！");
        }
        else
        {
            RestoreChara_Point();
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

    public void SaveTotalResult()
    {
        int totalResult = 0; // 合計結果を初期化
        foreach (SimpleCounter counter in counters) // 各カウンタの結果を合計
        {
            totalResult += counter.GetResult();
        }
        Debug.Log($"Total result: {totalResult}"); // 合計結果をデバッグログに出力

        // 運動記録として保存
        DateTime currentDateTime = DateTime.Now; // 現在の年、月、日を取得
        string key = currentDateTime.ToString("yyyyMMdd"); // 年月日をキーとして使う

        int previousTotal = PlayerPrefs.GetInt(key, 0); // キーが存在しない場合は0を返す
        int newTotal = previousTotal + totalResult;    // 新しい合計を計算(一日分のポイント合計）

        RestoreChara_Point();

        point += totalResult;

        // PlayerPrefsに保存
        PlayerPrefs.SetInt(key, newTotal);
        PlayerPrefs.Save();
        Debug.Log($"[TotalResultSaver] PlayerPrefsに新しい合計を保存しました: {newTotal}");

        // GameManagerに保存
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Point = newTotal;
            PlayerPrefs.SetInt("GameManagerPoints", GameManager.Instance.Point); // PlayerPrefsに保存
            PlayerPrefs.Save();
            Debug.Log($"[TotalResultSaver] GameManagerのポイントが更新され、保存されました: {GameManager.Instance.Point}");

            // gameManagerを確認して更新
            if (gameManager == null)
            {
                gameManager = GameManager.Instance; // 必要であればgameManagerにインスタンスを割り当て
            }

            if (gameManager != null)
            {
                gameManager.Point = point;
                Debug.Log($"[TotalResultSaver] gameManagerのポイントが更新されました: {gameManager.Point}");
                // ポイントを保存
                PlayerPrefs.SetInt(CaraPointKey, gameManager.Point); // ポイントを保存
                PlayerPrefs.Save(); // 即時保存
            }
            else
            {
                Debug.LogError("[TotalResultSaver] gameManagerが設定されていません！");
            }
        }
        else
        {
            Debug.LogError("[TotalResultSaver] GameManagerのインスタンスが見つかりません！");
        }

        // 詳細なデバッグ情報をログに出力
        Debug.Log($"Saved TotalResult on {currentDateTime.ToString("yyyy年M月d日")}: {newTotal}ポイント");
    }
}
