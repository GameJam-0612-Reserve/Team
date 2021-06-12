using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CGM_AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        [Header("字典检索名")]
        public string name;

        [Header("音频文件")]
        public AudioClip clip;

        [Header("分组")]
        public AudioMixerGroup audioGroup;

        [Header("音量")]
        [Range(0, 1)]
        public float volume=1;

        [Header("是否开局播放")]
        public bool playOnAwake=true;

        [Header("是否循环")]
        public bool isLoop = false;
    }

    public List<Sound> sounds;
    private Dictionary<string, Sound> audioDic;

    public AudioSource m_music;
    public GameObject m_sfx_Prefab;


    AudioMixer m_AudioMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioDic = new Dictionary<string, Sound>();
        foreach (var item in sounds)
        {
            audioDic.Add(item.name, item);
        }

        m_AudioMixer = Resources.Load<AudioMixer>("Audio/myAudioMixer");
    }

    public void PlayAudio(string name)
    {
        if (audioDic[name].audioGroup.name=="Music")
        {
            m_music.clip=audioDic[name].clip;
            m_music.volume = audioDic[name].volume;
            m_music.playOnAwake = audioDic[name].playOnAwake;
            m_music.loop = audioDic[name].isLoop;
            m_music.Play();
        }
        else if (audioDic[name].audioGroup.name == "SFX")
        {
            AudioSource temp= Instantiate(m_sfx_Prefab,this.transform).GetComponent<AudioSource>();
            temp.clip = audioDic[name].clip;
            temp.volume = audioDic[name].volume;
            temp.playOnAwake = audioDic[name].playOnAwake;
            temp.loop = audioDic[name].isLoop;
            temp.Play();
        }
    }

    public void StopMusic()
    {
        m_music.Stop();
    }
}
