using UnityEngine;

public class PickupEventController : MonoBehaviour
{
    public Transform loca;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playertriggereventmanager")
        {
            transform.position = loca.position;
        }
    }
}
