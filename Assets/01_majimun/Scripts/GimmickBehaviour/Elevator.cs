using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : GimmickBehaviour
{
    // [ Activate gimmick action, ]
    public override void OnTriggerActivation(GameObject target = null)
    {
        Debug.Log("Elevator gimmick.");

        _gimmickManager.Initialize();

        base.OnTriggerActivation(target);
    }
}
