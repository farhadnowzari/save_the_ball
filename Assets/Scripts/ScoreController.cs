using UnityEngine;
using UnityEngine.UI;
using Utils.ScoreUtils;
public class ScoreController : MonoBehaviour
{
    public Text ScoreText;

    // Update is called once per frame
    void Update()
    {
        if(Game.Ended) return;
        ScoreText.text = ((int)Game.CurrentScore).FormatScore(6);
    }
}
