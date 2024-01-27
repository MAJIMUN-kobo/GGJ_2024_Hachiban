using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
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
    private Vector2 displaySize = new Vector2(1920, 1020);
    private int displayMode = 1;
    private float mastarAudio = 1;
    private float bgmAudio = 1;
    private float seAudio = 1;
    public int languge = 0;


    void Awake()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Data/SettingData");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
