using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class EnemyAIHolo : MonoBehaviour
{
    //Enemy Name For Inspector
    public string EnemyName;
    //Enemy Difficulty
    [Range(-1, 20)] public float Difficulty;
    //Enemy Value
    public int EnemyWalkMin,EnemyWalkMax,WalkOpportunity,EnemyPosition;
    public float EnemyOpportunityDelay = 5;
    //Enemy Path and Visible indication
    public int[] EnemyPath;
    public GameObject[] ObjectMovementSystem;
    //Moving Visual Indication
    public UITransScript UITransScript;
    public DigitalGlitch[] DigitalGlitch;
    //Sound stuff
    public AudioOutput AudioOutput;

    //MainNight System
    public MainNightScript MainNightScript;

    void Start(){
        GameObject targetObject = GameObject.Find("UI transition Base");
        UITransScript = targetObject.GetComponent<UITransScript>();

        EnemyPosition = 0;
        for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(i == EnemyPath[EnemyPosition]);}
    }

    public void StartChangeEnemyAI() //To be able to call a start-like function with other scripts
    {
        if(Difficulty == -1){
            EnemyWalkMin = 0; EnemyWalkMax = 0; Inactive();
            for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(false);}
        }
        if(Difficulty == 0){
            EnemyWalkMin = 0; EnemyWalkMax = 0; Inactive();
        }
        if(Difficulty >= 1 && Difficulty <= 20){
            for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(i == EnemyPath[EnemyPosition]);}
            CancelInvoke("Active");
            Invoke("Active", 2f);
        }
    }

    void Inactive()
    {
        CancelInvoke("Active");
    }

    void Active()
    {
        WalkOpportunity = UnityEngine.Random.Range(EnemyWalkMin, EnemyWalkMax);

        if (WalkOpportunity == 1){
                UITransScript.EnemyFadeIn();
                EnemyPosition = UnityEngine.Random.Range(0, ObjectMovementSystem.Length);
                Debug.Log(EnemyName + " Was Triggered to Move with Pos of " + EnemyPosition); 
                for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(i == EnemyPath[EnemyPosition]);}
                for (int i2 = 0; i2 < DigitalGlitch.Length; i2++){
                    if(i2 == EnemyPosition){
                        DigitalGlitch[i2].enabled = true;
                    }
                    else{
                        DigitalGlitch[i2].enabled = false;
                    }
                }
                for (int i3 = 0; i3 < DigitalGlitch.Length; i3++){DigitalGlitch[i3].intensity = 0.7f + Difficulty/67f;}
        }
        Invoke("Active", EnemyOpportunityDelay);
    }

    public void ChangeDifficulty(float DifficultyValue){
        Difficulty = DifficultyValue;
        if (Difficulty > 0){EnemyWalkMin = 0; EnemyWalkMax = (int)(40f / Difficulty);} 
    }
    public void EnemyClose(){
        Inactive();
        EnemyPosition = 0;
        WalkOpportunity = 0;
        for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(i == EnemyPath[EnemyPosition]);}
    }
}
