using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorAnimalClass : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerClickHandler,IPointerUpHandler
{
    #region 教程专用动物类 与正式游戏不同
    //外部获取动物 是否被选中 进行阶段判断 两个都选中 进行下阶段提示
    //外部获取动物 身上是否有第二语言
    //接收外部信息 Learn(对方母语) 改变自身第二语言栏状态
    //传送信息 Teach() 
    //拖拽物体方法

    #endregion

    [Header("当前动物状态")]
    public bool isChosen;   //被选中 等待匹配
    public Transform UpperArea;

    [Header("在场生物")]
    public Transform animal;

    [Header("当前动物身上的语言栏状态")]
    public int firstLanguageID;
    public GameObject motherLanguage;
    public GameObject language_2nd;

    Sprite mysprite;

    private Vector2 offsetPos;

    //物体是否在移动
    bool isMoving;
    bool isLearning;


    //拖拽物体
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position - offsetPos;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = eventData.position - (Vector2)transform.position;
    }

    //点击触发 
    public void OnPointerClick(PointerEventData eventData)
    {
        //取反
        this.isChosen = !isChosen;
        if (animal.GetComponent<TutorAnimalClass>().isChosen && isChosen)
        {
            isMoving = true;
            animal.GetComponent<TutorAnimalClass>().isMoving = true;

            //满足两个均被选中条件 拉近距离 进行 Learn()
            //direction = animal.GetComponent<RectTransform>().anchoredPosition - GetComponent<RectTransform>().anchoredPosition;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Slot"))
        {
            transform.SetParent(collision.transform);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("Slot"))
        {
            transform.SetParent(UpperArea);

        }

    }





    void Start()
    {

    }

    void Update()
    {
        if (isMoving)
        {
            //移动向对方
            GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(GetComponent<RectTransform>().anchoredPosition, animal.GetComponent<RectTransform>().anchoredPosition, 2f);
            //Debug.Log(Vector2.Distance(GetComponent<RectTransform>().anchoredPosition, animal.GetComponent<RectTransform>().anchoredPosition));
            if (Vector2.Distance(GetComponent<RectTransform>().anchoredPosition, animal.GetComponent<RectTransform>().anchoredPosition) < 100)
            {
                //停止移动 
                isMoving = false;
                //开始学习
                //将2nd语言栏的图片渐变为对方 母语图标
                Learn(animal);

            }


        }

        if (isLearning)
        {
            if (language_2nd.GetComponent<Image>().fillAmount <= 1)
            {
                Debug.Log("Learning");
                language_2nd.GetComponent<Image>().fillAmount += Time.deltaTime * 0.2f;

            }

        }

    }

    void Learn(Transform other)
    {
        //Debug.Log(other.name);
        isLearning = true;

        //mysprite = language_2nd.GetComponent<Image>().sprite;

        language_2nd.GetComponent<Image>().sprite = other.gameObject.GetComponent<TutorAnimalClass>().motherLanguage.GetComponent<Image>().sprite;

        language_2nd.GetComponent<Image>().type = Image.Type.Filled;

        language_2nd.GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;

        language_2nd.GetComponent<Image>().fillAmount = 0;



    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (transform.parent.name.Contains("Slot"))
        {
            Debug.Log(000);
            transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}
