using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class DeadMenu : MonoBehaviour
{
    [EventRef]
    public string SoundD;
    EventInstance DeadMusic;

    SCORE scr;

    

    private void Start()
    {
        // DeadMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Death screen/End Music");
        DeadMusic = RuntimeManager.CreateInstance(SoundD);
        DeadMusic.start();
        
        scr = FindObjectOfType<SCORE>();

        
    }

    public void StartGame()
    {

        SceneManager.LoadSceneAsync("Game");
        DeadMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        DeadMusic.release();
    }
    public void StartMenu()
    {
        SceneManager.LoadSceneAsync("StartMenu");
        DeadMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        DeadMusic.release();
    }
}
