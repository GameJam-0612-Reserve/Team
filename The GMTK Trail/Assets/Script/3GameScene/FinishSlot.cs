using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSlot : MonoBehaviour
{
    private AnimalProperty holdingAnimal;
    public List<FinishLine> m_finishLines;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InThisSlot(AnimalProperty animalProperty)
    {
        holdingAnimal = animalProperty;
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
                //执行检测方法
                //根据检测结果改变line的表现
            }
            else
            {
                item.TurnToNormal();
            }
        }
    }
}
