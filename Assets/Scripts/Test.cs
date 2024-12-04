using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // DateTimeを使用するために必要

public class Test : MonoBehaviour
{
  void Start()
    {
        // ゲーム開始日を取得
        DateTime startDate = GameManager.Instance.GetStatedDate();
        Debug.Log($"Game Started On: {startDate}");

        // 経過日数を取得
        int elapsedDays = GameManager.Instance.GetDate();
        Debug.Log($"Days Since Game Started: {elapsedDays}");

        var gameManager = GameManager.Instance;

        // 運動データの設定 (例: 1日目)
        gameManager.SetMuscle(1, "腹筋", 20);  // 1日目に腹筋を20回
        gameManager.SetMuscle(1, "ウォーキング", 30); // 1日目にウォーキングを30分
        gameManager.SetMuscle(2, "ラジオ体操", 15); // 2日目にラジオ体操を15回

        // 運動データの取得と表示
        var day1Muscle = gameManager.GetMuscle(1);
        var day2Muscle = gameManager.GetMuscle(2);

        // 1日目の運動データを表示
    Debug.Log("Day 1の運動:");
    foreach (var exercise in day1Muscle)
    {
        Debug.Log($"{exercise.Key}: {exercise.Value}回");
    }

    // 2日目の運動データを表示
    Debug.Log("\nDay 2の運動:");
    foreach (var exercise in day2Muscle)
    {
        Debug.Log($"{exercise.Key}: {exercise.Value}回");
    }

    
    // キャラクターデータの設定
        gameManager.SetCharacterData(1, "Hero", 10);
        gameManager.SetCharacterData(2, "Villain", 20);
        gameManager.SetCharacterData(3, "Sidekick", 5);

    // 特定のキャラデータを取得して出力
        for (int i = 1; i <= 3; i++)
        {
            var character = gameManager.GetCharacterData(i);
            Debug.Log($"Number: {i}, Name: {character.caraName}, Level: {character.cara_level}");
        }
    }
}
