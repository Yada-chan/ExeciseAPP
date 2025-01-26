using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCounter : MonoBehaviour
{
    public Text countText; // カウントを表示するUI
    private int count = 0; // カウントの初期値
    public int multiplier = 5; // 任意の数値（こちらで設定）

    void Start()
    {
        UpdateDisplay(); // 初期表示を更新
    }

    public void Increment()//カウンタをプラスする関数
    {
        count++;//カウント＋１
        Debug.Log($"Count incremented to: {count}");
        UpdateDisplay();//カウント数を更新、表示
    }

    public void Decrement()//カウンタをマイナスする関数
    {
        if (count > 0)//カウンタが０出なければ減らす
        {
            count--;//カウントー１
            Debug.Log($"Count decremented to: {count}");
        }
        else
        {
            Debug.Log("Count is already at zero.");//特に何もしないため分かりやすいようにデバッグ表示
        }

        UpdateDisplay();// カウント数を更新、表示
    }

    public void MultiplyCount()//ポイント計算関数
    {
        int result = count * multiplier;//カウント＊一回当たりのポイント
        Debug.Log($"Multiplication result: {count} * {multiplier} = {result}");
    }

    private void UpdateDisplay()
    {
        countText.text = count.ToString(); // カウントをUIに表示
    }

    public int GetResult()//リザルトの取得
    {
        return count * multiplier;//一項目の合計を返す
    }
}

