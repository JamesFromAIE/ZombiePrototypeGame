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

    // Collision Function
    private void OnTriggerEnter(Collider other)
    {
        // When Enemy collides with Death
        if (other.CompareTag("Enemy"))
        {
            NewLevelManager.GetComponent<NewLevelManager>().score++;
            Instantiate(splatEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        // If Player collides with 'Death'
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Level Reset");
        }
    }
}

