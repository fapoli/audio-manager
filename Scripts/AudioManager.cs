using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioManager))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public List<AudioConfig> audioClips;

    private GroupSequence<string, AudioConfig> clipsByName = new GroupSequence<string, AudioConfig>();
    private AudioSource audioSource;
    private AudioClip currentClips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        foreach (var clip in audioClips)
        {
            var groupName = clip.audioGroup.Length > 0 ?
                clip.audioGroup :
                clip.audioClip.name;

            clipsByName.Add(groupName, clip);
        }

        instance = this;
    }

    public void Play(AudioClip clip, float volume = 1f)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void Play(string groupName)
    {
        if (!clipsByName.ContainsKey(groupName)) return;

        var clip = clipsByName.GetRandom(groupName);
        Play(clip.audioClip, clip.volume);
    }

    public void PlaySequence(string groupName)
    {
        if (!clipsByName.ContainsKey(groupName)) return;

        var clip = clipsByName.Next(groupName);
        Play(clip.audioClip, clip.volume);
    }
}

[System.Serializable]
public class AudioConfig
{
    public AudioClip audioClip;
    public string audioGroup;
    public float volume = 1;
}
