using System;
using UnityEngine;


public enum SoundType
{ 
    blockFall,
    blockSpawn,
    death,
    jump,
    land,
    exit,
    walk
}
[RequireComponent(typeof(AudioSource)),ExecuteInEditMode]

public class AudioManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    private static AudioManager instance = null;
    [SerializeField] private AudioSource audioSource; 

    
    void Awake()
    {
        if(!instance)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
        }
        
    }

    public static void playSound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomclip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomclip, volume);

        //instance.audioSource.PlayOneShot(instance.soundList[(int)sound],volume);
    }

    [Serializable]
    public struct SoundList
    {
        public AudioClip[] Sounds { get => sounds; }
        [SerializeField] public string name;
        [SerializeField] public AudioClip[] sounds;


    }

#if UNITY_EDITOR

    private void OnEnable()
    {
        string[] names  = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList,names.Length);
        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }

    }

#endif
}
