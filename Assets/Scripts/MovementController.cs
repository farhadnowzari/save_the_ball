using UnityEngine;
using Utils.InputUtils;

public class MovementController : MonoBehaviour
{
    #region Properties
    public Direction2D Direction;
    private Direction2D direction;
    [Range(0, 100)]
    public float SpeedX;
    #endregion
    private Rigidbody2D mainRigidBody;

    private Animator animator;
    void Awake()
    {
        mainRigidBody = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
        direction = Direction;
    }

    void Update()
    {
        setDirection();
    }

    void FixedUpdate()
    {
        move();
        runAnimations();
    }

    void setDirection() {
        if(!InputUtils.MovingHorizontaly()) return;
        this.Direction = InputUtils.GoingRight() ? Direction2D.Right : Direction2D.Left;
        if((Direction == Direction2D.Left || Direction == Direction2D.Right) && direction != Direction) {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 0);
            direction = Direction;
        }
    }

    void move() {
        var movingHorizontaly = InputUtils.MovingHorizontaly();
        var velocityX = movingHorizontaly ? SpeedX * (int)Direction : 0;
        var velocityY = mainRigidBody.velocity.y;
        mainRigidBody.velocity = new Vector2(velocityX, velocityY);
    }

    void runAnimations() {
        if(mainRigidBody.velocity.y < 0) {
            animator.SetBool("grounded", true);
        } else {
            animator.SetBool("grounded", false);
        }
        if(InputUtils.MovingHorizontaly()) {
            animator.SetFloat("speed", 1);
        } else {
            animator.SetFloat("speed", 0);
        }
    }
}
