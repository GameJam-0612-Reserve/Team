using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAniClips : MonoBehaviour
{
    #region 新手关卡 引导 
    //Step1 点击 动物1 
    //Step2 点击 动物2
    //(2.1) 等待 动物 1 2 交流学习完成
    //Step3 拖拽 动物1 到 格子 
    //Step4 拖拽 动物2 到 格子 
    //(5) 两格子可连接 通关提示
    #endregion

    [Header("目前步数")]
    public int currentStep;
    public bool step1Done;
    public bool step2Done;
    public bool step3Done;
    public bool step4Done;

    //Hieranchy 面板 将场景中的动物 和 格子 拖拽至此
    [Header("交互的物品")]
    public GameObject animal01;
    public GameObject animal02;
    public GameObject slot01;
    public GameObject slot02;

    //将所有动画拖拽至此
    public GameObject[] allAnimator;
    public GameObject currentAnimator;

    void Start()
    {
        //默认步数归零
        step1Done = step2Done = step3Done = step4Done = false;
        //默认激活中的动画
        currentAnimator = allAnimator[0];
        ActiveAnimator(CheckCurrentStep());

    }

    void Update()
    {
        ActiveAnimator(CheckCurrentStep());

    }

    //输入CheckCurrentStep() 只激活当前步骤提示动画
    void ActiveAnimator(int activatedAnimator)
    {
        //仅测试用 显示当前阶段
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

    //按照当前完成度 返回需要激活的动画下标
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

                        //播放成功显示框？
                        return 4;
                    }
                    //播放第四个动画
                    return 3;
                }
                step4Done = false;
                //播放第三个动画
                return 2;
            }
            step3Done = step4Done = false;
            //播放第二个动画
            return 1;
        }
        step2Done = step3Done = step4Done = false;
        //播放第一个动画
        return 0;
    }
}
