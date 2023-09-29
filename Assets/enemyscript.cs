using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public int EnemyTotHealth = 100;
    /*    public Transform EnemyLoaction;
        public GameObject EnemyBulletPrefab;*/
    /* private float TimeBetweenFire;
     private float EnemyBulletTimer;
     private bool canenemyfire = true;*/

    /* void Update()
     {
         if (canenemyfire)
         {
             Instantiate(EnemyBulletPrefab, EnemyLoaction.position, Quaternion.identity);
             canenemyfire = false;
         }

         for (TimeBetweenFire = 0; TimeBetweenFire < 3f; TimeBetweenFire++)
         {
             canenemyfire = true;
         }

     }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            EnemyTotHealth -= 10;
            if (EnemyTotHealth == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
