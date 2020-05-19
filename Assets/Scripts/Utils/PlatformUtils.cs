using System;
using System.Collections.Generic;
using Utils.PlatformRenderer;

namespace Utils.PlatformUtils {
    public static class PlatformUtils {
        public static PlatformType RandomizePlatformType() {
            var score = Game.CurrentScore;
            var types = new List<PlatformType>();
            if(score <= 100) {
                types.Add(PlatformType.LongPlatform);
            } else if(score > 100 && score < 200) {
                types.Add(PlatformType.LongPlatform);
                types.Add(PlatformType.ShortPlatform);
            } else {
                types.Add(PlatformType.LongPlatform);
                types.Add(PlatformType.ShortPlatform);
                types.Add(PlatformType.SinglePlatform);
            }
            var _types = types.ToArray();
            var randomIndex = UnityEngine.Random.Range(0, _types.Length);
            PlatformType randomPlatform = (PlatformType)_types.GetValue(randomIndex);
            return randomPlatform;
        }
    }
}