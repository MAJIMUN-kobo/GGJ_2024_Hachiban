using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Toilet : GimmickBehaviour
{
    [ SerializeField ] private AudioClip   _flushSE;
    [ SerializeField ] private AudioSource _toiletAudio;

    public async override void OnTriggerActivation(GameObject target)
    {
        Player player = target.GetComponent<Player>();

        if(_canPlay)
        {
            _toiletAudio.PlayOneShot( _flushSE );
            _canPlay = false;
            player.InuptDisable();
            
            SceneLoader.canLevelMove = false;
            await Task.Delay( 5000 );

            SceneLoader.Instance.LoadScene("TitleScene").Forget();
            SceneLoader.canLevelMove = true;
            base.OnTriggerActivation(target);
        }
    }
}
