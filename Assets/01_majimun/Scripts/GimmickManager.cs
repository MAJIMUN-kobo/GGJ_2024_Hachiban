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

        string log = "Setting Gimmicks === \n";
        foreach( GimmickBehaviour gimmick in  _playableGimmicks )
        {
            // random activation.
            int r = Random.Range( 0, 100 );
            if( r < 20 ) { gimmick.IsActive = false; }
            else { gimmick.IsActive = true; } 
            
            gimmick.Setup();

            log += $" > { gimmick.transform.name }, Activate = { gimmick.IsActive }\n";
        }
        Debug.Log( log );
    }

    // [ Frame Update ]
    void Update()
    {
        
    }
}
