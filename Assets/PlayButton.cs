using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Camera Camera;
    public Text Race1Time;
    public Text Race2Time;
    public Text Race3Time;
    public EventSystem EventSystem;
    public GameObject DefaultButton;

    void Start()
    {
        SceneManager.LoadScene("Room", LoadSceneMode.Additive);
    }

    public void PlayRace1()
    {
        SceneManager.LoadScene("Race1", LoadSceneMode.Additive);

    }

    public void PlayRace2()
    {
        SceneManager.LoadScene("Race2", LoadSceneMode.Additive);
    }

    public void PlayRace3()
    {
        SceneManager.LoadScene("Race3", LoadSceneMode.Additive);
    }

    void Update()
    {
        string minutes = Mathf.Floor(Times.Time1 / 60).ToString("00");
        string seconds = Mathf.Floor(Times.Time1 % 60).ToString("00");
        string fraction = Mathf.Floor((Times.Time1 * 100) % 100).ToString("00");
        Race1Time.text = minutes + ":" + seconds + ":" + fraction;
        minutes = Mathf.Floor(Times.Time2 / 60).ToString("00");
        seconds = Mathf.Floor(Times.Time2 % 60).ToString("00");
        fraction = Mathf.Floor((Times.Time2 * 100) % 100).ToString("00");
        Race2Time.text = minutes + ":" + seconds + ":" + fraction;
        minutes = Mathf.Floor(Times.Time3 / 60).ToString("00");
        seconds = Mathf.Floor(Times.Time3 % 60).ToString("00");
        fraction = Mathf.Floor((Times.Time3 * 100) % 100).ToString("00");
        Race3Time.text = minutes + ":" + seconds + ":" + fraction;

        if (SceneManager.GetSceneByName("Race1").isLoaded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Race1"));
        }
        else if (SceneManager.GetSceneByName("Race2").isLoaded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Race2"));
        }
        else if (SceneManager.GetSceneByName("Race3").isLoaded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Race3"));
        }

        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Menu"))
        {
            EventSystem.SetSelectedGameObject(null);
            foreach (var button in GetComponentsInChildren<Button>())
            {
                button.interactable = false;
            }
        }
        else if (EventSystem.currentSelectedGameObject == null)
        {
            EventSystem.SetSelectedGameObject(DefaultButton);
            foreach (var button in GetComponentsInChildren<Button>())
            {
                button.interactable = true;
            }
        }
    }
}
