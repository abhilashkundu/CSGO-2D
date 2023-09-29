using UnityEngine;

public class bullet : MonoBehaviour
{
    private Vector3 mouseposition;
    public Transform bulletsend;
    private Camera maincam;
    private Rigidbody2D rrb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rrb = GetComponent<Rigidbody2D>();
        mouseposition = maincam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouseposition - transform.position;
        Vector3 rotation = transform.position - mouseposition;
        rrb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rott = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rott + 180);
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall" && collision.gameObject.tag == "enemy")
        {
            transform.position = bulletsend.position;
        }
    }
}
