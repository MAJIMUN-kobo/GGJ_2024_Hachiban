using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ToiletDoor : GimmickBehaviour
{
    // [ Field ]
    // [ Firld ]
    [SerializeField] private AudioSource _audioSelf;
    [SerializeField] private AudioClip   _gimmickSE;
    [SerializeField] private GimmickBehaviour[] _gimmicks;
    [SerializeField] private Transform _effect;
    [SerializeField] private Animator _animator;

    public override void OnTriggerActivation(GameObject target)
    {
        if(_canPlay)
        {
            int r = Random.Range(0, _gimmicks.Length);
            Vector3 pos = transform.position - transform.right * 2;
            pos.y = 0;
            GimmickBehaviour clone = Instantiate(_gimmicks[r], pos, Quaternion.identity);
            Destroy(Instantiate(_effect, pos, Quaternion.identity).gameObject, 5f);
            Vector3 look = Camera.main.transform.position;
            clone.transform.LookAt(look);
            clone.transform.eulerAngles = Vector3.Scale(clone.transform.eulerAngles, Vector3.up);
            
            clone.IsActive = true;
            clone.Setup(_gimmickManager);

            _canPlay = false;

            Debug.Log("Toilet door gimmick.");
        }

        _audioSelf.PlayOneShot( _gimmickSE );
        _animator.SetTrigger("DoorAction");
        Debug.Log("hoge");

        base.OnTriggerActivation(target);
    }
}
