using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingGuy : GimmickBehaviour
{
    [SerializeField] private AudioSource _audioSelf;
    [SerializeField] private AudioClip   _gimmickSE;

    public override void OnTriggerActivation(GameObject target)
    {
        if( _canPlay )
        {
            _audioSelf.PlayOneShot(_gimmickSE);
            _canPlay = false;
        }

        base.OnTriggerActivation(target);
    }

    public override void OnLookAtActivation(GameObject target)
    {
        if( _canPlay )
        {
            _audioSelf.PlayOneShot(_gimmickSE);
            _canPlay = false;
        }

        base.OnLookAtActivation(target);
    }



}
