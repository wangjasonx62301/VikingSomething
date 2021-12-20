using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Icon : MonoBehaviour
{    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
