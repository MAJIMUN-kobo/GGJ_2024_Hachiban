using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    private GimmickBehaviour[] _playableGimmicks;

    // [ Object Initialize ]
    void Start()
    {
        _playableGimmicks = Object.FindObjectsOfType<GimmickBehaviour>();

        RandomActivationGimmicks();
    }


    public void Initialize()
    {
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

        GUILayout.Label( log );
    }
    #endif
}
