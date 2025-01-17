﻿using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    private static LoadingScene _loadingScene;

    private bool isStart;

    private Slider progressBar;

    private Text progressShow;


    private AsyncOperation ao;

    public static LoadingScene Instance()
    {
        return _loadingScene;
    }

    private void Awake()
    {
        _loadingScene = this;
        progressBar = GetComponentInChildren<Slider>();
        progressShow = progressBar.GetComponentInChildren<Text>();
    }


    private void FixedUpdate()
    {
        if (isStart)
        {
            progressBar.value = ao.progress;
            progressShow.text = (int) (ao.progress * 100) + "%";
            if (ao.isDone)
            {
                progressBar.gameObject.SetActive(false);
                isStart = false;
            }
        }
    }


    public void StartLoading(AsyncOperation asyncOperation)
    {
        isStart = true;
        ao = asyncOperation;
    }
}
