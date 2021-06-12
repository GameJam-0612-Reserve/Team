using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CGM;

public class SheetManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Examples:
        //ClearAllLevelSheet();
        //CreateLevelSheet(4);

        // AnimalDataBaseSheet animalDataBaseSheet = CenterGameManager.instance.m_SaveDataManager.m_animalDataBaseSheet;
        // Debug.Log(animalDataBaseSheet.data[0].type);
        // SlotUpdate(animalDataBaseSheet.data[1],2);
        // SlotUpdate(animalDataBaseSheet.data[1],1);
        // SlotUpdate(animalDataBaseSheet.data[1],3);
        // Debug.Log(animalDataBaseSheet.data[1].newSlots.Peek().type);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateLevelSheet(int levelID)
    {
        if (levelID <= 0)
        {
            Debug.LogError("LevelID must greater than 0");
            return;
        }
        LevelSheet levelParameters = CenterGameManager.instance.m_SaveDataManager.m_levelSheet;
        AnimalDataBaseSheet animalDataBaseSheet = CenterGameManager.instance.m_SaveDataManager.m_animalDataBaseSheet;
        LevelParameter current = levelParameters[levelID - 1];//levelID-1 means index(starts from 0)
        for (var i = 0; i < current.Animals.Count; i++)
        {
            if (current.Animals != null && current.Animals.Count > 0)
            {

                AnimalParameter currentAnimal = CenterGameManager.instance.m_SaveDataManager.m_animalSheet.data.Find(a => a.ID == current.Animals[i]);
                AnimalType currentType = currentAnimal.type;
                int slotsCount = currentAnimal.slotCount;
                AnimalDataBaseParameter add = new AnimalDataBaseParameter(current.ID, levelID, current.name, currentType, slotsCount);
                animalDataBaseSheet.data.Add(add);

            }
            else
            {
                Debug.LogError("current animal is empty");
            }
        }
    }
    public void ClearAllLevelSheet()
    {
        AnimalDataBaseSheet animalDataBaseSheet = CenterGameManager.instance.m_SaveDataManager.m_animalDataBaseSheet;
        animalDataBaseSheet.data.Clear();
    }

    public void SlotUpdate(AnimalDataBaseParameter animalDataBaseParameter, int languageID)
    {
        Queue<LanguageParameter> newSlots = animalDataBaseParameter.newSlots;
        // Debug.Log(newSlots);
        LanguageSheet languageSheet = CenterGameManager.instance.m_SaveDataManager.m_languageSheet;

        //newSlots.Enqueue(languageSheet.data.Find(a=>a.ID==languageID));//TO be optimized
        LanguageParameter language = languageSheet.data.Find(a => a.ID == languageID);

        //Check if capacity is 0 (can't learn anything)
        if (animalDataBaseParameter.capacity <= 0)
        {
            Debug.LogError("The queue is empty");
            return;
        }
        //Check if the language can be learned
        if (!language.canLearn)
        {
            return;
        }
        //Check if learning speed is 8 (all slots will be it)
        if (language.LearningSpeed == 8)
        {
            newSlots.Clear();
            for (int i = 0; i < animalDataBaseParameter.capacity; i++)
            {
                newSlots.Enqueue(language);
            }
            return;
        }
        //Check if learning speed is 0.5 (needs special methods)
        if (language.LearningSpeed == 0.5)
        {
            //TODO            
        }
        //Check if slots is full
        if (newSlots.Count == animalDataBaseParameter.capacity)
        {
            newSlots.Dequeue();
        }
        newSlots.Enqueue(language);
    }
}
