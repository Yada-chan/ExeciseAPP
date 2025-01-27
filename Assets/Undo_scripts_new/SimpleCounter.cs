using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCounter : MonoBehaviour
{
    public Text countText; // �J�E���g��\������UI
    private int count = 0; // �J�E���g�̏����l
    public int multiplier = 5; // �C�ӂ̐��l�i������Őݒ�j

    void Start()
    {
        UpdateDisplay(); // �����\�����X�V
    }

    public void Increment()//�J�E���^���v���X����֐�
    {
        count++;//�J�E���g�{�P
        Debug.Log($"Count incremented to: {count}");
        UpdateDisplay();//�J�E���g�����X�V�A�\��
    }

    public void Decrement()//�J�E���^���}�C�i�X����֐�
    {
        if (count > 0)//�J�E���^���O�o�Ȃ���Ό��炷
        {
            count--;//�J�E���g�[�P
            Debug.Log($"Count decremented to: {count}");
        }
        else
        {
            Debug.Log("Count is already at zero.");//���ɉ������Ȃ����ߕ�����₷���悤�Ƀf�o�b�O�\��
        }

        UpdateDisplay();// �J�E���g�����X�V�A�\��
    }

    public void MultiplyCount()//�|�C���g�v�Z�֐�
    {
        int result = count * multiplier;//�J�E���g����񓖂���̃|�C���g
        Debug.Log($"Multiplication result: {count} * {multiplier} = {result}");
    }

    private void UpdateDisplay()
    {
        countText.text = count.ToString(); // �J�E���g��UI�ɕ\��
    }

    public int GetResult()//���U���g�̎擾
    {
        return count * multiplier;//�ꍀ�ڂ̍��v��Ԃ�
    }
}

