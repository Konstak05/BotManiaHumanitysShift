using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainNightScript : MonoBehaviour
{
    //Scripts from other Systems
    public EnemyAI[] Enemies;
    public EnemyAICyan EnemyAICyan;
    public EnemyAIHolo EnemyAIHolo;
    public EnemyAIPurple EnemyAIPurple;
    public AudioOutput AudioOutput;
    public SecurityCamSystem SecurityCamSystem;
    public DoorSystem DoorSystem;
    //Text UI
    public TextMeshProUGUI NightTimeText,NightCountText,BatteryLeftText;
    //Values and Strings required
    public string NightDay;
    public int NightHourTime,NightHourValue,BatteryLife,BatteryLifeMAX;
    //NightHourDurations
    public int Hour1,Hour2,Hour3,Hour4,Hour5,Hour6;
    //Win and Lose required stuff
    public GameObject SixAmUI,YouDiedUI;
    public bool HasWon;
    //Different Day Difficulties
    public MainSystemScript MainSystemScript;
    //Power Generator
    //public Transform[] PowerWheel,PowerWheel2;
    public Renderer BatteryButton;
    public bool IsPowerGenOn,CanUsePowerGen = true;
    public Color BatteryDownColor,BatteryUpColor,BatteryWorkingColor;
    //Jumpscare System
    public Animator JumpscareAnimator;

    void Start()
    {
        GameObject targetObject = GameObject.Find("MainSystem");
        MainSystemScript = targetObject.GetComponent<MainSystemScript>();

        BatteryLife = BatteryLifeMAX;
        CanUsePowerGen = true;
        NightTimeText.text = "12 AM";
        NightCountText.text = "Night " + MainSystemScript.CurrentNight;
        BatteryLeftText.text = BatteryLife + "% BATTERY";
        Invoke("StartNight", 1f);
    }

    void Update(){
        if(IsPowerGenOn == true && DoorSystem.DoorIDisclosed[0] == false && DoorSystem.DoorIDisclosed[1] == false && DoorSystem.DoorIDisclosed[2] == false && DoorSystem.DoorIDisclosed[3] == false && SecurityCamSystem.isCameraOpen == false && BatteryLife < BatteryLifeMAX && BatteryLife > 0 && CanUsePowerGen == true){
        BatteryButton.material.color = BatteryWorkingColor;
        //    for (int i = 0; i < PowerWheel.Length; i++){PowerWheel[i].Rotate(0, 40 * Time.deltaTime, 0);}
        //    for (int i2 = 0; i2 < PowerWheel2.Length; i2++){PowerWheel2[i2].Rotate(0, -40 * Time.deltaTime, 0);}
        }
        if(IsPowerGenOn == false && BatteryLife > 0 && CanUsePowerGen == true){
            if(BatteryButton.material.color != BatteryUpColor){BatteryButton.material.color = BatteryUpColor;}
        }
    }

    private void StartNight()
    {
        //Interval
        if(NightHourValue <= Hour6){
            NightHourValue++;
            Invoke("StartNight", 1f);
        }
        //Night Hour System
        if(NightHourValue <= Hour1 && NightHourTime != 12){
            Enemies[0].ChangeDifficulty(MainSystemScript.DifficultyEnemyBase[0]);
            Enemies[1].ChangeDifficulty(MainSystemScript.DifficultyEnemy2Base[0]);
            Enemies[2].ChangeDifficulty(MainSystemScript.DifficultyEnemy3Base[0]);
            Enemies[3].ChangeDifficulty(MainSystemScript.DifficultyEnemy7Base[0]);
            EnemyAICyan.ChangeDifficulty(MainSystemScript.DifficultyEnemy4Base[0]);
            EnemyAIHolo.ChangeDifficulty(MainSystemScript.DifficultyEnemy5Base[0]);
            EnemyAIPurple.ChangeDifficulty(MainSystemScript.DifficultyEnemy6Base[0]);
            for (int i = 0; i < Enemies.Length; i++){Enemies[i].CanBackTrack = MainSystemScript.DifficultyEnemyBacktrackBase[0];}
            
            for (int i2 = 0; i2 < Enemies.Length; i2++){Enemies[i2].StartChangeEnemyAI();}
            EnemyAICyan.StartChangeEnemyAI();
            EnemyAIHolo.StartChangeEnemyAI();
            EnemyAIPurple.StartChangeEnemyAI();
            NightHourTime = 12;
            NightTimeText.text =  NightHourTime + " AM";
        }
        if(NightHourValue > Hour1 && NightHourValue <= Hour2 && NightHourTime != 1){
            Enemies[0].ChangeDifficulty(MainSystemScript.DifficultyEnemyBase[1]);
            Enemies[1].ChangeDifficulty(MainSystemScript.DifficultyEnemy2Base[1]);
            Enemies[2].ChangeDifficulty(MainSystemScript.DifficultyEnemy3Base[1]);
            Enemies[3].ChangeDifficulty(MainSystemScript.DifficultyEnemy7Base[1]);
            EnemyAICyan.ChangeDifficulty(MainSystemScript.DifficultyEnemy4Base[1]);
            EnemyAIHolo.ChangeDifficulty(MainSystemScript.DifficultyEnemy5Base[1]);
            EnemyAIPurple.ChangeDifficulty(MainSystemScript.DifficultyEnemy6Base[1]);
            for (int i = 0; i < Enemies.Length; i++){Enemies[i].CanBackTrack = MainSystemScript.DifficultyEnemyBacktrackBase[1];}

            for (int i2 = 0; i2 < Enemies.Length; i2++){Enemies[i2].StartChangeEnemyAI();}
            EnemyAICyan.StartChangeEnemyAI();
            EnemyAIHolo.StartChangeEnemyAI();
            EnemyAIPurple.StartChangeEnemyAI();
            NightHourTime = 1;
            NightTimeText.text =  NightHourTime + " AM";
        }
        if(NightHourValue > Hour2 && NightHourValue <= Hour3 && NightHourTime != 2){
            Enemies[0].ChangeDifficulty(MainSystemScript.DifficultyEnemyBase[2]);
            Enemies[1].ChangeDifficulty(MainSystemScript.DifficultyEnemy2Base[2]);
            Enemies[2].ChangeDifficulty(MainSystemScript.DifficultyEnemy3Base[2]);
            Enemies[3].ChangeDifficulty(MainSystemScript.DifficultyEnemy7Base[2]);
            EnemyAICyan.ChangeDifficulty(MainSystemScript.DifficultyEnemy4Base[2]);
            EnemyAIHolo.ChangeDifficulty(MainSystemScript.DifficultyEnemy5Base[2]);
            EnemyAIPurple.ChangeDifficulty(MainSystemScript.DifficultyEnemy6Base[2]);
            for (int i = 0; i < Enemies.Length; i++){Enemies[i].CanBackTrack = MainSystemScript.DifficultyEnemyBacktrackBase[2];}

            for (int i2 = 0; i2 < Enemies.Length; i2++){Enemies[i2].StartChangeEnemyAI();}
            EnemyAICyan.StartChangeEnemyAI();
            EnemyAIHolo.StartChangeEnemyAI();
            EnemyAIPurple.StartChangeEnemyAI();
            NightHourTime = 2;
            NightTimeText.text =  NightHourTime + " AM";
        }
        if(NightHourValue > Hour3 && NightHourValue <= Hour4 && NightHourTime != 3){
            Enemies[0].ChangeDifficulty(MainSystemScript.DifficultyEnemyBase[3]);
            Enemies[1].ChangeDifficulty(MainSystemScript.DifficultyEnemy2Base[3]);
            Enemies[2].ChangeDifficulty(MainSystemScript.DifficultyEnemy3Base[3]);
            Enemies[3].ChangeDifficulty(MainSystemScript.DifficultyEnemy7Base[3]);
            EnemyAICyan.ChangeDifficulty(MainSystemScript.DifficultyEnemy4Base[3]);
            EnemyAIHolo.ChangeDifficulty(MainSystemScript.DifficultyEnemy5Base[3]);
            EnemyAIPurple.ChangeDifficulty(MainSystemScript.DifficultyEnemy6Base[3]);
            for (int i = 0; i < Enemies.Length; i++){Enemies[i].CanBackTrack = MainSystemScript.DifficultyEnemyBacktrackBase[3];}

            for (int i2 = 0; i2 < Enemies.Length; i2++){Enemies[i2].StartChangeEnemyAI();}
            EnemyAICyan.StartChangeEnemyAI();
            EnemyAIHolo.StartChangeEnemyAI();
            EnemyAIPurple.StartChangeEnemyAI();
            NightHourTime = 3;
            NightTimeText.text =  NightHourTime + " AM";
        }
        if(NightHourValue > Hour4 && NightHourValue <= Hour5 && NightHourTime != 4){
            Enemies[0].ChangeDifficulty(MainSystemScript.DifficultyEnemyBase[4]);
            Enemies[1].ChangeDifficulty(MainSystemScript.DifficultyEnemy2Base[4]);
            Enemies[2].ChangeDifficulty(MainSystemScript.DifficultyEnemy3Base[4]);
            Enemies[3].ChangeDifficulty(MainSystemScript.DifficultyEnemy7Base[4]);
            EnemyAICyan.ChangeDifficulty(MainSystemScript.DifficultyEnemy4Base[4]);
            EnemyAIHolo.ChangeDifficulty(MainSystemScript.DifficultyEnemy5Base[4]);
            EnemyAIPurple.ChangeDifficulty(MainSystemScript.DifficultyEnemy6Base[4]);
            for (int i = 0; i < Enemies.Length; i++){Enemies[i].CanBackTrack = MainSystemScript.DifficultyEnemyBacktrackBase[4];}

            for (int i2 = 0; i2 < Enemies.Length; i2++){Enemies[i2].StartChangeEnemyAI();}
            EnemyAICyan.StartChangeEnemyAI();
            EnemyAIHolo.StartChangeEnemyAI();
            EnemyAIPurple.StartChangeEnemyAI();
            NightHourTime = 4;
            NightTimeText.text =  NightHourTime + " AM";
        }
        if(NightHourValue > Hour5 && NightHourValue <= Hour6 && NightHourTime != 5){
            Enemies[0].ChangeDifficulty(MainSystemScript.DifficultyEnemyBase[5]);
            Enemies[1].ChangeDifficulty(MainSystemScript.DifficultyEnemy2Base[5]);
            Enemies[2].ChangeDifficulty(MainSystemScript.DifficultyEnemy3Base[5]);
            Enemies[3].ChangeDifficulty(MainSystemScript.DifficultyEnemy7Base[5]);
            EnemyAICyan.ChangeDifficulty(MainSystemScript.DifficultyEnemy4Base[5]);
            EnemyAIHolo.ChangeDifficulty(MainSystemScript.DifficultyEnemy5Base[5]);
            EnemyAIPurple.ChangeDifficulty(MainSystemScript.DifficultyEnemy6Base[5]);
            for (int i = 0; i < Enemies.Length; i++){Enemies[i].CanBackTrack = MainSystemScript.DifficultyEnemyBacktrackBase[5];}

            for (int i2 = 0; i2 < Enemies.Length; i2++){Enemies[i2].StartChangeEnemyAI();}
            EnemyAICyan.StartChangeEnemyAI();
            EnemyAIHolo.StartChangeEnemyAI();
            EnemyAIPurple.StartChangeEnemyAI();
            NightHourTime = 5;
            NightTimeText.text =  NightHourTime + " AM";
        }
        if(NightHourValue > Hour6 && NightHourTime != 6){
            NightHourTime = 6;
            NightTimeText.text =  NightHourTime + " AM";
            NightOver();
        }
        //Night Battery System
        if(DoorSystem.DoorIDisclosed[0] == true && BatteryLife > 0){BatteryLife -= 1;}
        if(DoorSystem.DoorIDisclosed[1] == true && BatteryLife > 0){BatteryLife -= 1;}
        if(DoorSystem.DoorIDisclosed[2] == true && BatteryLife > 0){BatteryLife -= 1;}
        if(DoorSystem.DoorIDisclosed[3] == true && BatteryLife > 0){BatteryLife -= 1;}

        //Power Generator
        if(IsPowerGenOn == true && DoorSystem.DoorIDisclosed[0] == false && DoorSystem.DoorIDisclosed[1] == false && DoorSystem.DoorIDisclosed[2] == false && DoorSystem.DoorIDisclosed[3] == false && SecurityCamSystem.isCameraOpen == false && BatteryLife < BatteryLifeMAX && CanUsePowerGen == true){
            if(BatteryLife <= BatteryLifeMAX/3 && BatteryLife > 0){BatteryLife += 3;}
            else if(BatteryLife <= BatteryLifeMAX/2 && BatteryLife > BatteryLifeMAX/3){BatteryLife += 2;}
            else if(BatteryLife < BatteryLifeMAX && BatteryLife > BatteryLifeMAX/2){BatteryLife += 1;}
        }
        if(BatteryLife <= 0){
            BatteryButton.material.color = BatteryDownColor;
        }

        BatteryLeftText.text = BatteryLife + "% BATTERY";
    }

    public void PowerGeneratorToggle(bool Toggle){IsPowerGenOn = Toggle;}

    public void NightOver(){
        for (int i = 0; i < Enemies.Length; i++){Enemies[i].EnemyClose();}
        EnemyAICyan.EnemyClose();
        EnemyAIHolo.EnemyClose();
        SixAmUI.SetActive(true);
        AudioOutput.CloseAmbienceStarter();
        AudioOutput.PlaySound(2);
        HasWon = true;
        Invoke("ReturnToMainMenu", 5f);
    }
    public void GameOver(int Enemy){
        for (int i = 0; i < Enemies.Length; i++){Enemies[i].EnemyClose();}
        EnemyAICyan.EnemyClose();
        EnemyAIHolo.EnemyClose();

        SecurityCamSystem.isCameraOpen = false;
        if(SecurityCamSystem.isCameraOpen == true){SecurityCamSystem.IsRotatingToggle();}
        SecurityCamSystem.BottomCamButton.SetActive(false);
        DoorSystem.BatteryZero = true;
        JumpscareAnimator.enabled = true;
        JumpscareAnimator.SetInteger("DiedBy", Enemy);
        //YouDiedUI.SetActive(true);
        AudioOutput.CloseAmbienceStarter();
        Invoke("ReturnToMainMenu", 3f);
    }
    void ReturnToMainMenu(){
        AudioOutput.StopSound();
        AudioOutput.OpenAmbienceStarter();
        if(MainSystemScript.CurrentNight < 7 && HasWon == true){MainSystemScript.CurrentNight++;}
        Destroy(MainSystemScript.gameObject);
        MainSystemScript.SaveNight();
        SceneManager.LoadScene("MainMenu");
    }
}
