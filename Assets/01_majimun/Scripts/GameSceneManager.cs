using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    // [ Enum ]
    public enum GameSceneMode
    {
        Setup = 0,
        Playing,
        Resut,
        Exit
    }

    // [ Property ]
    public int stageLevel {  get; set; }
    public int gameMode   { get; set; }

    void Start()
    {
        gameMode   = (int)GameSceneMode.Setup;
        stageLevel = 1;
    }

    void Update()
    {
        GameModeUpdate();

        if( stageLevel > 8 )
        {
            ChangeScene();
            Debug.Log("Game Clear");
        }
    }


    public async void ChangeScene()
    {
        await SceneLoader.Instance.LoadScene("TitleScene");
    }


    public void GameModeUpdate()
    {
        switch( gameMode )
        {
            case (int)GameSceneMode.Setup:
                Setup();
                break;

            case (int)GameSceneMode.Playing:
                Playing();
                break;

            case (int)GameSceneMode.Resut:
                Result();
                break;

            case (int)GameSceneMode.Exit:
                Exit();
                break;

            default:
                break;
        }
    }


    public void Setup()
    {
        gameMode = (int)GameSceneMode.Playing;
    }


    public void Playing()
    {

    }


    public void Result()
    {

    }


    public void Exit()
    {

    }
}
