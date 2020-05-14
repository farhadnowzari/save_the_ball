using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace Utils.PlatformRenderer {
    public enum PlatformType {
        ShortPlatform,
        LongPlatform,
    }
    [System.Serializable]
    public class PlatformRenderer {
        public List<Transform> ShortPlatformPlaceholders;
        public GameObject ShortPlatform;
        public float MaximumTimeBetweenSpawn;
        public float PlatformSpeedIncrement;
        public float PlatformSpeed;
        public float PlatformMaxSpeed;
        public float TimeBetweenSpawn;
        public float TimeBetweenSpawnIncrementor;
        private float timeBetweenSpawn;


        public PlatformRenderer() {
            timeBetweenSpawn = TimeBetweenSpawn;
        }

        public bool CanSpawn() {
            if(timeBetweenSpawn <= 0) {
                if(TimeBetweenSpawn < MaximumTimeBetweenSpawn) {
                    TimeBetweenSpawn += TimeBetweenSpawnIncrementor;
                } 
                timeBetweenSpawn = TimeBetweenSpawn;
                return true;
            } else {
                timeBetweenSpawn -= Time.deltaTime;
                return false;
            }
        }

        public void ShuffleShortPlatforms() {
            ShortPlatformPlaceholders = ShortPlatformPlaceholders.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public void IncreaseSpeed() {
            if(this.PlatformSpeed < this.PlatformMaxSpeed) {
                this.PlatformSpeed += this.PlatformSpeedIncrement;
            }
       }

    }        
}