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
                    if (obj1.GetComponent<AnimalProperty>().animalTypel.Equals(obj2.GetComponent<AnimalProperty>().animalTypel))
                    {
                        Debug.Log("同类之间不需要学习语言");
                        LinkObjs.Clear();
                        return;
                    }
                    FindNoSpriteSlotAndChangeSprite(obj1, obj2.GetComponent<AnimalProperty>().miniIconSprite);
                    FindNoSpriteSlotAndChangeSprite(obj2, obj1.GetComponent<AnimalProperty>().miniIconSprite);
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
        else if (LinkObjs.Count >2)
        {
            LinkObjs.Clear();
            return;
        }
        else
        {
            linkMove = false;
        }
    }


    void FindNoSpriteSlotAndChangeSprite(GameObject obj,Sprite needChangeImage)
    {
        //拿到language插槽
        Transform languageSlots = obj.gameObject.transform.GetChild(0);

        //遍历插槽 找到第一个 slot 下没有子物体即没有语言的插槽
        for (int i = 0; i < languageSlots.childCount; i++)
        {
            if (languageSlots.GetChild(i).childCount == 0)
            {
                //将另一个元素的sprite转变为 当前slot的子物体 sprite从animalProperty中取 miniIcon
                GameObject miniIcon = new GameObject();
                miniIcon.AddComponent<Image>();
                miniIcon.GetComponent<Image>().sprite = needChangeImage;
                miniIcon.transform.SetParent(languageSlots.GetChild(i));
                miniIcon.transform.localPosition = Vector2.zero;
                return;
            }
        }


        //for (int i = 0; i < languageSlots.childCount; i++)
        //{
        //    if (languageSlots.GetChild(i).childCount>0)
        //    {
        //        for (int j = 0; j < languageSlots.GetChild(i).childCount; j++)
        //        {
        //            if (languageSlots.GetChild(i).GetChild(j)
        //            {

        //            }
        //        }
        //        languageSlots.GetChild(i).GetComponent<Image>().sprite = needChangeImage;
        //        return;
        //    }
        //}
    
    }

}
