using System;
using UnityEngine; // 必ず追加
using System.Collections.Generic;
using System.Diagnostics;

public class GameManager
{
    // Singletonインスタンス
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    // privateなゲーム変数
    private int level = 1;
    private int point = 0;
    private int[] cara_kcal = new int[10];
    private int[] item = new int[5];


    // 運動データを管理する辞書
    private Dictionary<int, Dictionary<string, int>> muscle = new Dictionary<int, Dictionary<string, int>>();

     // キャラ情報を管理する辞書
    private Dictionary<int, (string caraName, int cara_level)> characterData = new Dictionary<int, (string, int)>();

    private DateTime stated_date; // ゲームを始めた日
    private int date;             // ゲームを始めてからの経過日数

    // コンストラクタ（初期化処理）
    private GameManager()
    {
        // 初回起動時のデータを設定
        if (PlayerPrefsWrapper.HasKey("StatedDate"))
        {
            long binaryDate = Convert.ToInt64(PlayerPrefsWrapper.GetString("StatedDate"));
            stated_date = DateTime.FromBinary(binaryDate);
        }
        else
        {
            stated_date = DateTime.Now;
            PlayerPrefsWrapper.SetString("StatedDate", stated_date.ToBinary().ToString());
        }

        UpdateDate();
    }

    // 経過日数を更新
    private void UpdateDate()
    {
        date = (DateTime.Now - stated_date).Days;
    }

    // 運動記録を取得するメゾット
    public Dictionary<string, int> GetMuscle(int date)
    {
        if (muscle.ContainsKey(date))
        {
            return muscle[date];
        }
        return new Dictionary<string, int>();
    }
    // 運動記録を設定または更新するメゾット
    public void SetMuscle(int date, string exerciseType, int count)
    {
        if (!muscle.ContainsKey(date))
        {
            muscle[date] = new Dictionary<string, int>();
        }

        if (muscle[date].ContainsKey(exerciseType))
        {
            muscle[date][exerciseType] += count; // 回数を追加
        }
        else
        {
            muscle[date][exerciseType] = count; // 新しい運動を登録
        }
    }

        // キャラデータを取得するメソッド
    public (string caraName, int cara_level) GetCharacterData(int caraNum)
    {
        if (characterData.ContainsKey(caraNum))
        {
            return characterData[caraNum];
        }

        return ("Unknown", 0); // デフォルト値
    }

    // キャラデータを設定または更新するメソッド
    public void SetCharacterData(int caraNum, string caraName, int cara_level)
    {
        characterData[caraNum] = (caraName, cara_level);
    }


    // Getter for stated_date
    public DateTime GetStatedDate() => stated_date;

    // Getter for date (経過日数)
    public int GetDate()
    {
        UpdateDate();
        return date;
    }
}