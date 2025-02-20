using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainSystemScript : MonoBehaviour
{
    //Required to be permanent
    private static MainSystemScript instance;

    //Required for saving system
    public SavingSystem SavingSystem;
    //Nights
    public int[] DifficultyEnemyBase,DifficultyEnemy2Base,DifficultyEnemy3Base,DifficultyEnemy4Base,DifficultyEnemy5Base,DifficultyEnemy6Base,DifficultyEnemy7Base;
    public bool[] DifficultyEnemyBacktrackBase;
    public int[] Night1a,Night2a,Night3a,Night4a,Night5a,Night6a,Night8a;
    public int[] Night1b,Night2b,Night3b,Night4b,Night5b,Night6b,Night8b;
    public int[] Night1c,Night2c,Night3c,Night4c,Night5c,Night6c,Night8c;
    public int[] Night1d,Night2d,Night3d,Night4d,Night5d,Night6d,Night8d;
    public int[] Night1e,Night2e,Night3e,Night4e,Night5e,Night6e,Night8e;
    public int[] Night1f,Night2f,Night3f,Night4f,Night5f,Night6f,Night8f;
    public int[] Night1g,Night2g,Night3g,Night4g,Night5g,Night6g,Night8g;
    [Range(-1, 20)] public int Night7a,Night7b,Night7c,Night7d,Night7e,Night7f,Night7g;
    public bool NightBacktrack7,CanSkipLoadingScreen;
    public bool[] NightBacktrack1,NightBacktrack2,NightBacktrack3,NightBacktrack4,NightBacktrack5,NightBacktrack6,NightBacktrack8;
    public int CurrentNight;
    public GameObject[] NightButtons;
    public GameObject SecretNight,CustomNight;

    //Required scripts 
    public UITransScript UITransScript;

    //Text UI
    public TextMeshProUGUI LoadingText;

    //CustomNightText
    public TextMeshProUGUI[] BotDifficultyText;
    public GameObject BackTrackIndication;

    //Required to be permanent too
    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNight();
    }

    void Update()
    {
        if(UITransScript == null){
            GameObject targetObject = GameObject.Find("UI transition Base");
            UITransScript = targetObject.GetComponent<UITransScript>();
        }
    
        if (Input.GetKeyDown(KeyCode.F11))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "LoadingScreen")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "NightGame" && CanSkipLoadingScreen == true)
        {
            CancelInvoke("ChangeSceneToNight");
            CanSkipLoadingScreen = false;
            SceneManager.LoadScene("NightGame");
        }
    }
    //To transition from MainMenu to Night
    public void Night(int Day)
    {
        CurrentNight = Day;
        if(Day == 1){
            DifficultyEnemyBase = Night1a; 
            DifficultyEnemy2Base = Night1b; 
            DifficultyEnemy3Base = Night1c; 
            DifficultyEnemy4Base = Night1d; 
            DifficultyEnemy5Base = Night1e; 
            DifficultyEnemy6Base = Night1f; 
            DifficultyEnemy7Base = Night1g;
            DifficultyEnemyBacktrackBase = NightBacktrack1;
        }
        if(Day == 2){
            DifficultyEnemyBase = Night2a; 
            DifficultyEnemy2Base = Night2b; 
            DifficultyEnemy3Base = Night2c;
            DifficultyEnemy4Base = Night2d; 
            DifficultyEnemy5Base = Night2e; 
            DifficultyEnemy6Base = Night2f; 
            DifficultyEnemy7Base = Night2g; 
            DifficultyEnemyBacktrackBase = NightBacktrack2;
        }
        if(Day == 3){
            DifficultyEnemyBase = Night3a; 
            DifficultyEnemy2Base = Night3b; 
            DifficultyEnemy3Base = Night3c;
            DifficultyEnemy4Base = Night3d; 
            DifficultyEnemy5Base = Night3e; 
            DifficultyEnemy6Base = Night3f; 
            DifficultyEnemy7Base = Night3g;
            DifficultyEnemyBacktrackBase = NightBacktrack3;
        }
        if(Day == 4){
            DifficultyEnemyBase = Night4a; 
            DifficultyEnemy2Base = Night4b; 
            DifficultyEnemy3Base = Night4c;
            DifficultyEnemy4Base = Night4d; 
            DifficultyEnemy5Base = Night4e; 
            DifficultyEnemy6Base = Night4f; 
            DifficultyEnemy7Base = Night4g;
            DifficultyEnemyBacktrackBase = NightBacktrack4;
        }
        if(Day == 5){
            DifficultyEnemyBase = Night5a; 
            DifficultyEnemy2Base = Night5b; 
            DifficultyEnemy3Base = Night5c;
            DifficultyEnemy4Base = Night5d; 
            DifficultyEnemy5Base = Night5e; 
            DifficultyEnemy6Base = Night5f; 
            DifficultyEnemy7Base = Night5g;
            DifficultyEnemyBacktrackBase = NightBacktrack5;
        }
        if(Day == 6){
            DifficultyEnemyBase = Night6a; 
            DifficultyEnemy2Base = Night6b; 
            DifficultyEnemy3Base = Night6c;
            DifficultyEnemy4Base = Night6d; 
            DifficultyEnemy5Base = Night6e; 
            DifficultyEnemy6Base = Night6f; 
            DifficultyEnemy7Base = Night6g;
            DifficultyEnemyBacktrackBase = NightBacktrack6;
        }
        if(Day == 7){
            for (int i = 0; i < DifficultyEnemyBase.Length; i++){DifficultyEnemyBase[i] = Night7a;}
            for (int i2 = 0; i2 < DifficultyEnemy2Base.Length; i2++){DifficultyEnemy2Base[i2] = Night7b;}
            for (int i3 = 0; i3 < DifficultyEnemy3Base.Length; i3++){DifficultyEnemy3Base[i3] = Night7c;}
            for (int i4 = 0; i4 < DifficultyEnemy4Base.Length; i4++){DifficultyEnemy4Base[i4] = Night7d;}
            for (int i5 = 0; i5 < DifficultyEnemy5Base.Length; i5++){DifficultyEnemy5Base[i5] = Night7e;}
            for (int i6 = 0; i6 < DifficultyEnemy6Base.Length; i6++){DifficultyEnemy6Base[i6] = Night7f;}
            for (int i7 = 0; i7 < DifficultyEnemy7Base.Length; i7++){DifficultyEnemy7Base[i7] = Night7g;}
            for (int i9 = 0; i9 < DifficultyEnemyBacktrackBase.Length; i9++){DifficultyEnemyBacktrackBase[i9] = NightBacktrack7;}
        }
        if(Day == 8){
            DifficultyEnemyBase = Night8a; 
            DifficultyEnemy2Base = Night8b; 
            DifficultyEnemy3Base = Night8c;
            DifficultyEnemy4Base = Night8d; 
            DifficultyEnemy5Base = Night8e; 
            DifficultyEnemy6Base = Night8f; 
            DifficultyEnemy7Base = Night8g; 
            DifficultyEnemyBacktrackBase = NightBacktrack8;
        }
        //UITransScript.FadeIn();
        ChangeSceneToLoadingScreen1();
    }

    void ChangeSceneToLoadingScreen1(){
        SceneManager.LoadScene("LoadingScreen");
        Invoke("ChangeSceneToLoadingScreen2",0.2f);
    }
    void ChangeSceneToLoadingScreen2(){
        CanSkipLoadingScreen = true;

        GameObject targetObject = GameObject.Find("UI Loading Text");
        LoadingText = targetObject.GetComponent<TextMeshProUGUI>();

        if(LoadingText != null){LoadingText.text = CurrentNight.ToString();}
        Invoke("ChangeSceneToNight",12.5f);
    }
    void ChangeSceneToNight(){
        CanSkipLoadingScreen = false;
        SceneManager.LoadScene("NightGame");
    }

    //Custom Night Functions
    public void IncreaseEnemyDifficulty(int EnemyID){
        if(EnemyID == 0 && Night7a < 20){
            Night7a++;
            BotDifficultyText[EnemyID].text = Night7a.ToString();
        }
        else if(EnemyID == 1 && Night7b < 20){
            Night7b++;
            BotDifficultyText[EnemyID].text = Night7b.ToString();
        }
        else if(EnemyID == 2 && Night7c < 20){
            Night7c++;
            BotDifficultyText[EnemyID].text = Night7c.ToString();
        }
        else if(EnemyID == 3 && Night7d < 20){
            Night7d++;
            BotDifficultyText[EnemyID].text = Night7d.ToString();
        }
        else if(EnemyID == 4 && Night7e < 20){
            Night7e++;
            BotDifficultyText[EnemyID].text = Night7e.ToString();
        }
        else if(EnemyID == 5 && Night7f < 20){
            Night7f++;
            BotDifficultyText[EnemyID].text = Night7f.ToString();
        }
        else if(EnemyID == 6 && Night7g < 20){
            Night7g++;
            BotDifficultyText[EnemyID].text = Night7g.ToString();
        }
    }
    public void DecreaseEnemyDifficulty(int EnemyID){
        if(EnemyID == 0 && Night7a > -1){
            Night7a--;
            BotDifficultyText[EnemyID].text = Night7a.ToString();
        }
        else if(EnemyID == 1 && Night7b > -1){
            Night7b--;
            BotDifficultyText[EnemyID].text = Night7b.ToString();
        }
        else if(EnemyID == 2 && Night7c > -1){
            Night7c--;
            BotDifficultyText[EnemyID].text = Night7c.ToString();
        }
        else if(EnemyID == 3 && Night7d > -1){
            Night7d--;
            BotDifficultyText[EnemyID].text = Night7d.ToString();
        }
        else if(EnemyID == 4 && Night7e > -1){
            Night7e--;
            BotDifficultyText[EnemyID].text = Night7e.ToString();
        }
        else if(EnemyID == 5 && Night7f > -1){
            Night7f--;
            BotDifficultyText[EnemyID].text = Night7f.ToString();
        }
        else if(EnemyID == 6 && Night7g > -1){
            Night7g--;
            BotDifficultyText[EnemyID].text = Night7g.ToString();
        }
    }
    public void BacktrackToggle(){
        NightBacktrack7 = !NightBacktrack7;
        BackTrackIndication.SetActive(!NightBacktrack7);
    }

    //For Saving System
    public void SaveNight(){
        SavingSystem.CurrentNightSaved = CurrentNight;
        SavingSystem.SaveNight();
    }
    public void LoadNight(){
        SavingSystem.LoadNight();
        if(CurrentNight > 0 && CurrentNight <= 6){for (int i = 0; i < NightButtons.Length; i++){NightButtons[i].SetActive(i == CurrentNight - 1);} CustomNight.SetActive(false);}
        if(CurrentNight == 7){for (int i = 0; i < NightButtons.Length; i++){NightButtons[i].SetActive(false);} NightButtons[5].SetActive(true); CustomNight.SetActive(true);}
        if(CurrentNight > 7){for (int i = 0; i < NightButtons.Length; i++){NightButtons[i].SetActive(false);} SecretNight.SetActive(true); CustomNight.SetActive(false);}
        if(CurrentNight <= 0){for (int i = 0; i < NightButtons.Length; i++){NightButtons[i].SetActive(false);} SecretNight.SetActive(true); CustomNight.SetActive(false);}
    }
    //For Exiting
    public void Exit(){
        Application.Quit();
    }
}
