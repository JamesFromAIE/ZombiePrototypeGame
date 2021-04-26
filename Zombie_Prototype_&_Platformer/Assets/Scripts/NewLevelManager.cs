using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewLevelManager : MonoBehaviour
{
    [HideInInspector] public int score;
    [HideInInspector] public float health;
    public float damageMultiplyer = 1.0f;
    public Text killsTillLastWaveText;
    public Text scoreText;
    public Text healthText;
    public Text winText;
    public int killsTillLastWave = 20;
    private int zombieNumber;
    private float winTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {        
        // Links in-game Kill-cap to script Kill-cap
        killsTillLastWaveText.text = "Kills until Last Wave: " + killsTillLastWave;

        winText.text = "";

        zombieNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        // Health is affected by damage from Enemies
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>().health;

        // Links in-game score and health to UI
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;

        zombieNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;


        if (score > killsTillLastWave && zombieNumber == 0)
                                     
        {
            winText.text = "YOU WIN!";
            restartScene();
        }
  
    }
    void restartScene()
    {

        //winTime starts COUNTING DOWN
        winTime -= Time.deltaTime;

        if (winTime < 0)
        {
            SceneManager.LoadScene("WholeScene");
        }
    }
        
        

}
