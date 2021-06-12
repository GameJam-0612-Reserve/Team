using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CGM;

public class FinishSlot : MonoBehaviour
{
    private AnimalDataBaseParameter holdingAnimal;
    public List<FinishLine> m_finishLines;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InThisSlot(AnimalDataBaseParameter m_animalDataBasePara)
    {
        holdingAnimal = m_animalDataBasePara;
        CheckThisSlot();
    }

    public void OutThisSlot()
    {
        holdingAnimal = null;
        CheckThisSlot();
    }

    void CheckThisSlot()
    {
        foreach (FinishLine item in m_finishLines)
        {
            if (item.m_finishSlots[0].holdingAnimal != null && item.m_finishSlots[1].holdingAnimal != null)
            {
                bool temp= CenterGameManager.instance.m_sheetManager.Compare(item.m_finishSlots[0].holdingAnimal, item.m_finishSlots[1].holdingAnimal);
                if (temp)
                {
                    item.TurnToRight();
                }
                else
                {
                    item.TurnToWrong();
                }
            }
            else
            {
                item.TurnToNormal();
            }
        }
    }

}
