using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sum_score : MonoBehaviour
{
    public static int sum = 0;

    public static void AddSum_radio(int value)
    {
        sum += value;
        Debug.Log(sum);
    }

    public static void Dec_Sum_radio(int value)
    {
        sum -= value;
        Debug.Log(sum);
    }

    // �ʂ̏ꏊ�Œ���sum�ɒl�������郁�\�b�h
    public static void AddToSum(int value)
    {
        sum += value;
        Debug.Log("Sum updated: " + sum);
    }

    public static void DecToSum(int value) 
    { 
        sum -= value; 
        Debug.Log("Sum updated: " + sum); 
    }
}

