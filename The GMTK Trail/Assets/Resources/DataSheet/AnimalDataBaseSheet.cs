using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using geniikw.DataSheetLab;


[Serializable]
public class AnimalDataBaseParameter
{
    //ID
    public int ID;

    //AnimalID
    public int AnimalID;

    //所属关卡
    public int Level;

    //名字
    public string name;

    //物种，母语
    public AnimalType type;

    //二语言栏
    // public List<AnimalType> slots;

    //新二语言栏 by Yishen
    public Queue<LanguageParameter> newSlots;
    public readonly int capacity;
    public AnimalDataBaseParameter(){}
    // public AnimalDataBaseParameter(int AnimalID,int Level,string name,AnimalType type, List<AnimalType> slots ) { 
    //     this.AnimalID = AnimalID;
    //     this.Level = Level;
    //     this.name = name;
    //     this.type = type;
    //     this.slots = slots;
    //     this.newSlots = new Queue<LanguageParameter>(5);
    // }
    public AnimalDataBaseParameter(int AnimalID,int Level,string name,AnimalType type, int slotsCount ) { 
        this.AnimalID = AnimalID;
        this.Level = Level;
        this.name = name;
        this.type = type;
        this.newSlots = new Queue<LanguageParameter>(slotsCount);
        this.capacity = slotsCount;
    }

}

/// <summary>
/// sheet class name must be same with file name.
/// </summary>
[CreateAssetMenu]
public class AnimalDataBaseSheet : Sheet<AnimalDataBaseParameter> { }