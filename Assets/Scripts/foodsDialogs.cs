using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // TextMeshProを使用するために追加

public class foodsDialogs : MonoBehaviour
{
    [System.Serializable] // インスペクターで編集可能にする
    public class SyouhinGroup
    {
        public GameObject syouhinGroupObject;
        public Button syouhinButton;
        public TextMeshProUGUI name;  // Text から TextMeshProUGUI に変更
        public TextMeshProUGUI count; // Text から TextMeshProUGUI に変更
    }

    public List<SyouhinGroup> syouhinGroups = new List<SyouhinGroup>();
    public GameObject popup;
    public Button popupOkButton;
    public Button popupCancelButton;
    public GameObject popupBackGround;

    private void Start()
    {
        if (syouhinGroups == null || syouhinGroups.Count == 0)
        {
            Debug.LogError("syouhinGroups が設定されていません。インスペクターで確認してください。");
            return;
        }

        foreach (var group in syouhinGroups)
        {
            if (group == null || group.syouhinButton == null)
            {
                Debug.LogError("syouhinGroups の中に null の要素があるか、syouhinButton が設定されていません。");
                continue;
            }

            group.syouhinButton.onClick.AddListener(() => ShowPopup(group));
        }

        if (popup == null || popupBackGround == null)
        {
            Debug.LogError("ポップアップ関連のオブジェクトが設定されていません。");
        }
        else
        {
            HidePopup();
        }
    }

    public void ShowPopup(SyouhinGroup selectedGroup)
    {
        if (selectedGroup == null || selectedGroup.count == null)
        {
            Debug.LogError("選択された商品グループが null か、count が設定されていません。");
            return;
        }
        
        popup.SetActive(true);
        popupBackGround.SetActive(true);

        popupOkButton.onClick.RemoveAllListeners();
        popupOkButton.onClick.AddListener(() =>
        {
            UseItem(selectedGroup);
            HidePopup();
        });

        popupCancelButton.onClick.RemoveAllListeners();
        popupCancelButton.onClick.AddListener(HidePopup);
    }

    public void HidePopup()
    {
        popup.SetActive(false);
        popupBackGround.SetActive(false);
    }

    private void UseItem(SyouhinGroup group)
    {
        if (group == null || group.count == null)
        {
            Debug.LogError("使用する商品グループが null です。");
            return;
        }

        if (int.TryParse(group.count.text, out int currentCount) && currentCount > 0)
        {
            currentCount--;
            group.count.text = currentCount.ToString();
        }
        else
        {
            Debug.LogWarning("商品在庫がないか、数値変換に失敗しました。");
        }
    }
}
