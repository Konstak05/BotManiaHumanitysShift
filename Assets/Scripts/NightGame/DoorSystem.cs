using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSystem : MonoBehaviour
{
    //Main System Script for Battery
    public MainNightScript MainNightScript;

    public Animator[] Doors;
    public bool[] DoorIDisclosed,PurpleDeactivated;
    public bool BatteryZero;
    public float[] DoorValue;

    //Power Lights
    public SecurityCamSystem SecurityCamSystem;
    public Color ColorON,ColorOFF,ColorPurple;
    public Renderer[] ButtonLight,LightRenderers;
    public Image PowerGenImage;

    //Requirement for Sound
    public AudioOutput AudioOutput;

    void Start(){
        for (int i = 0; i < Doors.Length; i++){Doors[i].SetFloat("ClosedValue", 0);}
        for (int i2 = 0; i2 < DoorIDisclosed.Length; i2++){DoorIDisclosed[i2] = false;}
        for (int i3 = 0; i3 < LightRenderers.Length; i3++){LightRenderers[i3].material.color = ColorOFF;}
        for (int i4 = 0; i4 < ButtonLight.Length; i4++){ButtonLight[i4].material.color = ColorOFF;}
        PowerGenImage.color = ColorON;
    }

    void Update(){
        if(DoorIDisclosed[0] == false && DoorValue[0] > 0f){DoorValue[0] = DoorValue[0] - 0.05f; Doors[0].SetFloat("ClosedValue", DoorValue[0]);}
        else if(DoorIDisclosed[0] == true && DoorValue[0] < 1f){DoorValue[0] = DoorValue[0] + 0.075f; Doors[0].SetFloat("ClosedValue", DoorValue[0]);}
        if(DoorIDisclosed[1] == false && DoorValue[1] > 0f){DoorValue[1] = DoorValue[1] - 0.05f; Doors[1].SetFloat("ClosedValue", DoorValue[1]);}
        else if(DoorIDisclosed[1] == true && DoorValue[1] < 1f){DoorValue[1] = DoorValue[1] + 0.075f; Doors[1].SetFloat("ClosedValue", DoorValue[1]);}
        if(DoorIDisclosed[2] == false && DoorValue[2] > 0f){DoorValue[2] = DoorValue[2] - 0.05f; Doors[2].SetFloat("ClosedValue", DoorValue[2]);}
        else if(DoorIDisclosed[2] == true && DoorValue[2] < 1f){DoorValue[2] = DoorValue[2] + 0.075f; Doors[2].SetFloat("ClosedValue", DoorValue[2]);}

        //OpenDoors
        if(MainNightScript.BatteryLife <= 0 && BatteryZero == false){
            for (int i1 = 0; i1 < DoorIDisclosed.Length; i1++){DoorIDisclosed[i1] = false;}
            for (int i2 = 0; i2 < LightRenderers.Length; i2++){LightRenderers[i2].material.color = ColorON;}
            for (int i3 = 0; i3 < ButtonLight.Length; i3++){ButtonLight[i3].material.color = ColorON;}
            if(SecurityCamSystem.isCameraOpen == true){SecurityCamSystem.IsRotatingToggle();}
            LightRenderers[3].material.color = ColorON;
            BatteryZero = true;
        }
        if(PurpleDeactivated[0] == true && ButtonLight[0].material.color != ColorPurple){
            ButtonLight[0].material.color = ColorPurple;
            LightRenderers[0].material.color = ColorPurple;
        }
        if(PurpleDeactivated[1] == true && ButtonLight[1].material.color != ColorPurple){
            ButtonLight[1].material.color = ColorPurple;
            LightRenderers[1].material.color = ColorPurple;
        }
        if(PurpleDeactivated[2] == true && ButtonLight[2].material.color != ColorPurple){
            ButtonLight[2].material.color = ColorPurple;
            LightRenderers[2].material.color = ColorPurple;
        }
        if(PurpleDeactivated[0] == false && ButtonLight[0].material.color == ColorPurple){
            UpdateColor(0);
        }
        if(PurpleDeactivated[1] == false && ButtonLight[1].material.color == ColorPurple){
            UpdateColor(1);
        }
        if(PurpleDeactivated[2] == false && ButtonLight[2].material.color == ColorPurple){
            UpdateColor(2);
        }
    }

    public void DoorToggle(int Door)
    {
        if(Door >= 0 && Door < 3){
            if(MainNightScript.BatteryLife > 0 && PurpleDeactivated[Door] == false)
            {
                //Key sound
                AudioOutput.PlaySound(1);

                DoorIDisclosed[Door] = !DoorIDisclosed[Door];
            }
            else{
                //No Battery Sound
                AudioOutput.PlaySound(4);
            }
            if(DoorIDisclosed[Door] == false && MainNightScript.BatteryLife > 0 && PurpleDeactivated[Door] == false){
                ButtonLight[Door].material.color = ColorOFF;
                LightRenderers[Door].material.color = ColorOFF;
            }
            else{
                ButtonLight[Door].material.color = ColorON;
                LightRenderers[Door].material.color = ColorON;
            }
        }
        else if(Door == 3){
            if(MainNightScript.BatteryLife > 0)
            {
                //Key sound
                AudioOutput.PlaySound(1);

                DoorIDisclosed[Door] = !DoorIDisclosed[Door];
            }
            else{
                //No Battery Sound
                AudioOutput.PlaySound(4);
            }
            if(DoorIDisclosed[Door] == false && MainNightScript.BatteryLife > 0){
                PowerGenImage.color = ColorON;
                LightRenderers[Door].material.color = ColorOFF;
            }
            else{
                PowerGenImage.color = ColorOFF;
                LightRenderers[Door].material.color = ColorON;
            }
        }
    }
    public void UpdateColor(int DoorID){
            if(DoorIDisclosed[DoorID] == false && MainNightScript.BatteryLife > 0 && PurpleDeactivated[DoorID] == false){
                ButtonLight[DoorID].material.color = ColorOFF;
                LightRenderers[DoorID].material.color = ColorOFF;
            }
            else{
                ButtonLight[DoorID].material.color = ColorON;
                LightRenderers[DoorID].material.color = ColorON;
            }
    }
}
