using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip audioClip;
    }

    [SerializeField]
    private SoundData[] SEDatas;
    [SerializeField]
    private SoundData[] BGMDatas;
    [SerializeField, Range(0, 1), Tooltip("�}�X�^����")]
    float volume = 1;
    [SerializeField, Range(0, 1), Tooltip("BGM�̉���")]
    float bgmVolume = 1;
    [SerializeField, Range(0, 1), Tooltip("SE�̉���")]
    float seVolume = 1;

    //AudioSource�i�X�s�[�J�[�j�𓯎��ɖ炵�������̐������p��
    private AudioSource[] SESourceList = new AudioSource[20];

    //�ʖ�(name)���L�[�Ƃ����Ǘ��pDictionary
    private Dictionary<string, SoundData> SEDictionary = new Dictionary<string, SoundData>();
    private Dictionary<string, SoundData> BGMDictionary = new Dictionary<string, SoundData>();

    AudioSource bgmAudioSource;
    AudioSource seAudioSource;
    public float Volume
    {
        set
        {
            volume = Mathf.Clamp01(value);
            bgmAudioSource.volume = bgmVolume * volume;
            seAudioSource.volume = seVolume * volume;
        }
        get
        {
            return volume;
        }
    }

    public float BgmVolume
    {
        set
        {
            bgmVolume = Mathf.Clamp01(value);
            bgmAudioSource.volume = bgmVolume * volume;
        }
        get
        {
            return bgmVolume;
        }
    }

    public float SeVolume
    {
        set
        {
            seVolume = Mathf.Clamp01(value);
            seAudioSource.volume = seVolume * volume;
        }
        get
        {
            return seVolume;
        }
    }

    private void Awake()
    {
        //auidioSourceList�z��̐�����AudioSource���������g�ɐ������Ĕz��Ɋi�[
        for (var i = 0; i < SESourceList.Length; ++i)
        {
            SESourceList[i] = gameObject.AddComponent<AudioSource>();
        }
        bgmAudioSource = gameObject.AddComponent<AudioSource>();

        //SEDictionary�ɃZ�b�g
        foreach (var SEData in SEDatas)
        {
            SEDictionary.Add(SEData.name, SEData);
        }
        foreach (var BGMData in BGMDatas)
        {
            BGMDictionary.Add(BGMData.name, BGMData);
        }
    }

    //���g�p��AudioSource�̎擾 �S�Ďg�p���̏ꍇ��null��ԋp
    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < SESourceList.Length; ++i)
        {
            if (SESourceList[i].isPlaying == false) return SESourceList[i];
        }

        return null; //���g�p��AudioSource�͌�����܂���ł���
    }

    //�w�肳�ꂽAudioClip�𖢎g�p��AudioSource�ōĐ�
    public void sePlay(AudioClip clip)
    {
        var SESource = GetUnusedAudioSource();
        if (SESource == null) return; //�Đ��ł��܂���ł���
        SESource.clip = clip;
        SESource.volume = SeVolume * Volume;
        SESource.Play();
    }

    //�w�肳�ꂽ�ʖ��œo�^���ꂽAudioClip���Đ�
    public void sePlay(string name)
    {
        if (SEDictionary.TryGetValue(name, out var SEData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
            sePlay(SEData.audioClip); //����������A�Đ�
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }

    public void bgmPlay(AudioClip clip)
    {
        var BGMSource = bgmAudioSource;
        BGMSource.clip = clip;
        BGMSource.loop = true;
        BGMSource.volume = BgmVolume * Volume;
        BGMSource.Play();
    }

    public void bgmPlay(string name)
    {
        if (BGMDictionary.TryGetValue(name, out var BGMData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
            bgmPlay(BGMData.audioClip); //����������A�Đ�
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }

    public void bgmStop()
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = null;
    }
}