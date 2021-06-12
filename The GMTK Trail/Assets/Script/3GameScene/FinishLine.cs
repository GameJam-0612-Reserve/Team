using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public FinishSlot[] m_finishSlots;

    public GameObject right;
    public GameObject wrong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnToRight()
    {
        right.SetActive(true);
        wrong.SetActive(false);
    }
    public void TurnToWrong()
    {
        right.SetActive(false);
        wrong.SetActive(true);
    }
    public void TurnToNormal()
    {
        right.SetActive(false);
        wrong.SetActive(false);
    }
}
