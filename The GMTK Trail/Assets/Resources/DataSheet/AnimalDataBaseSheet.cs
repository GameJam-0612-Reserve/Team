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
        public List<AnimalType> slots;
    }

    /// <summary>
    /// sheet class name must be same with file name.
    /// </summary>
    [CreateAssetMenu]
    public class AnimalDataBaseSheet : Sheet<AnimalDataBaseParameter> { }