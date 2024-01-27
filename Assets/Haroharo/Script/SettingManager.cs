using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEditor.Search;
using UnityEditor.UI;


public class SettingManager : MonoBehaviour
{

    [System.Serializable]
    private struct SettingData
    {
        public Vector2 displaySize;
        //0:ボーダレスウィンドウ　1:フルスクリーン 3:ウィンドウサイズ
        public int displayMode;

        public float mastarAudio;
        public float bgmAudio;
        public float seAudio;

        //0:英語 1:日本語
        public int languge;
    }

    private SettingData settingData;

    string dataPath;
    string fileName = "SettingData.json";

    public int LanguageMode;
    public float Master_Audio;
    public float BGM_Audio;
    public float SE_Audio;

    void Awake()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        dataPath = Application.dataPath + "/" + fileName;
    #elif UNITY_ANDROID
        dataPath = Application.persistentDataPath + "/" + fileName;   
    #endif
        // ファイルがないとき、ファイル作成
        if (!File.Exists(dataPath))
        {
            //初期設定
            var obj = new SettingData
            {
                displaySize = new Vector2(1920, 1020),
                displayMode = 1,
                mastarAudio = 1,
                bgmAudio = 1,
                seAudio = 1,
                languge = 1
            };

            Save(obj);
        }

        // ファイルを読み込んでdataに格納
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    void Start()
    {
        

    }

    void Update()
    {
        
    }

    #region//セーブ関連

    //jsonファイル書き込み
    void Save(SettingData data)
    {
        string json = JsonUtility.ToJson(data);                 // jsonとして変換
        StreamWriter wr = new StreamWriter(dataPath, false);    // ファイル書き込み指定
        wr.WriteLine(json);                                     // json変換した情報を書き込み
        wr.Close();                                             // ファイル閉じる
        //Debug.Log(json);
        //Debug.Log("セーブできたで");
    }

    // jsonファイル読み込み
    SettingData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる

        return JsonUtility.FromJson<SettingData>(json);            // jsonファイルを型に戻して返す
    }
    #endregion

    void SettingLoad(SettingData settingData)
    {
        Screen.SetResolution((int)settingData.displaySize.x, (int)settingData.displaySize.y, (FullScreenMode)settingData.displayMode, 60);
        LanguageMode = settingData.languge;
    }

    //画面サイズの設定
    public void displaySizeSetting(TMP_Dropdown dropdown)
    {
        int value=dropdown.value;

        switch (value) 
        {
            case 0:
                settingData.displaySize = new Vector2(1920, 1080);
                break;
            case 1:
                settingData.displaySize = new Vector2(1280, 720);
                break;
            default: 
                break;
        }

        Screen.SetResolution((int)settingData.displaySize.x, (int)settingData.displaySize.y, (FullScreenMode)settingData.displayMode, 60);

        Save(settingData);
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    //画面モードの設定
    public void displayModeSetting(TMP_Dropdown dropdown)
    {
        settingData.displayMode = dropdown.value;

        Screen.SetResolution((int)settingData.displaySize.x, (int)settingData.displaySize.y, (FullScreenMode)settingData.displayMode, 60);

        Save(settingData);
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    //全体音の設定
    public void mastarAudioSetting(Slider m_Audio)
    {
        settingData.mastarAudio = m_Audio.value;
        Master_Audio = m_Audio.value;

        Debug.Log(m_Audio.value);

        Save(settingData);
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    //BGMの設定
    public void BGMSetting(Slider b_Audio)
    {
        settingData.bgmAudio = b_Audio.value;
        BGM_Audio = b_Audio.value;

        Debug.Log(b_Audio.value);

        Save(settingData);
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    //効果音の設定
    public void SESetting(Slider s_Audio)
    {
        settingData.seAudio = s_Audio.value;
        SE_Audio = s_Audio.value;

        Debug.Log(s_Audio.value);

        Save(settingData);
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    public void LanguageSetting(TMP_Dropdown dropdown)
    {
        LanguageMode = dropdown.value;
        settingData.languge = dropdown.value;

        Debug.Log(dropdown.value);

        Save(settingData);
        settingData = Load(dataPath);
        SettingLoad(settingData);

        #if UNITY_STANDALONE_WIN
        //System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe"));
        //Application.Quit();
        #endif
    }
}
