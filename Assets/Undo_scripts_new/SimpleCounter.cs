using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleCounter : MonoBehaviour
{
    public Text countText; // �J�E���g��\������UI
    public Text resultText; // �|���Z���ʂ�\������UI
    private int count = 0; // �J�E���g�̏����l
    private int multiplier = 5; // �C�ӂ̐��l�i������Őݒ�j

    void Start()
    {
        UpdateDisplay(); // �����\�����X�V
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
        countText.text = count.ToString(); // �J�E���g��UI�ɕ\��
    }
}
