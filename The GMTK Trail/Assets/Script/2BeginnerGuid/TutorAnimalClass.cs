using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorAnimalClass : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerClickHandler,IPointerUpHandler
{
    #region �̳�ר�ö����� ����ʽ��Ϸ��ͬ
    //�ⲿ��ȡ���� �Ƿ�ѡ�� ���н׶��ж� ������ѡ�� �����½׶���ʾ
    //�ⲿ��ȡ���� �����Ƿ��еڶ�����
    //�����ⲿ��Ϣ Learn(�Է�ĸ��) �ı�����ڶ�������״̬
    //������Ϣ Teach() 
    //��ק���巽��

    #endregion

    [Header("��ǰ����״̬")]
    public bool isChosen;   //��ѡ�� �ȴ�ƥ��
    public Transform UpperArea;

    [Header("�ڳ�����")]
    public Transform animal;

    [Header("��ǰ�������ϵ�������״̬")]
    public int firstLanguageID;
    public GameObject motherLanguage;
    public GameObject language_2nd;

    Sprite mysprite;

    private Vector2 offsetPos;

    //�����Ƿ����ƶ�
    bool isMoving;
    bool isLearning;


    //��ק����
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position - offsetPos;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = eventData.position - (Vector2)transform.position;
    }

    //������� 
    public void OnPointerClick(PointerEventData eventData)
    {
        //ȡ��
        this.isChosen = !isChosen;
        if (animal.GetComponent<TutorAnimalClass>().isChosen && isChosen)
        {
            isMoving = true;
            animal.GetComponent<TutorAnimalClass>().isMoving = true;

            //������������ѡ������ �������� ���� Learn()
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
            //�ƶ���Է�
            GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(GetComponent<RectTransform>().anchoredPosition, animal.GetComponent<RectTransform>().anchoredPosition, 2f);
            //Debug.Log(Vector2.Distance(GetComponent<RectTransform>().anchoredPosition, animal.GetComponent<RectTransform>().anchoredPosition));
            if (Vector2.Distance(GetComponent<RectTransform>().anchoredPosition, animal.GetComponent<RectTransform>().anchoredPosition) < 100)
            {
                //ֹͣ�ƶ� 
                isMoving = false;
                //��ʼѧϰ
                //��2nd��������ͼƬ����Ϊ�Է� ĸ��ͼ��
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
