using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
namespace Models.Playlist {
    [Serializable]
    public class Playlist {
        public List<AudioClip> Clips;
        [Range(0f, 1f)]
        public float Volume;
        public string Name;
        [HideInInspector]
        public AudioSource Source;

        public AudioClip RandomClip(GameObject gameObject) {
            var clips = Clips.OrderBy(c => Guid.NewGuid()).ToList();
            var clip = clips.First();
            if(Source == null) {
                Source = gameObject.AddComponent<AudioSource>();
                Source.volume = Volume;
            }
            Source.clip = clip;
            Source.loop = true;
            return clip;
        }
    }
}