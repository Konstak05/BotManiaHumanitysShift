using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public GameObject[] Objects;
    void Start()
    {
        for (int i = 0; i < Objects.Length; i++){Objects[i].SetActive(true);}
    }
}
