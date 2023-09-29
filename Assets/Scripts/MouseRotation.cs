using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public int nosofbullets = 10;
    public int totnosofbullets = 100;
    private Camera Cam;
    private Vector3 mousepos;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletspawn;
    [SerializeField] private float timebetweenfire;
    private float timer;
    [SerializeField] private bool canfire = true;
    public Vector3 rot;
    public bool magfull = true;
    int m;
    public AudioSource bulletfire;
    public AudioSource gunreload;

    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        //print("Total Number of bullets : " + totnosofbullets);
        mousepos = Cam.ScreenToWorldPoint(Input.mousePosition);

        rot = mousepos - transform.position;

        float rotZ = (Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg);

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (totnosofbullets == 0)
        {
            canfire = false;
            magfull = false;
        }
        if (totnosofbullets < 50)
        {
            magfull = false;
        }
        if (totnosofbullets > 50)
        {
            magfull = true;
        }

        if (Input.GetKeyDown("r") && totnosofbullets > 0)
        {
            if (totnosofbullets <= 10)
            {
                if ((totnosofbullets + nosofbullets) <= 10)
                {
                    nosofbullets += totnosofbullets;
                    totnosofbullets = 0;
                }
                if ((totnosofbullets + nosofbullets) >= 10)
                {
                    m = (totnosofbullets + nosofbullets) - 10;
                    totnosofbullets = m;
                    nosofbullets = 10;
                }
            }
            if (totnosofbullets > 10)
            {
                if (nosofbullets == 0)
                {
                    nosofbullets = 10;
                    totnosofbullets -= 10;
                }
                if (nosofbullets > 0)
                {
                    m = nosofbullets;
                    m = 10 - m;
                    if (m > 10)
                    {
                        nosofbullets = 10;
                        m = m - nosofbullets;
                        totnosofbullets += m;
                    }
                    if (m < 10)
                    {
                        nosofbullets += m;
                        totnosofbullets -= m;
                    }
                }
            }
            gunreload.Play();
        }

        if (!canfire)
        {
            timer += Time.deltaTime;
            if (timer > timebetweenfire)
            {
                timer = 0;
                canfire = true;
            }
        }

        if (Input.GetMouseButton(0) && canfire == true && nosofbullets > 0 && totnosofbullets >= 0)
        {
            canfire = false;
            Instantiate(bullet, bulletspawn.position, Quaternion.identity);
            bulletfire.Play();
            nosofbullets--;
            //bullet.GetComponent<Rigidbody2D>().AddForce(rot * 5000);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bulletpickup")
        {
            totnosofbullets += 100;
            canfire = true;
        }
    }
}
