using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;


    private void Awake()
    {
        //Grab reference for rigidbody and animator from object
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();     //search for a rigidbody2d in the components of the player
                                                //  and store it on body reference
    }


    void Start()
    {
        
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput* speed, body.linearVelocity.y);


        //flip player when moving left-right
        if(horizontalInput > 00.1f) 
            transform.localScale = Vector3.one;
        else if (horizontalInput < -00.1f)
            transform.localScale = new Vector3(-1,1,1);

        //jump
        if (Input.GetKey(KeyCode.Space)&& grounded)
            Jump();
            


        //Set animator parameters 
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded",grounded);
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

}
