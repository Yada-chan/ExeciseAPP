using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonHundler : MonoBehaviour
{
    private GameManager gameManager; // GameManagerの参照を保持

    // アイテム名と対応するポイント減少量、およびアイテムインデックスを定義
    private readonly Dictionary<string, (int cost, int itemIndex)> itemData = new Dictionary<string, (int, int)>
    {
        { "orangejuice", (10, 0) },
        { "syokupan", (20, 1) },
        { "mayo", (50, 2) },
        { "meat", (50, 3) },
        { "cake", (50, 4) },
        { "cupra-men", (100, 5) },
        { "jiro", (500, 6) }
    };

    private void Start()
    {
        // GameManagerのインスタンスを取得
        gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManagerが見つかりません！シーン内にGameManagerを配置してください。");
        }

    }

    // ボタンが押されたときに呼び出される関数
    public void OnButtonPressed(string buttonName)
    {
        // ボタン名を正規化（小文字化、不要な引用符の除去）
        string normalizedButtonName = buttonName.Trim('"').Trim().ToLower();
        Debug.Log($"受け取ったボタン名（正規化後）: \"{normalizedButtonName}\"");

        if (itemData.TryGetValue(normalizedButtonName, out var data))
        {
            Debug.Log("ボタンが押されました: " + normalizedButtonName);
            // ポイントが足りる場合のみ処理
            if (gameManager.Point >= data.cost)
            {
                gameManager.Point -= data.cost;
                gameManager.Item[data.itemIndex]++;
                Debug.Log($"{normalizedButtonName} を購入しました。残りポイント: {gameManager.Point}");
            }
            else
            {
                Debug.Log($"ポイントが不足しています！");
            }
        }
        else
        {
            Debug.LogError($"不明なアイテム: \"{buttonName}\"");
        }
    }
}
