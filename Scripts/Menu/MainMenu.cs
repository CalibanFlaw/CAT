using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //[EventRef]
    //public string SoundS;
    public FMOD.Studio.EventInstance StartMusic;


    private AsyncOperation OP;


    private void Start()
    {
        
        StartMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Start Screen/Start Music");
       // StartMusic = RuntimeManager.CreateInstance(SoundS);
        StartMusic.start();

        OP = SceneManager.LoadSceneAsync("Game");
        OP.allowSceneActivation = false;

    }

    public void StartGame()
    {
       

        StartMusic.setParameterByName("Start screen to play", 2);

        OP.allowSceneActivation = true;

        StartMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        StartMusic.release();

    }
}
