using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CGM;



public  class AnimalProperty : MonoBehaviour
{
    public int id;
    public AnimalType animalTypel;
    public int slotCount;
    public float learningSpeed;
    public bool canLearn;
    public Sprite charaTexture;
    public Sprite miniIconTexture;
    public Sprite bigIconTexture;
    // Start is called before the first frame update
    public void Start()
    {
        //CenterGameManager.instance.m_SaveDataManager.m_levelSheet.data.Find(c => c.ID == 3).Animals;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }



}
