using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttributes : MonoBehaviour
{

    public int playertothealth = 100;
    [SerializeField]
    MouseRotation bulpick;
    public bool healthfull = true;

    public Animator anima;

    public AudioSource bombplanted;
    public AudioSource youaredead;
    public AudioSource bombsound;

    public GameObject enemyprefab;
    public Transform[] enemytransform;
    private bool bombplantedbool;
    private bool bomeexplosiondone = false;

    [SerializeField] private int entryinbomblocation = 1;

    public GameObject bomb;

    private float timer = 1;
    private void Update()
    {
        if (playertothealth < 80)
        {
            healthfull = false;
        }
        if (playertothealth > 80)
        {
            healthfull = true;
        }
        if (entryinbomblocation == 2)
        {
            if (playertothealth == 0)
            {
                entryinbomblocation = 10;
                bombplanted.Stop();
                anima.SetBool("death", true);
                youaredead.Play();
                SceneManager.LoadScene("GameOver");
            }

            timer += 1;
            print(timer);
            if (timer > 5800 && bomeexplosiondone == false)
            {
                bomb.SetActive(true);
                bombsound.Play();
                bomeexplosiondone = true;
            }
            if (timer > 6000 && bomeexplosiondone == true)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            playertothealth -= 5;
            print(playertothealth);
        }
        if (collision.gameObject.tag == "HealthPickup" && !healthfull)
        {
            playertothealth = 100;
        }
        if (collision.gameObject.tag == "AmmoPickup" && bulpick.magfull == false)
        {
            bulpick.totnosofbullets = 100;
        }
        if (collision.gameObject.tag == "bomblocation" && entryinbomblocation == 1)
        {
            for (int pp = 0; pp < 11; pp++)
            {
                Instantiate(enemyprefab, enemytransform[pp].position, Quaternion.identity);
            }
            bombplanted.Play();
            entryinbomblocation = 2;
        }
    }
}
