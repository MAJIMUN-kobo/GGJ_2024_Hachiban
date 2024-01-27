using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingData
{
    public Vector2 DisplaySize;
    //0:ボーダレスウィンドウ　1:フルスクリーン 3:ウィンドウサイズ
    public int DisplayMode;

    public float MastarAudio;
    public float BGM;
    public float SE;

    //0:英語 1:日本語
    public int Languge;
}

public class SettingManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
