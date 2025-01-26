using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CounterManager : MonoBehaviour
{
    public List<SimpleCounter> counters; // 7�̃J�E���^���蓮�Őݒ�
    public List<Button> incrementButtons; // 7�̃v���X�{�^�����蓮�Őݒ�
    public List<Button> decrementButtons; // 7�̃}�C�i�X�{�^�����蓮�Őݒ�

    void Start()
    {
        // �v���X�{�^���̃C�x���g��ݒ�
        for (int i = 0; i < incrementButtons.Count; i++)
        {
            int index = i; // ���[�J���ϐ��ɃC���f�b�N�X��ێ�
            incrementButtons[i].onClick.AddListener(() => counters[index].Increment());
        }

        // �}�C�i�X�{�^���̃C�x���g��ݒ�
        for (int i = 0; i < decrementButtons.Count; i++)
        {
            int index = i; // ���[�J���ϐ��ɃC���f�b�N�X��ێ�
            decrementButtons[i].onClick.AddListener(() => counters[index].Decrement());
        }
    }

    public void MultiplyAllCounters()
    {
        foreach (SimpleCounter counter in counters)
        {
            counter.MultiplyCount();
        }
    }
}


