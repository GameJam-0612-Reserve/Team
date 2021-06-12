using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using geniikw.DataSheetLab;


    [Serializable]
    public class AnimalParameter
{
        //ID
        public int ID;

        //名字
        public string name;
        
        //物种，母语
        public AnimalType type;
        
        //二语言栏
        public int slotCount;
    }

    /// <summary>
    /// sheet class name must be same with file name.
    /// </summary>
    [CreateAssetMenu]
    public class AnimalSheet : Sheet<AnimalParameter> { }