using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GimmickBehaviour : MonoBehaviour, IGimmick
{
    // [ Serialize ]
    [SerializeField] private bool _activeAbsolute;

    // [ Property ]
    public bool IsActive { get ; set;}

    // [ Initialize ]
    public void Setup()
    {
        this.gameObject.SetActive( IsActive );
        if( _activeAbsolute ) this.gameObject.SetActive( true );
    }

    // [ Activate gimmick action. ]
    public virtual void OnTriggerActivation(GameObject target) { }

    // [ Activate gimmick action. ]
    public virtual void OnLookAtActivation(GameObject target) { }

    // [ Activate gimmick action. ]
    public virtual void OnInputActivation(GameObject target) { }
}
