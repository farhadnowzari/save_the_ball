using UnityEngine;
using UnityEngine.UI;
using Utils.ScoreUtils;
public class ScoreController : MonoBehaviour
{
    public Text ScoreText;
    private GameObject player;
    private PlayerScoreController playerScoreController;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player.ToString());
        playerScoreController = player.GetComponent<PlayerScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Game.Ended) return;
        var playerScore = playerScoreController.PlayerScore;
        ScoreText.text = ((int)playerScore).FormatScore(6);
    }
}
