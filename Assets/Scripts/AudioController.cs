using UnityEngine;
using Models.Sound;
using Models.Playlist;
using System.Collections.Generic;
using System.Linq;
public class AudioController : MonoBehaviour
{
    public List<Sound>  Sounds;
    public List<Playlist> Playlists;
    void Awake()
    {
        foreach(var sound in Sounds) {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
        var playlist = Playlists.First();
        playlist.RandomClip(gameObject);
        playlist.Source.Play();
    }

    void Update()
    {

    }

    public void Play(string name, float delay = 0, bool replay = true) {
        var sound = Sounds.FirstOrDefault(s => s.Name == name);
        if(sound == null) return;
        if(!replay && sound.Source.isPlaying) return;
        sound.Source.PlayDelayed(delay);
    }

    public void PlayOneShot(string name) {
        var sound = Sounds.FirstOrDefault(s => s.Name == name);
        if(sound == null) return;
        sound.Source.PlayOneShot(sound.Clip);
    }

    public void Stop(string name) {
        var sound = Sounds.FirstOrDefault(s => s.Name == name);
        if(sound == null) return;
        if(!sound.Source.isPlaying) return;
        sound.Source.Stop();
    }
}
