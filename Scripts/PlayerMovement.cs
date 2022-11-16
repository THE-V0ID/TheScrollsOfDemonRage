using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool grounded; 
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput < 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput > -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);


        if (Input.GetKey(KeyCode.Space) && grounded)
            jump();

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void jump()
    {
     // if(isGrounded())

        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            grounded = false;
            //  anim.setTrigger("Jump");
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Ground")
        grounded = true;
    }

  //  private bool isGrounded()
  //  {
    //    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
    //    return raycastHit.collider != null;
  //  }
}