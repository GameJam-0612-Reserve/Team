using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class LoginGuid : MonoBehaviour
{
    public GameObject prb_mask;
    public GameObject btn_menue1;
    public GameObject btn_menue2;
    private GameObject mask;
    //public LoginPanelView loginPanel;
    public static Action GuidCallback;
    // Use this for initialization
    void Start()
    {
        GuidCallback += GuidFinsih;
        //EventTriggerListener.GetListener(btn_menue1).onPointerClick += go =>
        //        {
        //            //            if (loginPanel != null)
        //            //            {
        //            //                loginPanel.gameObject.SetActive(true);
        //            GuidStep2();
        //            //}
        //            //            else
        //            //                Debug.LogError("panel_login is not found!");
        //        };
        ////EventTriggerListener.GetListener(btn_menue2).onPointerClick += go =>
        ////        {
        ////            GuidStep3();
        ////        };
        GuidStep1();

    }
    /// <summary>
    /// 第一步引导
    /// </summary>
    void GuidStep1()
    {
        Debug.Log("<color=red>开始第一步引导</color>");
        //创建遮罩Mask
        mask = Instantiate(prb_mask) as GameObject;
        mask.transform.parent = this.gameObject.transform;
        mask.transform.localPosition = Vector3.zero;
        mask.transform.localScale = Vector3.one;
        mask.transform.SetAsLastSibling();
        btn_menue1.AddComponent<Canvas>().overrideSorting = true;
        SetMaskAndBtnHiglight(null, btn_menue1);
    }
    void GuidStep2()
    {
        Debug.Log("第二步引导");
        SetMaskAndBtnHiglight(btn_menue1, btn_menue2);
    }
    //void GuidStep3()
    //{
    //    Debug.Log("第三步引导");
    //    SetMaskAndBtnHiglight(btn_menue2, loginPanel.btn_login);
    //}
    /// <summary>
    /// 还原上一个引导
    /// 设置下一个引导
    /// </summary>
    /// <param name="lastBtn">上一个引导按钮</param>
    /// <param name="nextStep">下一个引导按钮</param>
    void SetMaskAndBtnHiglight(GameObject lastStep, GameObject nextStep)
    {
        if (lastStep)
        {
            lastStep.GetComponent<Canvas>().overrideSorting = false;
            Destroy(lastStep.GetComponent<GraphicRaycaster>());
        }
        Canvas nextCanvas = nextStep.GetComponent<Canvas>();
        if (nextCanvas)
            nextCanvas.overrideSorting = true;
        else
            nextStep.AddComponent<Canvas>().overrideSorting = true;
        nextStep.AddComponent<GraphicRaycaster>();
    }
    void GuidFinsih()
    {
        Debug.Log("<color=red>引导完成</color>");
        Destroy(mask);
    }
}