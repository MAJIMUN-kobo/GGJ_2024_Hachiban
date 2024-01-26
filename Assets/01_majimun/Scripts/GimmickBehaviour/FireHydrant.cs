using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHydrant : GimmickBehaviour
{
    public override void OnTriggerActivation(GameObject target)
    {
        Debug.Log("Fire Hydrant Event...");

        base.OnTriggerActivation(target);
    }
}
