using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class move : MonoBehaviour,IPointerClickHandler,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float speed;
    public Transform leftDownPos;
    public Transform rightUpPos;
    public Vector2 movePos;
    private float currentWaitTime;
    public  float defaultWaitTime = 1f;
    public bool isLinkMove;
    private bool isDraging;
    private GameObject colliderObj;
    private bool inCheckMenu;
    public Vector3 beginDragPos;
    private bool isStopMove;
    Rigidbody2D rigi;
    //private float intervalTime;
    //private float lastInvokeTime;
    //private bool isPressMouseButton;


    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        movePos = GetRandomPos();

    }

    // Update is called once per frame
    void Update()
    {
        LinkData linkdate = GameObject.FindGameObjectWithTag("LinkData").GetComponent<LinkData>();
        isLinkMove = linkdate.linkMove;
        if (!isLinkMove&& !isDraging && !inCheckMenu&&!isStopMove)
        {
            FreeMove();
        }

    }

    Vector2 GetRandomPos()
    {
        Vector2 pos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
                                         Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return pos;
    }

    void FreeMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos) < 0.2f)
        {
            if (currentWaitTime <= 0)
            {
                movePos = GetRandomPos();
                currentWaitTime = defaultWaitTime;
            }
        }
        else
        {
            currentWaitTime -= Time.deltaTime;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!inCheckMenu)
        {
            Debug.Log(inCheckMenu);
            GameObject lindataObj = GameObject.FindGameObjectWithTag("LinkData");
            LinkData linkData = lindataObj.GetComponent<LinkData>();
            linkData.LinkObjs.Add(transform.gameObject);

        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        beginDragPos = transform.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDraging = true;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
        if ( colliderObj!=null&& colliderObj.gameObject.CompareTag("CheckMenu"))
        {
            transform.position = beginDragPos;
            inCheckMenu = false;
        }

        if (colliderObj != null && colliderObj.gameObject.CompareTag("CheckSlot"))
        {
            transform.SetParent(colliderObj.transform);
            transform.localPosition = Vector2.zero;
            transform.GetComponent<Image>().sprite = transform.GetComponent<AnimalProperty>().bigIconSprite;
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(124,125);

        }


        if (colliderObj != null && colliderObj.gameObject.CompareTag("LinkMenu"))
        {
            inCheckMenu = false;
            transform.GetComponent<Image>().sprite = transform.GetComponent<AnimalProperty>().charaSprite;
            Debug.Log(!isLinkMove + " " + !isDraging + "  " + !inCheckMenu + "  " + !isStopMove);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("CheckMenu"))
        {
            inCheckMenu = true;
            colliderObj = collision.gameObject;
            Debug.Log("Trigger");
        }

        if (collision.transform.CompareTag("CheckSlot"))
        {
            colliderObj = collision.gameObject;
            Debug.Log("Trigger");
        }

        if (collision.transform.CompareTag("LinkMenu"))
        {
            colliderObj = collision.gameObject;
            Debug.Log("TriggerLinkMenu");
        }

    }

}
