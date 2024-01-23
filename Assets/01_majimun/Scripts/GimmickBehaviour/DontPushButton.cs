using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontPushButton : GimmickBehaviour
{
    // [ Firld ]
    [SerializeField] private AudioSource _audioSelf;
    [SerializeField] private AudioClip   _gimmickSE;

    // [ Activate gimmick action, ]
    public override void GimmickActionEvent( GameObject target = null )
    {
        Debug.Log("Don't push button gimmick.");

        _audioSelf.PlayOneShot( _gimmickSE );

        base.GimmickActionEvent(target);
    }
}
