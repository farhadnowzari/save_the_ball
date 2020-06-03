using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreController : MonoBehaviour
{
    [HideInInspector]
    public float PlayerScore;
    public Transform TextPlaceholder;
    public GameObject TextMesh;

    public void GiveScore(float point, Color textColor) {
        var playerController = gameObject.GetComponent<PlayerController>();
        playerController.ShowText(buildText(point, textColor));
        PlayerScore += point;
        Game.CurrentScore = PlayerScore;
    }
    
    GameObject buildText(float point, Color textColor) {
        var textMeshComponent = TextMesh.GetComponent<TextMesh>();
        textMeshComponent.text = point.ToString();
        textMeshComponent.color = textColor;
        textMeshComponent.characterSize = 1f;
        return TextMesh;
    }
}
