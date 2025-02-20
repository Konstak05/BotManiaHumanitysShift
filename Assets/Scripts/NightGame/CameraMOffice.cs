using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMOffice : MonoBehaviour
{
    //RequiredForLimitedMovement
    public SecurityCamSystem SecurityCamScript;
    //Script Itself
    public Transform MainCamera;
    public float RotationSpeed = 50f;
    public float CurrentYRotation;
    public int RotateLeftRight = 0; //Controlled by Event triggers left and right

    void Update()
    {
        CurrentYRotation = MainCamera.eulerAngles.y;

        if (CurrentYRotation > 180){CurrentYRotation -= 360;}

        if(RotateLeftRight == 1 && CurrentYRotation < 15 && SecurityCamScript.CanMoveHead == true){MainCamera.Rotate(0, RotationSpeed * Time.deltaTime, 0);}
        if(RotateLeftRight == -1 && CurrentYRotation > -15 && SecurityCamScript.CanMoveHead == true){MainCamera.Rotate(0, -RotationSpeed * Time.deltaTime, 0);}
    }

    public void IsRotatingRight(){RotateLeftRight = 1;}
    public void IsRotatingLeft(){RotateLeftRight = -1;}
    public void NotRotating(){RotateLeftRight = 0;}
}
