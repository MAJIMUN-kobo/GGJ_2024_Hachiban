using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickCollider : MonoBehaviour
{
    private Player _self;
    private GameSceneManager _gameManager;
    private Transform _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        _self = GetComponent<Player>();
        _gameManager = GameObject.FindObjectOfType<GameSceneManager>();
        _mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        // Look Target;
        RaycastHit[] targets = Physics.BoxCastAll(_mainCamera.position, Vector3.one/10, _mainCamera.forward, Quaternion.identity, 5f);
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
