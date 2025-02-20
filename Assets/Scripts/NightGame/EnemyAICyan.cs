using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAICyan : MonoBehaviour
{
    //Enemy Name For Inspector
    public string EnemyName;
    //Enemy Difficulty
    [Range(-1, 20)] public int Difficulty;
    //Enemy Value
    public int EnemyWalkMin,EnemyWalkMax,WalkOpportunity,EnemyPosition;
    public float EnemyOpportunityDelay = 5;
    //Enemy Path and Visible indication
    public int[] EnemyPath;
    public GameObject[] ObjectMovementSystem;
    //Door Script for Win condition
    public DoorSystem DoorScript;
    public int DoorEnemyWalksat;
    //Moving Visual Indication
    public UITransScript UITransScript;
    //Sound stuff
    public AudioOutput AudioOutput;

    //MainNight System
    public MainNightScript MainNightScript;

    //ExtraCustomization
    public bool CanBackTrack;

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

        if (WalkOpportunity == 0 && CanBackTrack == true && EnemyPosition < ObjectMovementSystem.Length - 2){
            if(EnemyPosition > 0){
                UITransScript.EnemyFadeIn();
                EnemyPosition--;
                for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(i == EnemyPath[EnemyPosition]);}
            }
        }
        if (WalkOpportunity == 1){
                UITransScript.EnemyFadeIn();
                if(EnemyPosition < ObjectMovementSystem.Length-1){EnemyPosition++;}
                Debug.Log(EnemyName + " Was Triggered to Move with Pos of " + EnemyPosition); 
                if (EnemyPosition < ObjectMovementSystem.Length){
                    for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(i == EnemyPath[EnemyPosition]);}
                }

                if (EnemyPosition >= ObjectMovementSystem.Length-1 && DoorScript.DoorIDisclosed[DoorEnemyWalksat] == false){
                    //BeStuck there
                    EnemyOpportunityDelay = 1;
                    MainNightScript.CanUsePowerGen = false;
                    MainNightScript.BatteryButton.material.color = MainNightScript.BatteryDownColor;
                    if(MainNightScript.BatteryLife >= MainNightScript.BatteryLifeMAX){MainNightScript.BatteryLife -= 1*Difficulty;}
                    else if(MainNightScript.BatteryLife <= MainNightScript.BatteryLifeMAX/3 && MainNightScript.BatteryLife > 0){MainNightScript.BatteryLife -= 1;}
                    else if(MainNightScript.BatteryLife <= MainNightScript.BatteryLifeMAX/2 && MainNightScript.BatteryLife > MainNightScript.BatteryLifeMAX/3){MainNightScript.BatteryLife -= 2;}
                    else if(MainNightScript.BatteryLife < MainNightScript.BatteryLifeMAX && MainNightScript.BatteryLife > MainNightScript.BatteryLifeMAX/2){MainNightScript.BatteryLife -= 3;}
                    MainNightScript.BatteryLeftText.text = MainNightScript.BatteryLife + "% BATTERY";
                }
                else if (EnemyPosition >= ObjectMovementSystem.Length-1 && DoorScript.DoorIDisclosed[DoorEnemyWalksat] == true){
                    MainNightScript.CanUsePowerGen = true;
                    if(MainNightScript.BatteryLife > 0){MainNightScript.BatteryButton.material.color = MainNightScript.BatteryUpColor;}
                    EnemyOpportunityDelay = 5;
                    AudioOutput.PlaySound(8);
                    EnemyPosition = 0;
                    WalkOpportunity = 0;
                    for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(i == EnemyPath[EnemyPosition]);}
                }
        }
        Invoke("Active", EnemyOpportunityDelay);
    }

    public void ChangeDifficulty(int DifficultyValue){
        Difficulty = DifficultyValue;
        if (Difficulty > 0){EnemyWalkMin = 0; EnemyWalkMax = 40/Difficulty;} 
    }
    public void EnemyClose(){
        Inactive();
        EnemyPosition = 0;
        WalkOpportunity = 0;
        for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(i == EnemyPath[EnemyPosition]);}
    }
}
