using System;
using Utils.PlatformRenderer;

namespace Utils.PlatformUtils {
    public static class PlatformUtils {
        public static PlatformType RandomizePlatformType() {
            Array types = Enum.GetValues(typeof(PlatformType));
            var randomIndex = UnityEngine.Random.Range(0, types.Length);
            PlatformType randomPlatform = (PlatformType)types.GetValue(randomIndex);
            return randomPlatform;
        }
    }
}