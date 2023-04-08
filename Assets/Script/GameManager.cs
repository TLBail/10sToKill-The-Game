using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager(){}

    private static GameManager instance;
    
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

    
    private void Start() {
        StartCoroutine(DoSlowMotion());
    }

    [SerializeField] private float _slodownFactor = 0.05f;
    IEnumerator DoSlowMotion() {
        slowdowFactor = 0.05f;
        
        isRecording = true;
        yield return new WaitForSeconds(5f);
        isRecording = false;
    }
    
    public float slowdowFactor
    {
        get
        {
            return _slodownFactor;
        }
        set
        {
            _slodownFactor = value;
            Time.timeScale = _slodownFactor;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }


    public Action onPlayingRecordChange;
    private int _isPlayingRecord = 0;
    public int isPlayingRecord
    {
        get
        {
            return _isPlayingRecord;
        }
        set
        {
            _isPlayingRecord = value;
            onPlayingRecordChange?.Invoke();   
        }
    }
    
    public Action onRecordTime;
    private bool _isRecording = false;
    public float timeRecorded = 0f;

    private void FixedUpdate() {
        if (!isRecording) {
            timeIndex += isPlayingRecord;
            if (timeIndex < 0) {
                timeIndex = 0;
            }
        }
    }


    public bool isRecording
    {
        get
        {
            return _isRecording;
        }
        set
        {
            _isRecording = value;
            onRecordTime?.Invoke();
            if (_isRecording == false) {
                timeIndex = 0;
            }
        }
    }
    
    public int timeIndex = 0;

}
