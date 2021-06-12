using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CGM;
using UnityEngine.UI;

public class InitationAnimal : MonoBehaviour
{
    List<int> currentAnimalsId;
    List<AnimalProperty> currentLevelAnimals = new List<AnimalProperty>();
    public  Transform po1;
    public  Transform po2;

    private void Awake()
    {
        //拿到当前场景所有的怪物的id
        currentAnimalsId = CenterGameManager.instance.m_SaveDataManager.m_levelSheet.data.Find(c => c.ID == 3).Animals;
        Debug.Log(currentAnimalsId.Count);
        //通过ID拿到当前场景所有的怪物
        for (int i = 0; i < currentAnimalsId.Count; i++)
        {
            int id = currentAnimalsId[i];
            AnimalProperty ani = new AnimalProperty();
            ani.id= CenterGameManager.instance.m_SaveDataManager.m_animalSheet.data.Find(c => c.ID == id).ID;
            ani.animalTypel = CenterGameManager.instance.m_SaveDataManager.m_animalSheet.data.Find(c => c.ID == id).type;
            ani.slotCount = CenterGameManager.instance.m_SaveDataManager.m_animalSheet.data.Find(c => c.ID == id).slotCount;
            ani.charaSprite = Sprite.Create(CenterGameManager.instance.m_SaveDataManager.m_languageSheet.data.Find(c => c.type == ani.animalTypel).charaTexture as Texture2D, 
                                 new Rect(0, 0, CenterGameManager.instance.m_SaveDataManager.m_languageSheet.data.Find(c => c.type == ani.animalTypel).charaTexture.width,
                                         CenterGameManager.instance.m_SaveDataManager.m_languageSheet.data.Find(c => c.type == ani.animalTypel).charaTexture.height), Vector2.zero);
            
            ani.miniIconSprite = Sprite.Create(CenterGameManager.instance.m_SaveDataManager.m_languageSheet.data.Find(c => c.type == ani.animalTypel).miniIconTexture as Texture2D,
                     new Rect(0, 0, CenterGameManager.instance.m_SaveDataManager.m_languageSheet.data.Find(c => c.type == ani.animalTypel).miniIconTexture.width,
                             CenterGameManager.instance.m_SaveDataManager.m_languageSheet.data.Find(c => c.type == ani.animalTypel).miniIconTexture.height), Vector2.zero);

            ani.bigIconSprite = Sprite.Create(CenterGameManager.instance.m_SaveDataManager.m_languageSheet.data.Find(c => c.type == ani.animalTypel).bigIconTexture as Texture2D,
         new Rect(0, 0, CenterGameManager.instance.m_SaveDataManager.m_languageSheet.data.Find(c => c.type == ani.animalTypel).bigIconTexture.width,
                 CenterGameManager.instance.m_SaveDataManager.m_languageSheet.data.Find(c => c.type == ani.animalTypel).bigIconTexture.height), Vector2.zero);


            //ani.
            currentLevelAnimals.Add(ani);


        }
        //实例化怪物需要赋值：图片 槽位 

        foreach (var item in currentLevelAnimals)
        {
            Debug.Log(currentLevelAnimals);
        }

    }

    private void Start()
    {
        for (int i = 0; i < currentLevelAnimals.Count; i++)
        {
            GameObject obj = Instantiate((GameObject)Resources.Load("Prefabs/3GameScene/Animal"));
            obj.transform.GetChild(0).GetComponent<Image>().sprite = currentLevelAnimals[i].charaSprite;
            GameObject mUICanvas = GameObject.Find("Canvas");
            obj.transform.parent = mUICanvas.transform;
            obj.transform.GetChild(0).GetChild(0).GetComponent<GridLayoutGroup>().constraintCount = currentLevelAnimals[i].slotCount;
            
        }
    }
} 
