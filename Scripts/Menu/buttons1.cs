using UnityEngine;
using FMODUnity;

public class buttons1 : MonoBehaviour
{
    public GameObject PanelMenu, PanelExit, PanelPause, PanelShop;

    bool Paused = false;
    bool MenuOn = false, ShopOn = false, ExitOn = false;





    public void Shop()
    {
        if (ShopOn)
        {
            PanelShop.SetActive(false);
            ShopOn = false;
            RuntimeManager.PlayOneShot("event:/Taps");
        }
        else
        {
            PanelShop.SetActive(true);
            ShopOn = true;
            PanelMenu.SetActive(false);
            MenuOn = false;
            PanelExit.SetActive(false);
            ExitOn = false;
            RuntimeManager.PlayOneShot("event:/Taps");
        }
    }





    //Выход из игры
    public void ExitGame()
    {
        if (ExitOn)
        {
            PanelExit.SetActive(false);
            ExitOn = false;
            RuntimeManager.PlayOneShot("event:/Taps");
        }
        else
        {
            PanelExit.SetActive(true);
            ExitOn = true;
            PanelMenu.SetActive(false);
            MenuOn = false;
            PanelShop.SetActive(false);
            ShopOn = false;
            RuntimeManager.PlayOneShot("event:/Taps");
        }
    }
    public void ExitGameYEs()
    {
        Application.Quit();
    }


    // меню
    public void MainMenu()
    {
        if (MenuOn)
        {
            PanelMenu.SetActive(false);
            MenuOn = false;
            RuntimeManager.PlayOneShot("event:/Taps");
        }
        else
        {
            PanelMenu.SetActive(true);
            MenuOn = true;
            PanelShop.SetActive(false);
            ShopOn = false;
            PanelExit.SetActive(false);
            ExitOn = false;
            RuntimeManager.PlayOneShot("event:/Taps");
        }
    }

    //Пауза
    public void Pause()
    {
        if (Paused)
        {

            PanelPause.SetActive(false);
            Time.timeScale = 1;
            Paused = false;
        }
        else
        {

            PanelPause.SetActive(true);
            Time.timeScale = 0;
            Paused = true;

        }
    }
}
