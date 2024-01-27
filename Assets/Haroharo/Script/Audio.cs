using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;

        if (audioSource.loop)
        {
            audioSource.Play();
        }
        else
        {
            StartCoroutine(Cor());
        }
    }

    //音楽を鳴らし、鳴り終わったら消す
    IEnumerator Cor()
    {
        //音楽を鳴らす
        audioSource.PlayOneShot(audioClip);

        //鳴り始めたことを表示
        Debug.Log("開始");

        //終了まで待機
        yield return new WaitWhile(() => audioSource.isPlaying);

        //終了したことを表示
        Debug.Log("終了");
        Destroy(gameObject);
    }
}
