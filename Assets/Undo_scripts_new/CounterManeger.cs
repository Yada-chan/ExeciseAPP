using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CounterManager : MonoBehaviour
{
    public List<SimpleCounter> counters; // 7つのカウンタを手動で設定
    public List<Button> incrementButtons; // 7つのプラスボタンを手動で設定
    public List<Button> decrementButtons; // 7つのマイナスボタンを手動で設定
    public Text totalResultText; // 合計結果を表示するテキスト

    void Start()
    {
        // プラスボタンのイベントを設定
        
        for (int i = 0; i < incrementButtons.Count; i++)//プラスボタンの数だけループする
        {
            int index = i;//iを保存
            incrementButtons[i].onClick.AddListener(() => {//クリックしたときのイベントを追加
                counters[index].Increment();//クリックされたカウンタを取得、インクリメントという関数を呼び出し、カウントを＋１する
                UpdateTotalResult();//合計を更新する関数を呼び出す
            });
        }

        // マイナスボタンのイベントを設定
        for (int i = 0; i < decrementButtons.Count; i++)
        {
            int index = i;//iを保存
            decrementButtons[i].onClick.AddListener(() => {//マイナスボタンの数だけループする
                counters[index].Decrement();//クリックされたカウンタを取得、デクリメントという関数を呼び出し、カウントを-１する
                UpdateTotalResult();//合計を更新する関数を呼び出す
            });
        }
    }

    public void UpdateTotalResult()
    {
        int totalResult = 0;
        foreach (SimpleCounter counter in counters)//配列[0]から順番に[N]まで処理する（繰り返す）
        {
            totalResult += counter.GetResult();//カウンタ１からカウンタ７まで順番に合計を足す
        }
        totalResultText.text = totalResult.ToString();//合計表示
        Debug.Log($"Total result: {totalResult}");
    }

    public void MultiplyAllCounters()
    {
        foreach (SimpleCounter counter in counters)
        {
            counter.MultiplyCount();//カウンタの数＊ポイントを計算する関数
        }
    }
}
