using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : GimmickBehaviour
{
    // [ Activate gimmick action, ]
    public override void OnTriggerActivation(GameObject target = null)
    {
        Debug.Log("Elevator gimmick.");

        int discovered = _gimmickManager.gimmickDiscoveredCount;
        if( discovered >= 1 )
        {
            _gimmickManager?.Initialize();
            _gimmickManager.stageLevel++;
        }

        base.OnTriggerActivation(target);
    }

    public override void OnLookAtActivation(GameObject target)
    {
        Debug.Log("Elevator look activate.");

        base.OnLookAtActivation(target);
    }
}
