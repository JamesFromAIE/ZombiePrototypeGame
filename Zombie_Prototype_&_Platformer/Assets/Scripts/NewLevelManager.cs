using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {        
        // Links in-game Kill-cap to script Kill-cap
        killsTillLastWaveText.text = "Kills until Last Wave: " + killsTillLastWave;

        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Health is affected by damage from Enemies
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>().health;

        // Links in-game score and health to UI
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;

        if (score >= killsTillLastWave)
        {
            winText.gameObject.SetActive(true);
            Debug.Log("The winText function is running");
        }
  
    }


}
