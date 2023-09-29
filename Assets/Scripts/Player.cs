using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rbody;
    private Vector2 dir;
    Animator anim;

    public AudioSource Walkingsound;
    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rbody.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }

    public void InputSys()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        dir = new Vector2(h, v).normalized;
    }

    void Update()
    {
        InputSys();

        if (rbody.velocity.magnitude > 0)
        {
            Walkingsound.Play();
            anim.SetBool("walk", true);
        }
        if (rbody.velocity.magnitude == 0)
        {
            //Walkingsound.Stop();
            anim.SetBool("walk", false);
        }
    }


}
