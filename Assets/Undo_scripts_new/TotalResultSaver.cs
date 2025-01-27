using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalResultSaver : MonoBehaviour
{
    public List<SimpleCounter> counters; // �J�E���^���蓮�Őݒ�

    // ���v���ʂ��v�Z���A�ۑ����郁�\�b�h
    public void SaveTotalResult()
    {
        int totalResult = 0; // ���v���ʂ�������
        foreach (SimpleCounter counter in counters) // �e�J�E���^�̌��ʂ����v
        {
            totalResult += counter.GetResult();
        }
        Debug.Log($"Total result: {totalResult}"); // ���v���ʂ��f�o�b�O���O�ɏo��

        // �^���L�^�Ƃ��ĕۑ�
        DateTime currentDateTime = DateTime.Now; // ���݂̔N�A���A�����擾
        string key = currentDateTime.ToString("yyyyMMdd"); // �N�������L�[�Ƃ��Ďg��
        PlayerPrefs.SetInt(key, totalResult); // PlayerPrefs�ɕۑ�
        PlayerPrefs.Save(); // �ύX��ۑ�

        // �ڍׂȃf�o�b�O�������O�ɏo��
        Debug.Log($"Saved TotalResult on {currentDateTime.ToString("yyyy�NM��d��")}: {totalResult}�|�C���g");
    }
}




