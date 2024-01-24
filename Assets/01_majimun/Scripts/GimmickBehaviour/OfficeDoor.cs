using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OfficeDoor : GimmickBehaviour
{
    [SerializeField] private PlayableDirector _timeline;
    [SerializeField] private AudioClip        _doorSE;
    [SerializeField] private AudioSource      _doorAudio;

    // [ Activate gimmick action. ]
    public override void OnTriggerActivation(GameObject target = null)
    {
        _timeline.Play();
        _doorAudio.PlayOneShot(_doorSE);

        Debug.Log("Office Door!!");

        base.OnTriggerActivation(target);
    }
}
