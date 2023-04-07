using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager(){}

    private static GameManager instance;
    
    public Action onReverseTime;
    public static GameManager Instance
    {
        get
        {
            return instance ?? (instance = new GameObject("SingletonHolder").AddComponent<GameManager>()); // ?? is the null coalescing operator. It's the same as doing this: instance != null ? instance : new GameObject("SingletonHolder").AddComponent<GameManager>();
        }
        private set{ instance = value;}
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private bool _isReversing = false;
    public bool isReversing
    {
        get
        {
            return _isReversing;
        }
        set
        {
            _isReversing = value;
            onReverseTime?.Invoke();   
        }
    }
}
