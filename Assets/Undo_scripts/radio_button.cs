using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radio_button : MonoBehaviour
{
    public Text textField;
    public const int lower_limit = 0;
    private int count;

    void Start()
    {
        count = 0;
        textField.text = count.ToString();
    }

    public void CountButton_increase()
    {
        count++;
        textField.text = count.ToString();
    }

    public void CountButton_reduse()
    {
        count--;
        if (count <= lower_limit)
            count = 0;
        textField.text = count.ToString();
    }
}
