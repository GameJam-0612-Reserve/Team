using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAniClips : MonoBehaviour
{
    #region ���ֹؿ� ���� 
    //Step1 ��� ����1 
    //Step2 ��� ����2
    //(2.1) �ȴ� ���� 1 2 ����ѧϰ���
    //Step3 ��ק ����1 �� ���� 
    //Step4 ��ק ����2 �� ���� 
    //(5) �����ӿ����� ͨ����ʾ
    #endregion

    [Header("Ŀǰ����")]
    public int currentStep;
    public bool step1Done;
    public bool step2Done;
    public bool step3Done;
    public bool step4Done;

    //Hieranchy ��� �������еĶ��� �� ���� ��ק����
    [Header("��������Ʒ")]
    public GameObject animal01;
    public GameObject animal02;
    public GameObject slot01;
    public GameObject slot02;

    //�����ж�����ק����
    public GameObject[] allAnimator;
    public GameObject currentAnimator;

    void Start()
    {
        //Ĭ�ϲ�������
        step1Done = step2Done = step3Done = step4Done = false;
        //Ĭ�ϼ����еĶ���
        currentAnimator = allAnimator[0];
        ActiveAnimator(CheckCurrentStep());

    }

    void Update()
    {
        ActiveAnimator(CheckCurrentStep());

    }

    //����CheckCurrentStep() ֻ���ǰ������ʾ����
    void ActiveAnimator(int activatedAnimator)
    {
        //�������� ��ʾ��ǰ�׶�
        currentStep = activatedAnimator + 1;

        if (activatedAnimator >= 0 && activatedAnimator < allAnimator.Length)
            currentAnimator = allAnimator[activatedAnimator];
        else
            currentAnimator = null;

        foreach (var item in allAnimator)
        {
            if (item == currentAnimator)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }

    //���յ�ǰ��ɶ� ������Ҫ����Ķ����±�
    int CheckCurrentStep()
    {
        if (step1Done)
        {
            Debug.Log(1);
            if (step2Done)
            {
                Debug.Log(2);

                if (step3Done)
                {
                    Debug.Log(3);

                    if (step4Done)
                    {
                        Debug.Log(4);

                        //���ųɹ���ʾ��
                        return 4;
                    }
                    //���ŵ��ĸ�����
                    return 3;
                }
                step4Done = false;
                //���ŵ���������
                return 2;
            }
            step3Done = step4Done = false;
            //���ŵڶ�������
            return 1;
        }
        step2Done = step3Done = step4Done = false;
        //���ŵ�һ������
        return 0;
    }
}
