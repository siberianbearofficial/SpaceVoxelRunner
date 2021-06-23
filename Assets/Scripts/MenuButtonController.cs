using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    private Button[] buttons;
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            string name = button.gameObject.name;
            if (name == "PlayButton")
            {
                button.onClick.AddListener(OnPlayButtonClick);
            } else if (name == "SettingsButton")
            {
                button.onClick.AddListener(OnSettingsButtonClick);
            }
        }
    }

    void OnPlayButtonClick()
    {
        SceneManager.LoadScene("PlayScene");
    }

    void OnSettingsButtonClick()
    {
        print("Settings!");
    }
}
