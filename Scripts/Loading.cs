using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMOD.Studio;

public class Loading : MonoBehaviour
{
    public int sceneID;
    public Image LoadingSCN;
    public Text progressTXT;
    

    private void Start()
    {
        
       FMODUnity.RuntimeManager.LoadBank("Master", true);
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            LoadingSCN.fillAmount = progress;
            progressTXT.text = string.Format("{0:0}%", progress * 100); 
            
            yield return null;
        }
    }
}

