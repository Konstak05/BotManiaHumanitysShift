using UnityEngine;
using UnityEngine.SceneManagement;

public class UITransScript : MonoBehaviour
{
    //Required to be permanent
    private static UITransScript instance;
    //FadeObjects
    public GameObject FadeObject2;

    //Required to be permanent too
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //public void FadeIn(){FadeObject.SetActive(true); Invoke("FadeOut",2f);}

    //public void FadeOut(){FadeObject.SetActive(false);}

    public void EnemyFadeIn(){FadeObject2.SetActive(true); Invoke("EnemyFadeOut",0.5f);}

    public void EnemyFadeOut(){FadeObject2.SetActive(false);}
}
