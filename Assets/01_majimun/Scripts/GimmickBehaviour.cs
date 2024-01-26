using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class GimmickBehaviour : MonoBehaviour, IGimmick
{
    // [ Serialize ]
    [SerializeField] private GimmickBehaviour _subGimmick;
    [SerializeField] private bool _activeAbsolute = false;
    [SerializeField, Range(0, 100)]  private int _activeRate = 50;
    [SerializeField] private float _lookSearchTime = 1;

    // [ Property ]
    public bool IsActive { get ; set;}
    public int  GetActiveRate { get { return _activeRate; } }

    protected GimmickManager _gimmickManager;
    protected float _lookTimer;
    protected float _nLookTimer;

    private void FixedUpdate()
    {
        if( _nLookTimer == _lookTimer )
        {
            OnLookAtCanceled();
        }
        _lookTimer = _nLookTimer;
    }

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

    public void LookAtUpdate(GameObject target)
    {
        _nLookTimer = _lookTimer;
        _nLookTimer += Time.deltaTime;
        if(_nLookTimer >= _lookSearchTime )
        {
            _nLookTimer = 0;
            _lookTimer = 0;
            OnLookAtActivation(target);
        }
    }

    public void OnLookAtCanceled()
    {
        _lookTimer = 0;
        _nLookTimer = 0;
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
