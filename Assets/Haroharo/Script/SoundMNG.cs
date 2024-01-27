using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMNG : MonoBehaviour
{
    // Audio Source �̐ݒ�
    [SerializeField]
    private AudioSource MainAudioSource;

    // BGM�ݒ�
    [SerializeField]
    private AudioClip[] Sounds;

    // �t�F�[�h�C�����Ԃ̐ݒ�i�b�j
    [SerializeField]
    private float FadeInTime;

    // �t�F�[�h�A�E�g���Ԃ̐ݒ�i�b�j
    [SerializeField]
    private float FadeOutTime;

    // ���݂̃{�����[���v�Z�p
    private float SoundTime;

    // MAX�{�����[��
    private float MaxVol;

    // �Đ����̋Ȕԍ�
    private int SoundNum;

    // BGM��ԊǗ�
    public enum BGM_STATE
    {
        WAIT,
        FADE_IN,
        NOW_PLAY,
        FADE_OUT,
        FADE_STOP,
        PAUSE,
        END,
    }
    private BGM_STATE _bgm_state;
    private BGM_STATE _state_work;

    //-------------------------------------------------//

    // ���l�̏�����
    private void Awake()
    {
        MainAudioSource=GetComponent<AudioSource>();

        MainAudioSource.volume = 0.0f;

        SoundTime = 0.0f;
        MaxVol = 1.0f;
        SoundNum = 0;

        _bgm_state = BGM_STATE.WAIT;
        _state_work = BGM_STATE.WAIT;
    }

    // ���s���̏���
    private void Update()
    {
        switch (_bgm_state)
        {
            // �t�F�[�h�C������
            case BGM_STATE.FADE_IN:
                if (FadeInTime <= 0.0f)
                {
                    MainAudioSource.volume = MaxVol;
                    _bgm_state = BGM_STATE.NOW_PLAY;
                }
                else if (FadeInTime >= Sounds[SoundNum].length)
                {
                    SoundTime += Time.deltaTime;
                    if (SoundTime >= Sounds[SoundNum].length * 0.9f)
                    {
                        SoundTime = Sounds[SoundNum].length * 0.9f;
                        _bgm_state = BGM_STATE.NOW_PLAY;
                    }
                    MainAudioSource.volume = SoundTime / (Sounds[SoundNum].length * 0.9f) * MaxVol;
                }
                else
                {
                    SoundTime += Time.deltaTime;
                    if (SoundTime >= FadeInTime)
                    {
                        SoundTime = FadeInTime;
                        _bgm_state = BGM_STATE.NOW_PLAY;
                    }
                    MainAudioSource.volume = SoundTime / FadeInTime * MaxVol;
                }
                break;

            // �ʏ�Đ�������
            case BGM_STATE.NOW_PLAY:
                if (Sounds[SoundNum].length - MainAudioSource.time <= FadeOutTime)
                {
                    SoundTime = FadeOutTime;
                    _bgm_state = BGM_STATE.FADE_OUT;
                }
                break;

            // �t�F�[�h�A�E�g����
            case BGM_STATE.FADE_OUT:
                if (FadeOutTime > 0.0f)
                {
                    SoundTime -= Time.deltaTime;
                    if (SoundTime <= 0.0f)
                    {
                        SoundTime = 0.0f;
                    }
                    MainAudioSource.volume = SoundTime / FadeOutTime * MaxVol;
                }

                if (!MainAudioSource.isPlaying)
                {
                    _bgm_state = BGM_STATE.END;
                }
                break;

            // �t�F�[�h�A�E�g��~����
            case BGM_STATE.FADE_STOP:
                if (FadeOutTime > 0.0f)
                {
                    SoundTime -= Time.deltaTime;
                    if (SoundTime <= 0.0f)
                    {
                        SoundTime = 0.0f;
                        MainAudioSource.Stop();
                    }
                    MainAudioSource.volume = SoundTime / FadeOutTime * MaxVol;
                }
                else
                {
                    StopSoundNow();
                }

                if (!MainAudioSource.isPlaying)
                {
                    _bgm_state = BGM_STATE.END;
                }
                break;
        }
    }

    // �w��ԍ��̍Đ��i-1�Ń����_���Đ��j
    public void StartSoundNum(int _num)
    {
        // �Đ�����Ȕԍ��̎擾
        SoundNum = _num;

        // �ő�Ȑ�����
        if (0 <= SoundNum && SoundNum < Sounds.Length)
        {
            MainAudioSource.clip = Sounds[SoundNum];
        }
        else
        {
            // �ő�Ȑ����z����w��̏ꍇ�@�܂��� -1 �Ȃǂ��w�肳�ꂽ�ꍇ�̓����_���ŋȂ�I��
            SoundNum = UnityEngine.Random.Range(0, Sounds.Length);
            MainAudioSource.clip = Sounds[SoundNum];
        }

        MainAudioSource.Stop();
        SoundTime = 0.0f;
        MainAudioSource.volume = 0.0f;
        _bgm_state = BGM_STATE.FADE_IN;
        MainAudioSource.Play();
    }

    // �r���Đ��i-1�Ń����_���Đ��j
    public void StartSoundNum(int _num, float _time)
    {
        // �Đ�����Ȕԍ��̎擾
        SoundNum = _num;

        // �ő�Ȑ�����
        if (0 <= SoundNum && SoundNum < Sounds.Length)
        {
            MainAudioSource.clip = Sounds[SoundNum];
        }
        else
        {
            // �ő�Ȑ����z����w��̏ꍇ�@�܂��� -1 �Ȃǂ��w�肳�ꂽ�ꍇ�̓����_���ŋȂ�I��
            SoundNum = UnityEngine.Random.Range(0, Sounds.Length);
            MainAudioSource.clip = Sounds[SoundNum];
        }

        MainAudioSource.Stop();
        MainAudioSource.volume = MaxVol;

        if (_time < Sounds[SoundNum].length)
        {
            MainAudioSource.time = _time;
        }
        else
        {
            Debug.Log("���Ԏw�肪�Ȃ̍ő厞�Ԃ𒴂��Ă��܂�");
            MainAudioSource.time = 0;
        }

        _bgm_state = BGM_STATE.NOW_PLAY;
        MainAudioSource.Play();
    }

    // �Ȃ̈ꎞ��~
    public void SoundPause()
    {
        _state_work = _bgm_state;
        _bgm_state = BGM_STATE.PAUSE;
        MainAudioSource.Pause();
    }

    // �Ȃ̍ĊJ
    public void SoundUnPause()
    {
        _bgm_state = _state_work;
        MainAudioSource.UnPause();
    }

    // ����~
    public void StopSoundNow()
    {
        MainAudioSource.Stop();
        _bgm_state = BGM_STATE.END;
    }

    // �t�F�[�h��~
    public bool StopSoundFadeOut()
    {
        bool _re = false;

        if (_bgm_state == BGM_STATE.FADE_IN ||
            _bgm_state == BGM_STATE.NOW_PLAY)
        {
            SoundTime = FadeOutTime;
            _bgm_state = BGM_STATE.FADE_STOP;
            _re = true;
        }

        return _re;
    }

    //------------- Get & Set -------------//

    // ���݂̃X�e�[�^�X�擾
    public BGM_STATE GetNowBgmState()
    {
        return _bgm_state;
    }

    // ���݂̍Đ�BGM�ԍ��̎擾
    public int GetSoundNum()
    {
        return SoundNum;
    }

    // ���݂̍Đ����Ԏ擾
    public float GetAudioSourceTime()
    {
        return MainAudioSource.time;
    }

    // ���݂̋Ȃ̍ő�Đ����Ԃ̎擾
    public float GetNowPlaySoundMaxTime()
    {
        return Sounds[SoundNum].length;
    }

    // �t�F�[�h���Ԑݒ�
    public void SetFadeTime(float _InTime, float _OutTime)
    {
        FadeInTime = _InTime;
        FadeOutTime = _OutTime;
    }

    // �ő剹�ʕύX
    public void SetMaxVol(float _vol)
    {
        // �{�����[���̍ő�l���߃`�F�b�N
        if (_vol >= 1.0f)
        {
            _vol = 1.0f;
        }

        // �{�����[���̔��f
        MaxVol = _vol;

        // ���݂̃{�����[�����ő�l�ȏゾ�����ꍇ�ύX����
        if (MainAudioSource.volume >= MaxVol)
        {
            MainAudioSource.volume = MaxVol;
        }

        // �ʏ�Đ���Ԃ�MaxVol�����݂̃{�����[���l����������ύX����
        if (_bgm_state == BGM_STATE.NOW_PLAY)
        {
            if (MainAudioSource.volume < MaxVol)
            {
                MainAudioSource.volume = MaxVol;
            }
        }
    }

}
