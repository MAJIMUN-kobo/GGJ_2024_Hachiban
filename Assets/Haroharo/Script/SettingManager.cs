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
        //0:�{�[�_���X�E�B���h�E�@1:�t���X�N���[�� 3:�E�B���h�E�T�C�Y
        public int displayMode;

        public float mastarAudio;
        public float bgmAudio;
        public float seAudio;

        //0:�p�� 1:���{��
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
        // �t�@�C�����Ȃ��Ƃ��A�t�@�C���쐬
        if (!File.Exists(dataPath))
        {
            //�����ݒ�
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

        // �t�@�C����ǂݍ����data�Ɋi�[
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    void Start()
    {
        

    }

    void Update()
    {
        
    }

    #region//�Z�[�u�֘A

    //json�t�@�C����������
    void Save(SettingData data)
    {
        string json = JsonUtility.ToJson(data);                 // json�Ƃ��ĕϊ�
        StreamWriter wr = new StreamWriter(dataPath, false);    // �t�@�C���������ݎw��
        wr.WriteLine(json);                                     // json�ϊ�����������������
        wr.Close();                                             // �t�@�C������
        //Debug.Log(json);
        //Debug.Log("�Z�[�u�ł�����");
    }

    // json�t�@�C���ǂݍ���
    SettingData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // �t�@�C���ǂݍ��ݎw��
        string json = rd.ReadToEnd();                           // �t�@�C�����e�S�ēǂݍ���
        rd.Close();                                             // �t�@�C������

        return JsonUtility.FromJson<SettingData>(json);            // json�t�@�C�����^�ɖ߂��ĕԂ�
    }
    #endregion

    void SettingLoad(SettingData settingData)
    {
        Screen.SetResolution((int)settingData.displaySize.x, (int)settingData.displaySize.y, (FullScreenMode)settingData.displayMode, 60);
        LanguageMode = settingData.languge;
    }

    //��ʃT�C�Y�̐ݒ�
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

    //��ʃ��[�h�̐ݒ�
    public void displayModeSetting(TMP_Dropdown dropdown)
    {
        settingData.displayMode = dropdown.value;

        Screen.SetResolution((int)settingData.displaySize.x, (int)settingData.displaySize.y, (FullScreenMode)settingData.displayMode, 60);

        Save(settingData);
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    //�S�̉��̐ݒ�
    public void mastarAudioSetting(Slider m_Audio)
    {
        settingData.mastarAudio = m_Audio.value;
        Master_Audio = m_Audio.value;

        Debug.Log(m_Audio.value);

        Save(settingData);
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    //BGM�̐ݒ�
    public void BGMSetting(Slider b_Audio)
    {
        settingData.bgmAudio = b_Audio.value;
        BGM_Audio = b_Audio.value;

        Debug.Log(b_Audio.value);

        Save(settingData);
        settingData = Load(dataPath);
        SettingLoad(settingData);
    }

    //���ʉ��̐ݒ�
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
