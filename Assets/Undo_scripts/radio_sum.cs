using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnotherScript : MonoBehaviour
{
    void Start()
    {
        // �Ⴆ�΁A����������100��������
        sum_score.AddToSum(100);

        // ���̑���ɉ����Ēl��������
        sum_score.DecToSum(100);
    }


}
