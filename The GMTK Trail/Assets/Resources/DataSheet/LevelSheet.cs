using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using geniikw.DataSheetLab;


[Serializable]
public class LevelParameter
{
    //ID
    public int ID;

    //名字
    public string name;

    //关卡内动物ID(AnimalSheetID)
    public List<int> Animals;

    //下一关 场景名
    public string NameOfNextScene;

    //这一关 这一关场景名
    public string NameOfThisScene;
}

/// <summary>
/// sheet class name must be same with file name.
/// </summary>
[CreateAssetMenu]
public class LevelSheet : Sheet<LevelParameter> { }