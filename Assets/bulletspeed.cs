using UnityEngine;

public class bulletspeed : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject playerr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerr = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = playerr.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * 10;
    }

    private void Update()
    {
        Destroy(this.gameObject, 2f);
    }
}
