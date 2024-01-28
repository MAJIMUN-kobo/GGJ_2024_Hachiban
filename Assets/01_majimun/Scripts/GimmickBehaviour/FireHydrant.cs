using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHydrant : GimmickBehaviour
{
    // [ Serialize ]
    [SerializeField] private Transform _hydroEffect;
    [SerializeField] private AudioClip _hydroSE;


    public override void OnTriggerActivation(GameObject target)
    {
        Debug.Log("Fire Hydrant Event...");
        AudioManager audioManager = GameObject.FindObjectOfType<AudioManager>();
        audioManager.SEPlay(0, false);

        Transform effect = Instantiate(_hydroEffect, this.transform.position - new Vector3(0, 1, 0), Quaternion.identity);
        Destroy(effect.gameObject, 10);

        base.OnTriggerActivation(target);
    }
}
