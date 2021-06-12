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
    /// ��һ������
    /// </summary>
    void GuidStep1()
    {
        Debug.Log("<color=red>��ʼ��һ������</color>");
        //��������Mask
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
        Debug.Log("�ڶ�������");
        SetMaskAndBtnHiglight(btn_menue1, btn_menue2);
    }
    //void GuidStep3()
    //{
    //    Debug.Log("����������");
    //    SetMaskAndBtnHiglight(btn_menue2, loginPanel.btn_login);
    //}
    /// <summary>
    /// ��ԭ��һ������
    /// ������һ������
    /// </summary>
    /// <param name="lastBtn">��һ��������ť</param>
    /// <param name="nextStep">��һ��������ť</param>
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
        Debug.Log("<color=red>�������</color>");
        Destroy(mask);
    }
}