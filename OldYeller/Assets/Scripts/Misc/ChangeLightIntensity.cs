
using UnityEngine;
using System.Collections;

public class ChangeLightIntensity : MonoBehaviour {

    /*a control variable when the player yells*/
    public bool hasYelled = false;
    /* after how long will the next yell come*/
    public float timeForNextYell = 3f;      
    private float currentTime;
    private float currentMikeTime;          
    private Light lightComponent;
    public float maxLightRange;

    /*-----------------MIKE CONTROLS-------------------*/
    /*set the threshold value for yelling*/
    public float yellThreshold;    
    private MicrophoneInput mikeInput;  //get the reference of the mike script

    void Start() {
        currentTime = Time.deltaTime;
        currentMikeTime = Time.deltaTime;
        /*get the reference of the light*/
        lightComponent = gameObject.GetComponent<Light>();
        /*clamp the range of the light*/
        lightComponent.range = Mathf.Clamp(lightComponent.range, 0f, maxLightRange);

        mikeInput = GameObject.FindGameObjectWithTag("Yeller").GetComponent<MicrophoneInput>();
    }

    void Update() {

        if(YellIntensity() > yellThreshold) {
            if (lightComponent.range < maxLightRange) {
                IncrementLightRange();
            }
        } else {
            DecrementLightrange();
        }

        /*------------------------obsolete code NOW------------------------*/
        //if (hasYelled == true) {
        //    /*we want the light to fade in and out before the next yell comes, half in for fade in and other half for fade out*/
        //    if(currentTime <= timeForNextYell / 2) {
        //        if(lightComponent.range < maxLightRange) {
        //            IncrementLightRange();
        //        }
        //        /*keep incrementing the timer*/
        //        currentTime += Time.deltaTime;
        //    } else {
        //        DecrementLightrange();
        //        if(lightComponent.range < 1) {
        //            /*reset the hasYelled*/
        //            hasYelled = false;
        //            currentTime = 0f;
        //        }
        //    }
        //}
        /*------------------------obsolete code NOW------------------------*/
    }

    private void IncrementLightRange() {
        lightComponent.range += 1f;
    }

    private void DecrementLightrange() {
        lightComponent.range -= 1f;
    }

    private float YellIntensity() {
        return mikeInput.MicLoudness;
    }
}
