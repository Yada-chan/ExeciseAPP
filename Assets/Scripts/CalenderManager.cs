using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CalenderManager : MonoBehaviour
{
    ///<summary>
    ///�I�u�W�F�N�g�E�R���|�[�l���g
    ///</summary>

    //�p�u���b�N
    [Header("�J�����_�[�g")]
    public GameObject calender;
    [Header("�J�����_�[�̔N���e�L�X�g")]
    public GameObject calenderDate;
    [Header("���t�v���n�u")]
    public GameObject dayPanel;

    //�v���C�x�[�g
    private Text calenderDateText = null;
    private Image[] dayButtonColor = new Image[42];
    private Text[] dayText = new Text[42];

    ///<summary>
    ///�e��ϐ�
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
        // �J�����_�[�̔N����\������
        calenderDateText = calenderDate.GetComponent<Text>();
        calenderDateText.text = firstDay.ToString("yyyy�NM��");

        CreateDayPanel();
        SetCalenderDate();
    }

    private void GetTheDate()
    {
        DateTime temp = DateTime.Now.Date;
        firstDay = new DateTime(temp.Year, temp.Month, 1);
        nextMonth = firstDay.AddMonths(1);
    }

    // ���t�p�l�����쐬����
    private void CreateDayPanel()
    {
        Debug.Log("CalledCreateDayPanel");
        for (int i = 0; i < 42; i++)
        {
            GameObject createButton = Instantiate(dayPanel);
            createButton.transform.SetParent(calender.transform, false);
            dayButtonColor[i] = createButton.GetComponent<Image>();
            dayText[i] = createButton.transform.GetChild(0).GetComponent<Text>();
            createButton.SetActive(false); // ������ԂŔ�A�N�e�B�u�ɐݒ�
            Debug.Log(i);

        }
    }
    // �J�����_�[�̓��t�����Z�b�g����
    private void SetCalenderDate()
    {
        DayOfWeek firstWeek = firstDay.DayOfWeek;
        int diff = (firstWeek == DayOfWeek.Sunday) ? 0 : -(int)firstWeek + 1;
        firstPoint = firstDay.AddDays(diff);

        for (int i = 0; i < 42; i++)
        {
            DateTime temp = firstPoint.AddDays(i);
            dayText[i].transform.parent.gameObject.SetActive(true); // �p�l�����A�N�e�B�u�ɐݒ�

            if (temp.Month != firstDay.Month)
            {
                dayText[i].text = temp.Day.ToString();
                dayButtonColor[i].color = gray;
            }
            else
            {
                dayText[i].text = temp.Day.ToString();
                dayButtonColor[i].color = Color.white;
            }

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
        }

    }

    public void ChangeMonth(int month)
    {
        Debug.Log("ChangeMonth called with argument: " + month);

        firstDay = firstDay.AddMonths(month);
        nextMonth = firstDay.AddMonths(1);
        calenderDateText.text = firstDay.ToString("yyyy�NM��");

        // �����̃p�l�����A�N�e�B�u�ɂ���
        foreach (Transform child in calender.transform)
        {
            child.gameObject.SetActive(false);
        }

        SetCalenderDate();
    }
}
