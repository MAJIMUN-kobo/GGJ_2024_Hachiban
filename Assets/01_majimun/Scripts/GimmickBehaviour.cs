using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GimmickBehaviour : MonoBehaviour, IGimmick
{
    // [ Serialize ]
    [SerializeField] private GimmickBehaviour _subGimmick;
    [SerializeField] private bool _activeAbsolute;
    [SerializeField, Range(0, 100)]  private int _activeRate = 50;

    // [ Property ]
    public bool IsActive { get ; set;}
    public int  GetActiveRate { get { return _activeRate; } }

    protected GimmickManager _gimmickManager;

    // [ Initialize ]
    public void Setup(GimmickManager manager)
    {
        if( _activeAbsolute ) IsActive = true;
        this.gameObject.SetActive( IsActive );
        _gimmickManager = manager;
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
