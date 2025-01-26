using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalResultSaver : MonoBehaviour
{
    public List<SimpleCounter> counters; // カウンタを手動で設定

    // 合計結果を計算し、保存するメソッド
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
        PlayerPrefs.SetInt(key, totalResult); // PlayerPrefsに保存
        PlayerPrefs.Save(); // 変更を保存

        // 詳細なデバッグ情報をログに出力
        Debug.Log($"Saved TotalResult on {currentDateTime.ToString("yyyy年M月d日")}: {totalResult}ポイント");
    }
}




