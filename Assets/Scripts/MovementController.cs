using UnityEngine;
using Utils.InputUtils;

public class MovementController : MonoBehaviour
{
    #region Properties
    public Direction2D Direction;
    public GameObject Skin;
    private Direction2D direction;
    [Range(0, 100)]
    public float SpeedX;
    #endregion
    private Rigidbody2D mainRigidBody;
    private SpriteRenderer skinSpriteRenderer;
    private Animator skinAnimator;
    void Awake()
    {
        mainRigidBody = GetComponent<Rigidbody2D>();   
        skinSpriteRenderer = Skin.GetComponent<SpriteRenderer>();
        skinAnimator = Skin.GetComponent<Animator>();
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
            skinSpriteRenderer.flipX = !skinSpriteRenderer.flipX;
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
            skinAnimator.SetBool("grounded", true);
        } else {
            skinAnimator.SetBool("grounded", false);
        }
        if(InputUtils.MovingHorizontaly()) {
            skinAnimator.SetFloat("speed", 1);
        } else {
            skinAnimator.SetFloat("speed", 0);
        }
    }
}
