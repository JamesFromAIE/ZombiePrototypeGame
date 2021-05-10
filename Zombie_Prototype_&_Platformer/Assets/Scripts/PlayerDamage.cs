using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public float health = 100.0f;
    public float timer = 0.0f;
    GameObject NewLevelManager;
    public GameObject painEffect;
    public float painTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        NewLevelManager = GameObject.FindGameObjectWithTag("NewLevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        // If Player Health hits 0, Restart Scene
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //Collision Function
    private void OnCollisionStay(Collision collision)
    {
        // If Enemy collides with Player
        if (collision.gameObject.tag == "Enemy")
        {
            //Time between damage
            timer = timer + Time.deltaTime;

            //Damage taken over time
            painTimer = painTimer - Time.deltaTime;

            if (timer >= 0.05)
            {
                health = health - 1 * NewLevelManager.GetComponent<NewLevelManager>().damageMultiplyer;
                timer = 0.0f;
            }

            //If PainTimer hits 0, Play pain Sound & Particle effect
            if (painTimer <= 0.0)
            {
                Instantiate(painEffect, transform.position, Quaternion.identity);
                painTimer = 1.0f;
            }
        }
    }
}
