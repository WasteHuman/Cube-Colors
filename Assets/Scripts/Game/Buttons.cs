using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public static Buttons S;

    public GameObject musicOn, musicOff;


    private void Start()
    {
        S = this;

        if (PlayerPrefs.GetString("music") == "No" && gameObject.name == "Music")
        {
            musicOff.SetActive(true);
            musicOn.SetActive(false);
        }
    }

    public void Play()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("Play");
    }

    public void RestartGame()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("Play");
    }

    public void VK()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        }
        Application.OpenURL("https://vk.com/wastemoon_games");
    }

    public void HowToPlay()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("HowToPlay");
    }

    public void CloseHowTo()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("Main");
    }

    public void Home()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("Main");
    }

    public void MusicWork()
    {
        if (PlayerPrefs.GetString("music") == "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
            PlayerPrefs.SetString("music", "Yes");
            musicOff.SetActive(false);
            musicOn.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("music", "No");
            musicOff.SetActive(true);
            musicOn.SetActive(false);
        }
    }

    public void RewardedRestart()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        }
        //GameController.S.UnpausedGame();
        GameController.gameCntrll.rLost.SetActive(false);
    }

    public void NoRewadred()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        }
        GameController.gameCntrll.rLost.SetActive(false);
        GameController.gameCntrll.pLost.SetActive(true);
    }

    public void RateGame()
    {
        if (PlayerPrefs.GetString("music") != "No")
        {
            GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        }
        Application.OpenURL("https://apps.rustore.ru/app/com.BIGYARGames.CubeColors");
    }
}
