using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private enum GameState
    {
        TITLE,
        IN_GAME,
    }

    private GameState gameState;

    private GameObject TitleObj;
    private GameObject InGameObj;
    private GameObject PauseObj;
    private GameObject SettingObj;
    private GameObject SettingDisplayObj;
    private GameObject SettingAudioObj;
    private GameObject SettingLanguageObj;

    private bool isSetting;
  　public bool isPause;

    Camera MainCamera;

    private void Awake()
    {
        TitleObj = GameObject.Find("Title");
        InGameObj = GameObject.Find("InGame");
        PauseObj = GameObject.Find("Pause");
        SettingObj = GameObject.Find("Setting");
        SettingDisplayObj = GameObject.Find("display");
        SettingAudioObj = GameObject.Find("Audio");
        SettingLanguageObj = GameObject.Find("Language");

        gameState = GameState.TITLE;
    }

    private void Start()
    {
        DontDestroyOnLoad(transform.root.gameObject);

        TitleObj.SetActive(true);
        InGameObj.SetActive(false);
        PauseObj.SetActive(false);
        SettingObj.SetActive(false);
        SettingDisplayObj.SetActive(false);
        SettingAudioObj.SetActive(false);
        SettingLanguageObj.SetActive(false); 
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.TITLE:
                TitleScene();
                SettingBackKey();
                break;
            case GameState.IN_GAME:
                InGameScene();
                SettingBackKey();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// タイトル時の処理
    /// </summary>
    private void TitleScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isSetting == false)
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// 設定に行くボタン
    /// </summary>
    public void SettingButton()
    {
        SettingObj.SetActive(true);

        TitleObj.SetActive(false);
        PauseObj.SetActive(false);
        SettingDisplayObj.SetActive(false);
        SettingAudioObj.SetActive(false);
        SettingLanguageObj.SetActive(false);

        isSetting = true;
    }

    /// <summary>
    /// 設定中の戻るボタン
    /// </summary>
    public void SettingBackButton()
    {
        switch (gameState)
        {
            case GameState.TITLE:
                TitleObj.SetActive(true);
                SettingObj.SetActive(false);
                SettingDisplayObj.SetActive(false);
                SettingAudioObj.SetActive(false);
                SettingLanguageObj.SetActive(false);
                break;

            case GameState.IN_GAME:
                PauseObj.SetActive(true);
                SettingObj.SetActive(false);
                SettingDisplayObj.SetActive(false);
                SettingAudioObj.SetActive(false);
                SettingLanguageObj.SetActive(false);
                break;
            default:
                break;
        }
        isSetting = false;
    }

    /// <summary>
    /// 設定中のキーボード
    /// </summary>
    private void SettingBackKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isSetting == true)
        {
            switch (gameState)
            {
                case GameState.TITLE:
                    TitleObj.SetActive(true);
                    SettingObj.SetActive(false);
                    SettingDisplayObj.SetActive(false);
                    SettingAudioObj.SetActive(false);
                    SettingLanguageObj.SetActive(false);
                    break;

                case GameState.IN_GAME:
                    PauseObj.SetActive(true);
                    SettingObj.SetActive(false);
                    SettingDisplayObj.SetActive(false);
                    SettingAudioObj.SetActive(false);
                    SettingLanguageObj.SetActive(false);
                    break;
                default:
                    break;
            }
            isSetting = false;
        }
    }

    /// <summary>
    /// ゲーム中の処理
    /// </summary>
    private void InGameScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            Time.timeScale = 1;
            PauseObj.SetActive(true);
            isPause = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            Time.timeScale = 0;
            PauseObj.SetActive(false);
            isPause = true;
        }
    }

    /// <summary>
    /// ゲームに戻る
    /// </summary>
    public void ReturnGame()
    {
        Time.timeScale = 1;
        PauseObj.SetActive(true);
        isPause = false;
    }

    /// <summary>
    /// ゲームスタート
    /// </summary>
    public void StartGameButton()
    {
        SceneManager.LoadScene("MainScene");
        gameState = GameState.IN_GAME;
    }

    /// <summary>
    /// 設定のディスプレイのボタン
    /// </summary>
    public void SettingDisplay()
    {
        SettingDisplayObj.SetActive(true);
        SettingAudioObj.SetActive(false);
        SettingLanguageObj.SetActive(false);
    }

    /// <summary>
    /// 設定の音声のボタン
    /// </summary>
    public void SettingAudioButton()
    {
        SettingDisplayObj.SetActive(false);
        SettingAudioObj.SetActive(true);
        SettingLanguageObj.SetActive(false);
    }

    /// <summary>
    /// 設定の言語のボタン
    /// </summary>
    public void SettingLanguageButton()
    {
        SettingDisplayObj.SetActive(false);
        SettingAudioObj.SetActive(false);
        SettingLanguageObj.SetActive(true);
    }

    /// <summary>
    /// ゲーム終了ボタン
    /// </summary>
    public void GameExitButton()
    {
        Application.Quit();
    }
}
