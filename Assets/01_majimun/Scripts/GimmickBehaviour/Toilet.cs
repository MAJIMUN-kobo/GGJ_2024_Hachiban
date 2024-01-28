using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Toilet : GimmickBehaviour
{
    // [ Serialize ]
    [ SerializeField ] private AudioClip   _flushSE;
    [ SerializeField ] private AudioSource _toiletAudio;
    
    private GameSceneManager _gameSceneManager;

    private void Start()
    {
        _gameSceneManager = GameObject.FindObjectOfType<GameSceneManager>();
    }


    public async override void OnTriggerActivation(GameObject target)
    {
        Player player = target.GetComponent<Player>();

        if(_canPlay)
        {
            _toiletAudio.PlayOneShot( _flushSE );
            _canPlay = false;
            _gameSceneManager.gameMode = (int)GameSceneManager.GameSceneMode.Exit;
            player.InuptDisable();
            
            SceneLoader.canLevelMove = false;
            
            await Task.Delay( 1000 * 10 );

            SceneLoader.Instance.LoadScene("TitleScene").Forget();
            SceneLoader.canLevelMove = true;
            base.OnTriggerActivation(target);
        }
    }
}
