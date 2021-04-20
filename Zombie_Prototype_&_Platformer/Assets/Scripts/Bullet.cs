using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100.0f;
    public GameObject splatEffect;
    GameObject NewLevelManager;

    // Start is called before the first frame update
    void Start()
    {
        NewLevelManager = GameObject.FindGameObjectWithTag("NewLevelManager");

        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        
        // DestroySelf after 5 seconds
        Invoke("DestroySelf", 5.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }

        // When Bullet collides with something
       private void OnCollisionEnter(Collision collision)
       {
        // When Bullet collides with "Enemy"
        if (collision.gameObject.tag == "Enemy")
           {
                NewLevelManager.GetComponent<NewLevelManager>().score++;
                Instantiate(splatEffect, collision.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
           }

        // When Bullet collides with ANYTHING else
             DestroySelf();
       }
        // When Bullet collides with NOTHING
       void DestroySelf()
           {
                Destroy(gameObject);
           }
}