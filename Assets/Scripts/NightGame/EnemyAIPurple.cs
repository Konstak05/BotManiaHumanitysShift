using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class EnemyAIPurple : MonoBehaviour
{
    //Enemy Name For Inspector
    public string EnemyName;
    //Enemy Difficulty
    [Range(-1, 20)] public float Difficulty;
    //Enemy Value
    public int EnemyWalkMin,EnemyWalkMax,WalkOpportunity,EnemyPosition,IsAlreadyOnCam;
    public float EnemyOpportunityDelay = 5;
    //Enemy Path and Visible indication
    public int[] EnemyPath;
    public GameObject[] ObjectMovementSystem;
    //Sound stuff
    public AudioOutput AudioOutput;

    //MainNight System
    public MainNightScript MainNightScript;
    public DoorSystem DoorSystem;

    //Security Cam stuff
    public SecurityCamSystem SecurityCamSystem;

    void Start(){

        EnemyPosition = 0;
        for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(false);}
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
            Gotclosed();
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

        if (WalkOpportunity == 1 && IsAlreadyOnCam == 0){
                EnemyPosition = UnityEngine.Random.Range(0, ObjectMovementSystem.Length);
                Debug.Log(EnemyName + " Was Triggered to Move with Pos of " + EnemyPosition); 
                for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(i == EnemyPath[EnemyPosition]);}
                AudioOutput.PlaySound(9);

                //SecurityCamIndication
                SecurityCamSystem.PurpleDeactivated[EnemyPosition] = true;
                SecurityCamSystem.UpdateColor(EnemyPosition);
                //DoorrelatedSystems
                int closedoor = UnityEngine.Random.Range(0, 3);
                DoorSystem.PurpleDeactivated[closedoor] = true;
                //Check to make sure it doesn't trigger again
                IsAlreadyOnCam = 1;
        }
        Invoke("Active", EnemyOpportunityDelay);
    }

    public void Gotclosed(){
        IsAlreadyOnCam = 0;
        //ClosePopups to be sure
        for (int i = 0; i < ObjectMovementSystem.Length; i++){ObjectMovementSystem[i].SetActive(false);}
        //Doorsystem
        for (int i2 = 0; i2 < DoorSystem.PurpleDeactivated.Length; i2++){DoorSystem.PurpleDeactivated[i2] = false;}
        //CameraSystem
        for (int i3 = 0; i3 < SecurityCamSystem.PurpleDeactivated.Length; i3++){SecurityCamSystem.PurpleDeactivated[i3] = false;}
        SecurityCamSystem.UpdateColorStandalone();
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
