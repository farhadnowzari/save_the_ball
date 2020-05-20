using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace Utils.SkyboxRenderer {
    [System.Serializable]
    public class SkyboxRenderer {
        public List<GameObject> Skyboxes;
        public List<GameObject> ActiveSkyboxes {
            get;
            private set;
        }
        public float Speed;
        public float MaxSpeed;
        public float SpeedIncrementor;

        public SkyboxRenderer() {
            ActiveSkyboxes = new List<GameObject>();
        }
        public GameObject GetRandomSkybox() {
            var skyboxes = Skyboxes.OrderBy(o => Guid.NewGuid()).ToList();
            return skyboxes.First();
        }

        public void IncreaseSpeed() {
            if(Speed < MaxSpeed) {
                Speed += SpeedIncrementor;
            }
        }

        public void AddActiveBox(GameObject skybox) {
            ActiveSkyboxes.RemoveAll(a => a == null);
            if(ActiveSkyboxes.Count < 2) {
                ActiveSkyboxes.Add(skybox);
            }
        }

        public int CanSpawnCount() {
            ActiveSkyboxes.RemoveAll(a => a == null);
            return 2 - ActiveSkyboxes.Count;
        }
        
    }
}