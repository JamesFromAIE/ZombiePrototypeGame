using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject splatEffect;
    GameObject NewLevelManager;
    // Start is called before the first frame update
    void Start()
    {
        NewLevelManager = GameObject.FindGameObjectWithTag("NewLevelManager");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // When Enemy collides with Death
        if (collision.gameObject.tag == "Enemy")
        {
            NewLevelManager.GetComponent<NewLevelManager>().score++;
            Instantiate(splatEffect, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Level Reset");
        }
    }

}

