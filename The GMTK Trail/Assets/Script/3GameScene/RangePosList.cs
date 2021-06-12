using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangePosList : MonoBehaviour
{
    public Transform[] rangePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetBackRandomPos()
    {
        int k = Random.Range(0, rangePos.Length);
        return rangePos[k];
    }
}
