using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CGM;

public class InitationAnimal : MonoBehaviour
{
    List<int> currentAnimalsId;
    List<AnimalProperty> currentLevelAnimals = new List<AnimalProperty>();
    public  Transform po1;
    public  Transform po2;

    private void Awake()
    {
        //�õ���ǰ�������еĹ����id
        currentAnimalsId = CenterGameManager.instance.m_SaveDataManager.m_levelSheet.data.Find(c => c.ID == 3).Animals;
        //ͨ��ID�õ���ǰ�������еĹ���
        for (int i = 0; i < currentAnimalsId.Count; i++)
        {
            int id = currentAnimalsId[i];
            AnimalProperty ani = new AnimalProperty();
            ani.id= CenterGameManager.instance.m_SaveDataManager.m_animalSheet.data.Find(c => c.ID == id).ID;
            ani.animalTypel = CenterGameManager.instance.m_SaveDataManager.m_animalSheet.data.Find(c => c.ID == id).type;
            ani.slotCount = CenterGameManager.instance.m_SaveDataManager.m_animalSheet.data.Find(c => c.ID == id).slotCount;



            //ani.
            currentLevelAnimals.Add(ani);

        }
        //ʵ����������Ҫ��ֵ��ͼƬ ��λ 


    }

    private void Start()
    {
        
    }
}
