using UnityEngine;
namespace Utils.ScoreUtils {
    public static class ScoreUtils {
        public static void GivePlayerPoint(GameObject player, float point, Color textColor) {
            var playerScoreController = player.GetComponent<PlayerScoreController>();
            if(playerScoreController != null) {
                playerScoreController.GiveScore(point, textColor);
            }
        }
        
        public static string FormatScore(this int score, int leadingZeros = 4) {
            return score.ToString("D" + leadingZeros);
        }
    }
}