using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] BGM_AudioClip;
    [SerializeField]
    private AudioClip[] SE_AudioClip;

    SettingManager settingManager;

    [SerializeField]
    private GameObject BGM_Source;
    [SerializeField]
    private GameObject SE_Source;

    private Camera mainCamera;

    void Awake()
    {
        settingManager=GameObject.Find("SettingManager").GetComponent<SettingManager>();
        mainCamera = Camera.main;
    }

    /// <summary>
    /// BGMを流す
    /// </summary>
    /// <param name="id">何番目の曲を流す？</param>
    /// <param name="loop"></param>
    /// <param name="name">オブジェクト名の設定</param>
    public void BGMPlay(int id,bool loop,string BGM_Name="BGM")
    {
        var BGM_Obj = Instantiate(BGM_Source, mainCamera.transform.parent);
        BGM_Obj.transform.localPosition = Vector3.zero;
        BGM_Obj.name = BGM_Name; 

        AudioSource audio=BGM_Obj.GetComponent<AudioSource>();

        audio.volume = settingManager.Master_Audio / settingManager.BGM_Audio;
        audio.clip = BGM_AudioClip[id];
        audio.loop = loop;
        audio.Play();
    }

    /// <summary>
    /// BGMを止める
    /// </summary>
    /// <param name="BGM_Name"></param>
    public void BGMStop(string BGM_Name="BGM")
    {
        Destroy(GameObject.Find(BGM_Name));
    }

    /// <summary>
    /// SEを再生
    /// </summary>
    /// <param name="id">何番目のSE？</param>
    /// <param name="loop">ループするのか</param>
    /// <param name="SE_Name">ループで消す場合は絶対に必要</param>
    public void SEPlay(int id,bool loop,string SE_Name = "SE")
    {
        var SE_Obj = Instantiate(BGM_Source,mainCamera.transform.parent);
        SE_Obj.transform.localPosition = Vector3.zero;
        SE_Obj.name = SE_Name;

        AudioSource audio = SE_Obj.GetComponent<AudioSource>();

        audio.volume = settingManager.Master_Audio / settingManager.SE_Audio;
        audio.clip = SE_AudioClip[id];
        audio.loop = loop;
        //audio.Play();
    }

    /// <summary>
    /// SEを止める
    /// </summary>
    /// <param name="SE_Name">名前</param>
    public void SEStop(string SE_Name = "SE")
    {
        Destroy(GameObject.Find(SE_Name));
    }
}
