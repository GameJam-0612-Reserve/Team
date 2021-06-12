using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkData : MonoBehaviour
{
    public float linkSpeed;
    public float learnMutiplier;
    public List<GameObject> LinkObjs;
    public bool linkMove;
    public float currentLearnTime;
    public float defaultLearnTime=5f;
    public bool learnFinsh;
    public bool stopMove;
    public Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (LinkObjs.Count == 2)
        {
            if (LinkObjs[0] == LinkObjs[1])
            {
                LinkObjs.Clear();
                return;
            }
            GameObject obj1 = LinkObjs[0];
            GameObject obj2 = LinkObjs[1];
            linkMove = true;
            obj1.transform.position = Vector2.MoveTowards(obj1.transform.position, (Vector2) obj2.transform.position- offset, linkSpeed * Time.deltaTime);
            obj2.transform.position = Vector2.MoveTowards(obj2.transform.position, (Vector2)obj1.transform.position- offset, linkSpeed * Time.deltaTime);
            if (Vector2.Distance(obj1.transform.position, obj2.transform.position) < 150f)
            {
                if (currentLearnTime >= defaultLearnTime)
                {
                    Debug.Log("开始互相学习");           
                    FindNoSpriteSlotAndChangeSprite(obj1, obj2.GetComponent<Image>().sprite);
                    FindNoSpriteSlotAndChangeSprite(obj2, obj1.GetComponent<Image>().sprite);
                    LinkObjs.Remove(obj2);
                    LinkObjs.Remove(obj1);
                    linkMove = false;
                    currentLearnTime = 0;
                    stopMove = false;
                }
                else
                {
                    currentLearnTime += Time.deltaTime ;
                }
            }
        }
        else
        {
            linkMove = false;
        }
    }


    void FindNoSpriteSlotAndChangeSprite(GameObject obj,Sprite needChangeImage)
    {
        Transform languageSlots = obj.gameObject.transform.GetChild(0);

        for (int i = 0; i < languageSlots.childCount; i++)
        {
            if (languageSlots.GetChild(i).GetComponent<Image>().sprite==null)
            {
                languageSlots.GetChild(i).GetComponent<Image>().sprite = needChangeImage;
                return;
            }
        }
    
    }

}
