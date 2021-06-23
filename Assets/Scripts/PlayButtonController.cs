using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonController : MonoBehaviour
{
    private Button[] buttons;
    public GameObject PauseCanvas, MainCanvas;
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            string name = button.gameObject.name;
            if (name == "PauseButton")
            {
                button.onClick.AddListener(OnPauseButtonClick);
            } else if (name == "PlayButton")
            {
                button.onClick.AddListener(OnPlayButtonClick);
            }
        }
    }

    void OnPauseButtonClick()
    {
        Game.paused = true;
        PauseCanvas.SetActive(true);
        MainCanvas.SetActive(false);
    }

    void OnPlayButtonClick()
    {
        Game.paused = false;
        MainCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
    }
}
