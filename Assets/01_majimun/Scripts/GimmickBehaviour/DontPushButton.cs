using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontPushButton : GimmickBehaviour
{
    // [ Firld ]
    [SerializeField] private AudioSource _audioSelf;
    [SerializeField] private AudioClip   _gimmickSE;
    [SerializeField] private GimmickBehaviour[] _gimmicks;
    [SerializeField] private Transform _effect;


    // [ Activate gimmick action, ]
    public override void OnTriggerActivation( GameObject target = null )
    {
        if( _canPlay )
        {
            int r = Random.Range(0, _gimmicks.Length);
            Vector3 pos = Camera.main.transform.position - Camera.main.transform.forward * 2;
            pos.y = 0;
            GimmickBehaviour clone = Instantiate(_gimmicks[r], pos, Quaternion.identity);
            Destroy(Instantiate(_effect, this.transform.position, Quaternion.identity).gameObject, 5f);
            Vector3 look = Camera.main.transform.position;
            clone.transform.LookAt(look);
            clone.transform.eulerAngles = Vector3.Scale(clone.transform.eulerAngles, Vector3.up);
            _audioSelf.PlayOneShot( _gimmickSE );
            clone.IsActive = true;
            clone.Setup(_gimmickManager);
            _canPlay = false;
            Debug.Log($"Don't push button gimmick.");
        }

        base.OnTriggerActivation(target);
    }
}
