using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndSceneManager : MonoBehaviour {

    Text Results;
    Text Stats;
    Text WinLose;
    private PlayerMovement playermove;

    // Use this for initialization
    void Start () {
        Results = GameObject.Find("Result").GetComponent<Text>();
        WinLose = GameObject.Find("WinLose").GetComponent<Text>();
        Stats = GameObject.Find("Stats").GetComponent<Text>();
        playermove = GameObject.Find("Player").GetComponent<PlayerMovement>();


        if(playermove.shitHappened)
        {
            WinLose.text = "YOU WIN!";
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
        else
        {
            WinLose.text = "YOU LOSE!";
            Results.text = "Why bother playing if you weren't going to shit?";
            Stats.text = "Viewers: 0 Time: 15.0" ;
        }
            
        
    }
	
	// Update is called once per frame
	void Update () {

        if(InputManager.Abutton())
        {
            SceneManager.LoadScene("CharacterSelect");
        }
	
	}
}
