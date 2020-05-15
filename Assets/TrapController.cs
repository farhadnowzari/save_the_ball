using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public List<GameObject> Saws;
    public float SawSpeed;
    public float MinimumHorizontalDistance;
    public float MaximumHorizontalDistance;

    private Dictionary<int, Direction2D> directions;
    void Awake()
    {
        directions = new Dictionary<int, Direction2D>();
        for(var i = 0; i < Saws.Count; i++) {
            if(Saws[i].transform.position.x < 0) {
                directions[i] = Direction2D.Right;
            } else {
                directions[i] = Direction2D.Left;
            }
        }
    }

    void Update()
    {
        for(var i = 0; i < Saws.Count; i++) {
            if(directions[i] == Direction2D.Right) {
                var rigidbody = Saws[i].GetComponent<Rigidbody2D>();
                rigidbody.velocity = Vector2.right * SawSpeed;
            } else {
                var rigidbody = Saws[i].GetComponent<Rigidbody2D>();
                rigidbody.velocity = Vector2.right * -SawSpeed;
            }
            if(Saws[i].transform.position.x > MaximumHorizontalDistance) {
                directions[i] = Direction2D.Left;
            } else if(Saws[i].transform.position.x < MinimumHorizontalDistance) {
                directions[i] = Direction2D.Right;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var targetObject = other.gameObject;
        if(targetObject.layer == (int)Layers.Platform) {
            var platformController = targetObject.GetComponent<PlatformController>();
            platformController.DestroyMe();
        }
    }
}
