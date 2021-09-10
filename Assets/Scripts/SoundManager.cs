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
    [SerializeField, Range(0, 1), Tooltip("マスタ音量")]
    float volume = 1;
    [SerializeField, Range(0, 1), Tooltip("BGMの音量")]
    float bgmVolume = 1;
    [SerializeField, Range(0, 1), Tooltip("SEの音量")]
    float seVolume = 1;

    //AudioSource（スピーカー）を同時に鳴らしたい音の数だけ用意
    private AudioSource[] SESourceList = new AudioSource[20];

    //別名(name)をキーとした管理用Dictionary
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
        //auidioSourceList配列の数だけAudioSourceを自分自身に生成して配列に格納
        for (var i = 0; i < SESourceList.Length; ++i)
        {
            SESourceList[i] = gameObject.AddComponent<AudioSource>();
        }
        bgmAudioSource = gameObject.AddComponent<AudioSource>();

        //SEDictionaryにセット
        foreach (var SEData in SEDatas)
        {
            SEDictionary.Add(SEData.name, SEData);
        }
        foreach (var BGMData in BGMDatas)
        {
            BGMDictionary.Add(BGMData.name, BGMData);
        }
    }

    //未使用のAudioSourceの取得 全て使用中の場合はnullを返却
    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < SESourceList.Length; ++i)
        {
            if (SESourceList[i].isPlaying == false) return SESourceList[i];
        }

        return null; //未使用のAudioSourceは見つかりませんでした
    }

    //指定されたAudioClipを未使用のAudioSourceで再生
    public void sePlay(AudioClip clip)
    {
        var SESource = GetUnusedAudioSource();
        if (SESource == null) return; //再生できませんでした
        SESource.clip = clip;
        SESource.volume = SeVolume * Volume;
        SESource.Play();
    }

    //指定された別名で登録されたAudioClipを再生
    public void sePlay(string name)
    {
        if (SEDictionary.TryGetValue(name, out var SEData)) //管理用Dictionary から、別名で探索
        {
            sePlay(SEData.audioClip); //見つかったら、再生
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
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
        if (BGMDictionary.TryGetValue(name, out var BGMData)) //管理用Dictionary から、別名で探索
        {
            bgmPlay(BGMData.audioClip); //見つかったら、再生
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }

    public void bgmStop()
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = null;
    }
}