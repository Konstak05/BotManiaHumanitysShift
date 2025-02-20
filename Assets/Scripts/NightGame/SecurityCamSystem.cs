using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecurityCamSystem : MonoBehaviour
{
    //Required for BatteryUsage
    public DoorSystem DoorSystem;

    public Animator checkCamAnim;
    public float CheckCamDelay,DelayTransitionsValue;
    public int CamCooldown; //CamCooldown so the player doesn't activate it mid-way
    public bool isCameraOpen; //Controlled by Event trigger Bottom Camera Button
    public bool[] OpenedCamera,PurpleDeactivated; //PurplehasDeactivated

    public GameObject BottomCamButton;
    public GameObject[] cameraSystem;
    public GameObject[] camerasShownWithID,CameraObjects;
    public Image[] Camerarenderers;
    public Color ColorON,ColorOFF,ColorPurple;

    //CameraMOffice Values
    public bool CanMoveHead = true;

    //Requirement for Sound
    public AudioOutput AudioOutput;

    void Start()
    {
        CanMoveHead = true;
        int cameraID = 0;
        for (int i = 0; i < camerasShownWithID.Length; i++){camerasShownWithID[i].SetActive(i == cameraID);}
        OpenedCamera[0] = true;
        UpdateColorStandalone();
        Invoke("CameraUpdater", 0.5f);
    }

    void CameraUpdater()
    {
        if(isCameraOpen == true){
            if(CheckCamDelay < 1){
                CheckCamDelay += DelayTransitionsValue;
                checkCamAnim.SetFloat("CameraMode", CheckCamDelay);
            }
            if(CheckCamDelay >= 1 && CamCooldown == 0){
                CamCooldown = 1;

                //for headmovement left and right
                CanMoveHead = false;
                for (int i = 0; i < cameraSystem.Length; i++){cameraSystem[i].SetActive(true);}

                //Key sound
                AudioOutput.PlaySound(1);
            }
        }
        if(isCameraOpen == false){
            if(CheckCamDelay > 0){
                CheckCamDelay -= DelayTransitionsValue;
                checkCamAnim.SetFloat("CameraMode", CheckCamDelay);
            }
            if(CheckCamDelay <= 0 && CamCooldown == 0){
                CamCooldown = 1;

                //for headmovement left and right
                CanMoveHead = true;
            }
        }
        Invoke("CameraUpdater", 0.02f);
    }
    //CameraRotationAnimation
    public void IsRotatingToggle(){
        if(DoorSystem.BatteryZero == false){
            if (CamCooldown == 1){
                isCameraOpen = !isCameraOpen; 
                CamCooldown = 0;

                //CanMoveHead for headmovement left and right
                CanMoveHead = false;

                //Close Camera Screens
                for (int i = 0; i < cameraSystem.Length; i++){cameraSystem[i].SetActive(false);}
            }
        }
        else{
            //Key sound
            AudioOutput.PlaySound(4);
        }
    }
    //CameraScreenSystem
    public void OpenCamera(int cameraID){
        for (int i = 0; i < camerasShownWithID.Length; i++){camerasShownWithID[i].SetActive(i == cameraID);}
        for (int i2 = 0; i2 < CameraObjects.Length; i2++){CameraObjects[i2].SetActive(i2 == cameraID);}
        for (int i3 = 0; i3 < OpenedCamera.Length; i3++){OpenedCamera[i3] = (i3 == cameraID);}
        UpdateColorStandalone();
    }
    public void UpdateColorStandalone(){
        for (int i = 0; i < Camerarenderers.Length; i++){
            if (OpenedCamera[i] == true){Camerarenderers[i].color = ColorON;}
            else if(OpenedCamera[i] != true && Camerarenderers[i].color == ColorON && PurpleDeactivated[i] == false){Camerarenderers[i].color = ColorOFF;}
            else if(OpenedCamera[i] != true && Camerarenderers[i].color != ColorPurple && PurpleDeactivated[i] == true){Camerarenderers[i].color = ColorPurple;}
        }   
    }
    public void UpdateColor(int ImageID)
    {
        for (int i = 0; i < Camerarenderers.Length; i++){
            if (i == ImageID && PurpleDeactivated[ImageID] == true){Camerarenderers[i].color = ColorPurple;}
        }
    }
}