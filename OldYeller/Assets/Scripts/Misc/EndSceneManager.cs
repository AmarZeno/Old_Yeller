﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndSceneManager : MonoBehaviour {

    Text Results;
    Text Stats;
    private PlayerMovement playermove;

    // Use this for initialization
    void Start () {
        Results = GameObject.Find("Result").GetComponent<Text>();
        Stats = GameObject.Find("Stats").GetComponent<Text>();
        playermove = GameObject.Find("Player").GetComponent<PlayerMovement>();

        if (playermove.score == 0)
        {
            Results.text = "Nobody saw you shit? That's just a normal shit";
        }
        else if(playermove.score > 0 && playermove.score <=4)
        {
            Results.text = "Fetish level poop voyeurism";
        }
        else if (playermove.score > 4 && playermove.score <= 8)
        {
            Results.text = "You are the Toyota Corolla of shitting infront of people. Boringly Medium";
        }
        else if (playermove.score > 8 && playermove.score < 12)
        {
            Results.text = "A water-polo team's worth of people saw you shit";
        }
        else if (playermove.score >= 12)
        {
            Results.text = "It's sad when old people get dementia";
        }

        Stats.text = "Viewers: " + playermove.score + " Time: " + playermove.GameTime;
    }
	
	// Update is called once per frame
	void Update () {

        if(InputManager.Abutton())
        {
            SceneManager.LoadScene("CharacterSelect");
        }
	
	}
}