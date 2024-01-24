using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OfficeDoor : GimmickBehaviour
{
    [SerializeField] private PlayableDirector _timeline;

    // [ Activate gimmick action. ]
    public override void GimmickActionEvent(GameObject target = null)
    {
        _timeline.Play();

        base.GimmickActionEvent(target);
    }
}
