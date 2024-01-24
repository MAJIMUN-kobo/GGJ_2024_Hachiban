using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : GimmickBehaviour
{
    // [ Update ]
    private void Update()
    {
        IsActive = true;
    }

    // [ Activate gimmick action, ]
    public override void OnTriggerActivation(GameObject target = null)
    {
        Debug.Log("Elevator gimmick.");

        UnityEngine.SceneManagement.SceneManager.LoadScene("DemoGimmickRoom");

        base.OnTriggerActivation(target);
    }
}
