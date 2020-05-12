using UnityEngine;
using Utils.InputUtils;

public class MovementController : MonoBehaviour
{
    #region Properties
    public Direction2D Direction;
    [Range(0, 100)]
    public float Speed;
    #endregion
    private Rigidbody2D mainRigidBody;  
    void Awake()
    {
        mainRigidBody = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        setDirection();
    }

    void FixedUpdate()
    {
        move();
    }

    void setDirection() {
        this.Direction = InputUtils.GoingRight() ? Direction2D.Right : Direction2D.Left;
    }

    void move() {
        var movingHorizontaly = InputUtils.MovingHorizontaly();
        var velocityX = movingHorizontaly ? Speed * (int)Direction : 0;
        var velocityY = mainRigidBody.velocity.y;
        mainRigidBody.velocity = new Vector2(velocityX, velocityY);
    }
}
