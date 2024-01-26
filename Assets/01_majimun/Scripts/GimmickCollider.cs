using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickCollider : MonoBehaviour
{
    private Player _self;
    private GameSceneManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _self = GetComponent<Player>();
        _gameManager = GameObject.FindObjectOfType<GameSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        RaycastHit[] targets = Physics.BoxCastAll(transform.position, Vector3.one/10, transform.forward, Quaternion.identity, 5f);
        foreach (RaycastHit target in targets) 
        {
            if( target.transform.tag.Contains("Gimmick"))
            {
                GimmickBehaviour behaviour = target.transform.GetComponent<GimmickBehaviour>();
                behaviour.LookAtUpdate(this.gameObject);
                
                //Debug.Log($"target = { target.transform.name }");
            }

        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if( collision.transform.tag.Contains("Gimmick"))
        {
            GimmickBehaviour behaviour = collision.transform.GetComponent<GimmickBehaviour>();
            behaviour.OnTriggerActivation(this.gameObject);
        }
    }
}
