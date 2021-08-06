using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class Sound : MonoBehaviour
{
    public static Bus Music;
    public static Bus Effect;
    public static Bus Bonus;
    public static Bus CAT;

    public Toggle music;
    public Toggle effect;

    public static Sound instance;

    public bool PlayEffect;
    bool Paused = false;

    public GameObject PanelPause;

    private void Awake()
    {
        instance = this;

        Music = RuntimeManager.GetBus("bus:/Music");
        Effect = RuntimeManager.GetBus("bus:/Interraction");
        Bonus = RuntimeManager.GetBus("bus:/Fish Take filter");
        CAT = RuntimeManager.GetBus("bus:/Movement");

        if (!PlayerPrefs.HasKey("Mus"))
        {
            PlayerPrefs.SetInt("Mus", 1);
            music.isOn = true;
            Music.setMute(false);
            PlayerPrefs.Save();
        }
        else
        {
            if (PlayerPrefs.GetInt("Mus") == 0)
            {
                music.isOn = false;
            }
        }

        if (!PlayerPrefs.HasKey("Eff"))
        {
            PlayerPrefs.SetInt("Eff", 1);
            PlayEffect = true;
            effect.isOn = true;
            Effect.setMute(false);
            Bonus.setMute(false);
            CAT.setMute(false);
            PlayerPrefs.Save();

        }
        else
        {
            if (PlayerPrefs.GetInt("Eff") == 0)
            {
                effect.isOn = false;
                PlayEffect = false;
            }
        }

    }


    public void EffectVolLevel()
    {
        if (effect.isOn == true)
        {

            PlayerPrefs.SetInt("Eff", 1);
            Effect.setMute(false);
            Bonus.setMute(false);
            CAT.setMute(false);
            PlayEffect = true;

        }
        else
        {

            PlayerPrefs.SetInt("Eff", 0);
            Effect.setMute(true);
            Bonus.setMute(true);
            CAT.setMute(true);
            PlayEffect = false;
        }
        PlayerPrefs.Save();
    }



    public void MusicVolLevel()
    {
        if (music.isOn == true)
        {
            PlayerPrefs.SetInt("Mus", 1);
            Music.setMute(false);
        }

        else
        {
            PlayerPrefs.SetInt("Mus", 0);
            Music.setMute(true);
        }

        PlayerPrefs.Save();

    }


    public void Pause()
    {
        if (Paused)
        {

            PanelPause.SetActive(false);
            Time.timeScale = 1;
            Paused = false;
            Bonus.setPaused(false);
            CAT.setPaused(false);
            Effect.setPaused(false);
        }
        else
        {
            PanelPause.SetActive(true);
            Time.timeScale = 0;
            Paused = true;
            Bonus.setPaused(true);
            CAT.setPaused(true);
            Effect.setPaused(true);

        }
    }
}
