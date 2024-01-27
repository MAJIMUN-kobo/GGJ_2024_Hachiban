using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : GimmickBehaviour
{
    [ SerializeField ] private AudioClip   _flushSE;
    [ SerializeField ] private AudioSource _toiletAudio;

    public override void OnTriggerActivation(GameObject target)
    {
        _toiletAudio.PlayOneShot( _flushSE );
        _gimmickManager.gimmickDiscoveredCount++;

        base.OnTriggerActivation(target);
    }
}
