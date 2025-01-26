using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CalenderManager : MonoBehaviour
{
    ///<summary>
    ///オブジェクト・コンポーネント
    ///</summary>

    //パブリック
    [Header("カレンダー枠")]
    public GameObject calender;
    [Header("カレンダーの年月テキスト")]
    public GameObject calenderDate;
    [Header("日付プレハブ")]
    public GameObject dayPanel;
    [Header("ポイント表示テキスト")]
    public Text pointsText; // 新しく追加するフィールド

    //プライベート
    private Text calenderDateText = null;
    private Image[] dayButtonColor = new Image[42];
    private Text[] dayText = new Text[42];

    ///<summary>
    ///各種変数
    ///</summary>

    private DateTime firstDay = DateTime.MinValue;
    private DateTime nextMonth = DateTime.MinValue;
    private DateTime firstPoint = DateTime.MinValue;

    private Color green = new Color(0f, 0.4f, 1f);
    private Color gray = new Color(0.9f, 0.9f, 0.9f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        GetTheDate();

        // カレンダーの年月を表示する
        calenderDateText = calenderDate.GetComponent<Text>();
        calenderDateText.text = firstDay.ToString("yyyy年M月");

        CreateDayPanel();

        // 全てのパネルを一度非アクティブにする
        foreach (Transform child in calender.transform)
        {
            child.gameObject.SetActive(false);
        }

        SetCalenderDate();
    }

    private void GetTheDate()
    {
        DateTime temp = DateTime.Now.Date;
        firstDay = new DateTime(temp.Year, temp.Month, 1);
        nextMonth = firstDay.AddMonths(1);
    }

    // 日付パネルを作成する
    private void CreateDayPanel()
    {
        Debug.Log("CalledCreateDayPanel");
        for (int i = 0; i < 42; i++)
        {
            GameObject createButton = Instantiate(dayPanel);
            createButton.transform.SetParent(calender.transform, false);
            dayButtonColor[i] = createButton.GetComponent<Image>();
            dayText[i] = createButton.transform.GetChild(0).GetComponent<Text>();
            int index = i; // インデックスをキャプチャする
            createButton.GetComponent<Button>().onClick.AddListener(() => OnDayButtonClick(index)); // クリックイベントを追加
            createButton.SetActive(false); // 初期状態で非アクティブに設定
            Debug.Log("Created day panel: " + i);
        }
        Debug.Log("Total panels created: " + calender.transform.childCount); // パネル数の確認
    }

    // カレンダーの日付をリセットする
    private void SetCalenderDate()
    {
        // カレンダーの最初の日の曜日を取得
        DayOfWeek firstWeek = firstDay.DayOfWeek;
        int diff = (firstWeek == DayOfWeek.Sunday) ? 0 : -(int)firstWeek;

        // 修正したポイント
        firstPoint = firstDay.AddDays(diff);

        for (int i = 0; i < 42; i++)
        {
            DateTime temp = firstPoint.AddDays(i);
            dayText[i].transform.parent.gameObject.SetActive(true); // パネルをアクティブに設定

            // 初期色を灰色に設定し、テキストをリセット
            dayButtonColor[i].color = gray;
            dayText[i].text = "";

            if (temp.Month == firstDay.Month)
            {
                dayText[i].text = temp.Day.ToString();
                dayButtonColor[i].color = Color.white;
            }

            // 曜日に応じたテキストカラーの設定
            switch (temp.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dayText[i].color = Color.red;
                    break;
                case DayOfWeek.Saturday:
                    dayText[i].color = Color.blue;
                    break;
                default:
                    dayText[i].color = green;
                    break;
            }

            Debug.Log("Day: " + temp.Day + ", Panel: " + i + ", Month: " + temp.Month + ", First Day Month: " + firstDay.Month);
        }
    }

    // 日付ボタンがクリックされたときに呼び出されるメソッド
    private void OnDayButtonClick(int index)
    {
        DateTime clickedDate = firstPoint.AddDays(index);
        string key = clickedDate.ToString("yyyyMMdd"); // 年月日をキーとして使う
        int dayPoints = PlayerPrefs.GetInt(key, 0); // PlayerPrefsからポイントを取得、存在しない場合は0

        // ポイント表示のテキストを改行を含めて設定
        pointsText.text = $"{clickedDate.ToString("yyyy年")}\n{clickedDate.ToString("M月d日")}\n{dayPoints}ポイント";

        Debug.Log($"Clicked day panel {index}: {clickedDate.ToString("yyyy年M月d日")}, Points: {dayPoints}");
    }




    public void ChangeMonth(int month)
    {
        Debug.Log("ChangeMonth called with argument: " + month);

        firstDay = firstDay.AddMonths(month);
        nextMonth = firstDay.AddMonths(1);
        calenderDateText.text = firstDay.ToString("yyyy年M月");

        // 既存のパネルを非アクティブにする
        foreach (Transform child in calender.transform)
        {
            child.gameObject.SetActive(false);
        }

        SetCalenderDate();
    }
}
