using UnityEngine;
namespace Utils.ScoreUtils {
    public static class ScoreUtils {
        public static void GivePlayerPoint(GameObject player, float point) {
            var playerScoreController = player.GetComponent<PlayerScoreController>();
            if(playerScoreController != null) {
                playerScoreController.GiveScore(point);
            }
        }
    }
}