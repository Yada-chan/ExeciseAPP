using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CounterManager : MonoBehaviour
{
    public List<SimpleCounter> counters; // 7つのカウンタを手動で設定
    public List<Button> incrementButtons; // 7つのプラスボタンを手動で設定
    public List<Button> decrementButtons; // 7つのマイナスボタンを手動で設定

    void Start()
    {
        // プラスボタンのイベントを設定
        for (int i = 0; i < incrementButtons.Count; i++)
        {
            int index = i; // ローカル変数にインデックスを保持
            incrementButtons[i].onClick.AddListener(() => counters[index].Increment());
        }

        // マイナスボタンのイベントを設定
        for (int i = 0; i < decrementButtons.Count; i++)
        {
            int index = i; // ローカル変数にインデックスを保持
            decrementButtons[i].onClick.AddListener(() => counters[index].Decrement());
        }
    }

    public void MultiplyAllCounters()
    {
        foreach (SimpleCounter counter in counters)
        {
            counter.MultiplyCount();
        }
    }
}


