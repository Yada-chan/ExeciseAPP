using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CounterManager : MonoBehaviour
{
    public List<SimpleCounter> counters; // 7�̃J�E���^���蓮�Őݒ�
    public List<Button> incrementButtons; // 7�̃v���X�{�^�����蓮�Őݒ�
    public List<Button> decrementButtons; // 7�̃}�C�i�X�{�^�����蓮�Őݒ�
    public Text totalResultText; // ���v���ʂ�\������e�L�X�g

    void Start()
    {
        // �v���X�{�^���̃C�x���g��ݒ�
        
        for (int i = 0; i < incrementButtons.Count; i++)//�v���X�{�^���̐��������[�v����
        {
            int index = i;//i��ۑ�
            incrementButtons[i].onClick.AddListener(() => {//�N���b�N�����Ƃ��̃C�x���g��ǉ�
                counters[index].Increment();//�N���b�N���ꂽ�J�E���^���擾�A�C���N�������g�Ƃ����֐����Ăяo���A�J�E���g���{�P����
                UpdateTotalResult();//���v���X�V����֐����Ăяo��
            });
        }

        // �}�C�i�X�{�^���̃C�x���g��ݒ�
        for (int i = 0; i < decrementButtons.Count; i++)
        {
            int index = i;//i��ۑ�
            decrementButtons[i].onClick.AddListener(() => {//�}�C�i�X�{�^���̐��������[�v����
                counters[index].Decrement();//�N���b�N���ꂽ�J�E���^���擾�A�f�N�������g�Ƃ����֐����Ăяo���A�J�E���g��-�P����
                UpdateTotalResult();//���v���X�V����֐����Ăяo��
            });
        }
    }

    public void UpdateTotalResult()
    {
        int totalResult = 0;
        foreach (SimpleCounter counter in counters)//�z��[0]���珇�Ԃ�[N]�܂ŏ�������i�J��Ԃ��j
        {
            totalResult += counter.GetResult();//�J�E���^�P����J�E���^�V�܂ŏ��Ԃɍ��v�𑫂�
        }
        totalResultText.text = totalResult.ToString();//���v�\��
        Debug.Log($"Total result: {totalResult}");
    }

    public void MultiplyAllCounters()
    {
        foreach (SimpleCounter counter in counters)
        {
            counter.MultiplyCount();//�J�E���^�̐����|�C���g���v�Z����֐�
        }
    }
}
