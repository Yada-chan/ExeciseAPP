using System;
using System.Collections.Generic;
using UnityEngine;

public class TotalResultSaver : MonoBehaviour
{
    public List<SimpleCounter> counters; // �J�E���^���蓮�Őݒ�
    public GameManager gameManager; // GameManager�X�N���v�g���Q��

    private const string CaraPointKey = "CaraPointValue";


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


        // GameManager�̃|�C���g�Ƃ��Ă��ۑ�
        int previousTotal = PlayerPrefs.GetInt(key, 0); // �L�[�����݂��Ȃ��ꍇ��0��Ԃ�
        int newTotal = previousTotal + totalResult;    // �V�������v���v�Z

        // PlayerPrefs�ɕۑ�
        PlayerPrefs.SetInt(key, newTotal);
        PlayerPrefs.Save();
        Debug.Log($"[TotalResultSaver] PlayerPrefs�ɐV�������v��ۑ����܂���: {newTotal}");

        // GameManager�ɕۑ�
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Point = newTotal;
            PlayerPrefs.SetInt("GameManagerPoints", GameManager.Instance.Point); // PlayerPrefs�ɕۑ�
            PlayerPrefs.Save();
            Debug.Log($"[TotalResultSaver] GameManager�̃|�C���g���X�V����A�ۑ�����܂���: {GameManager.Instance.Point}");

            // gameManager���m�F���čX�V
            if (gameManager == null)
            {
                gameManager = GameManager.Instance; // �K�v�ł����gameManager�ɃC���X�^���X�����蓖��
            }

            if (gameManager != null)
            {
                gameManager.Point = newTotal;
                Debug.Log($"[TotalResultSaver] gameManager�̃|�C���g���X�V����܂���: {gameManager.Point}");
                // ���x����ۑ�
                PlayerPrefs.SetInt(CaraPointKey, gameManager.Point); // ���x����ۑ�
                PlayerPrefs.Save(); // �����ۑ�
            }
            else
            {
                Debug.LogError("[TotalResultSaver] gameManager���ݒ肳��Ă��܂���I");
            }
        }
        else
        {
            Debug.LogError("[TotalResultSaver] GameManager�̃C���X�^���X��������܂���I");
        }

        // �ڍׂȃf�o�b�O�������O�ɏo��
        Debug.Log($"Saved TotalResult on {currentDateTime.ToString("yyyy�NM��d��")}: {newTotal}�|�C���g");
    }
}
