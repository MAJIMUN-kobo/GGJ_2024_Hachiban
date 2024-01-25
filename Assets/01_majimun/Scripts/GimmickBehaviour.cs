using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GimmickBehaviour : MonoBehaviour, IGimmick
{
    // [ Serialize ]
    [SerializeField] private GimmickBehaviour _subGimmick;
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
    public virtual void OnTriggerActivation(GameObject target) 
    {
        SubActivation(target);
    }

    // [ Activate gimmick action. ]
    public virtual void OnLookAtActivation(GameObject target)
    { 
        SubActivation(target); 
    }

    // [ Activate gimmick action. ]
    public virtual void OnInputActivation(GameObject target)
    { 
        SubActivation(target); 
    }

    // [ Activate gimmick action. ]
    public virtual void SubActivation(GameObject target) 
    {
        _subGimmick?.OnTriggerActivation(target);
    }
}
