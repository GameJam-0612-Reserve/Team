using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGM
{
    public class CenterGameManager : Singleton<CenterGameManager>
    {
        [Header("我的SheetManager")]
        public SheetManager m_sheetManager;

        [Header("我的SceneLoader")]
        public CGM_SceneLoader m_SceneLoader;

        [Header("我的SaveData管理器")]
        public CGM_SaveDataManager m_SaveDataManager;

        [Header("我的UILoader")]
        public CGM_UILoader m_UILoader;

        [Header("我的AudioManager")]
        public CGM_AudioManager m_AudioManager;

        //游戏状态
        public int State = 0; //0=startScene,1=GameScene,

        // Start is called before the first frame update
        void Start()
        {
            //设置固定帧率
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }



        public Texture2D Cursor1;
        public Texture2D Cursor2;

        /// <summary>
        /// 改变cursor的方法
        /// </summary>
        /// <param name="type">1=手指抬起 2=手指点下</param>
        public void ChangeCursor(int type)
        {
            switch (type)
            {
                case 1:
                    Cursor.SetCursor(Cursor1, new Vector2(0.18f, 0.82f), CursorMode.Auto);
                    break;
                case 2:
                    Cursor.SetCursor(Cursor2, new Vector2(0.18f, 0.82f), CursorMode.Auto);
                    break;
                default:
                    break;
            }
        }
    }
}
