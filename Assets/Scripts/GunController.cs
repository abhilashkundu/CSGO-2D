using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private Vector3 mousepos;
    [SerializeField] private Transform bulletspawn;
    [SerializeField] private GameObject bullet;
    private float bullettime;
    [SerializeField] private float timebetweenshoot;
    [SerializeField] private bool canshoot;

    // Update is called once per frame
    void Update()
    {
        mousepos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousepos - transform.position;

        float z = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, z);

        if (!canshoot)
        {
            bullettime += Time.deltaTime;
            if (bullettime > timebetweenshoot)
            {
                canshoot = true;
            }
        }
        if (Input.GetMouseButtonDown(0) && canshoot)
        {
            canshoot = false;
            Instantiate(bullet, bulletspawn.position, Quaternion.identity);
        }
    }
}
