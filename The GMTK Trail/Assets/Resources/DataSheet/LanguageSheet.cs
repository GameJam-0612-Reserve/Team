using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using geniikw.DataSheetLab;


    [Serializable]
    public class LanguageParameter
    {
        //ID
        public int ID;

        //名字
        public AnimalType type;
        
        //学习速度
        public float LearningSpeed;
        
        //是否为可学习的语言
        public bool canLearn;

        //角色图
        public Texture charaTexture;

        //图标图
        public Texture iconTexture;
}

    /// <summary>
    /// sheet class name must be same with file name.
    /// </summary>
    [CreateAssetMenu]
    public class LanguageSheet : Sheet<LanguageParameter> { }