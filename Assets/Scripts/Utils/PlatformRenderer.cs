using System.Collections.Generic;
using UnityEngine;

namespace Utils.PlatformRenderer {
    public enum PlatformType {
        ShortPlatform,
        LongPlatform,
        SinglePlatform
    }
    [System.Serializable]
    public class PlatformRenderer {
        public List<GameObject> Walls;
        public List<Transform> Placeholders;
        public GameObject ShortPlatform;
        public GameObject LongPlatform;
        public GameObject SinglePlatform;
        public float PlatformSpeedIncrement;
        public float PlatformSpeed;
        public float PlatformMaxSpeed;
        public float TimeBetweenSpawn;
        private float timeBetweenSpawn;
        [HideInInspector]
        public int LastPlaceholderIndex {
            get {
                if(this.lastPlaceholerIndex == -1) {
                    lastPlaceholerIndex = UnityEngine.Random.Range(0, this.Placeholders.Count);
                    return lastPlaceholerIndex;
                }
                return this.lastPlaceholerIndex;
            }
            set {
                this.lastPlaceholerIndex = value; 
            }
        }
        private int lastPlaceholerIndex = -1;


        public PlatformRenderer() {
            timeBetweenSpawn = TimeBetweenSpawn;
        }

        public bool CanSpawn() {
            if(timeBetweenSpawn <= 0) {
                timeBetweenSpawn = TimeBetweenSpawn;
                return true;
            } else {
                timeBetweenSpawn -= Time.deltaTime;
                return false;
            }
        }

        public void IncreaseSpeed() {
            if(this.PlatformSpeed < this.PlatformMaxSpeed) {
                this.PlatformSpeed += this.PlatformSpeedIncrement;
                Game.Speed = this.PlatformSpeed;
            }
        }

        public int getLastPlaceholderIndex() {
            if(this.lastPlaceholerIndex == -1) {
                lastPlaceholerIndex = UnityEngine.Random.Range(0, this.Placeholders.Count);
                return lastPlaceholerIndex;
            }
            return this.lastPlaceholerIndex;
        }

        public void SlowDown(float amount) {
            PlatformSpeed -= amount;
        }
    }        
}