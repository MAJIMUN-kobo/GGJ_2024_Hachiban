using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if( collision.transform.tag.Contains("Gimmick"))
        {
            GimmickBehaviour behaviour = collision.transform.GetComponent<GimmickBehaviour>();
            behaviour.GimmickActionEvent();
        }
    }
}
