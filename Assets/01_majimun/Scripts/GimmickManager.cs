using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    private GimmickBehaviour[] _playableGimmicks;
    private GameSceneManager _gameManager;

    // [ Property ]
    public int gimmickDiscoveredCount { get ; set; }
    public int stageLevel
    {
        get { return _gameManager.stageLevel; }
        set { _gameManager.stageLevel = value; }
    }

    // [ Object Initialize ]
    void Start()
    {
        _playableGimmicks = Object.FindObjectsOfType<GimmickBehaviour>();
        _gameManager = GameObject.FindObjectOfType<GameSceneManager>();

        RandomActivationGimmicks();
    }


    public void Initialize()
    {
        gimmickDiscoveredCount = 0;
        RandomActivationGimmicks();
    }

    
    // [ Random activation all gimmick ]
    public void RandomActivationGimmicks()
    {
        foreach( GimmickBehaviour gimmick in  _playableGimmicks )
        {
            // random activation.
            int r = Random.Range( 0, 100 );
            if( r < gimmick.GetActiveRate ) { gimmick.IsActive = true; }
            else { gimmick.IsActive = false; }
            
            gimmick.Setup( this );
        }
    }


    // [ Frame Update ]
    void Update()
    {
        
    }

    

    #if UNITY_EDITOR
    private void OnGUI()
    {
        string log = "Setting Gimmicks === \n";
        foreach( GimmickBehaviour gimmick in  _playableGimmicks )
        {
            log += $" > { gimmick.transform.name }, Activate = { gimmick.IsActive }\n";
        }

        log += "\nGame Level ===\n";
        log += $"Stage Level = { _gameManager.stageLevel }\n";
        log += $"Discovered Gimmick = { gimmickDiscoveredCount }\n";
        GUILayout.Label( log );
    }
    #endif
}
