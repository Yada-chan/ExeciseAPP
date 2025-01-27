using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleCounter : MonoBehaviour
{
    public Text countText; // カウントを表示するUI
    public Text resultText; // 掛け算結果を表示するUI
    private int count = 0; // カウントの初期値
    private int multiplier = 5; // 任意の数値（こちらで設定）

    void Start()
    {
        UpdateDisplay(); // 初期表示を更新
    }

    public void Increment()
    {
        count++;
        Debug.Log($"Count incremented to: {count}");
        UpdateDisplay();
    }

    public void Decrement()
    {
        if (count > 0)
        {
            count--;
            Debug.Log($"Count decremented to: {count}");
        }
        else
        {
            Debug.Log("Count is already at zero.");
        }

        UpdateDisplay();
    }

    public void MultiplyCount()
    {
        int result = count * multiplier;
        resultText.text = result.ToString();
        Debug.Log($"Multiplication result: {count} * {multiplier} = {result}");
    }

    private void UpdateDisplay()
    {
        countText.text = count.ToString(); // カウントをUIに表示
    }
}
