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
        showText(point, textColor);
        PlayerScore += point;
    }
    
    void showText(float point, Color textColor) {
        var textMeshComponent = TextMesh.GetComponent<TextMesh>();
        textMeshComponent.text = point.ToString();
        textMeshComponent.color = textColor;
        var position = new Vector3(TextPlaceholder.position.x, TextPlaceholder.position.y, 0);
        var textMesh = Instantiate(TextMesh, position, Quaternion.identity, transform);
    }
}
