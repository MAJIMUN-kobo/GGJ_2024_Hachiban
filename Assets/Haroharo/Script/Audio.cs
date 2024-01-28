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

    //���y��炵�A��I����������
    IEnumerator Cor()
    {
        //���y��炷
        audioSource.PlayOneShot(audioClip);

        //��n�߂����Ƃ�\��
        Debug.Log("�J�n");

        //�I���܂őҋ@
        yield return new WaitWhile(() => audioSource.isPlaying);

        //�I���������Ƃ�\��
        Debug.Log("�I��");
        Destroy(gameObject);
    }
}
