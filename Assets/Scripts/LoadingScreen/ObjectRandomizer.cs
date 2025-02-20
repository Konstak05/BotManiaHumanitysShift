using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomizer : MonoBehaviour
{
    public GameObject[] Objects;

    void Start()
    {
        int RandomObjectSelector = UnityEngine.Random.Range(0, Objects.Length);
        for (int i = 0; i < Objects.Length; i++){Objects[i].SetActive(i == RandomObjectSelector);}
    }
}
