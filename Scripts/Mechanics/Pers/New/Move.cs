using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public enum SIDEs { Left, Mid, Right }
public class Move : MonoBehaviour
{
    public SIDEs m_Side = SIDEs.Mid;
    float NewXPos = 0f;
    // движение
    [HideInInspector]
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    // на сколько нужно сдвинутся в бок
    public float XValue;
    private float x, y, z;
    public float SpeedDodge, speed;
    private CharacterController m_char = null;
    private Animator m_Animator;


    public bool CanPlay, Inviz;
    private bool Bonus = false, BonusX10 = false, BonusX5 = false;

    SCORE Scr;

    public float JumpPower;
    public bool InJump;
    public bool InRoll;

    public GameObject DeadPanel, Indicarot;
    public Image Loading;

    [SerializeField] ParticleSystem PCoin = null, PBonus = null, PMagnit = null, PDead = null;

    //  [EventRef]
    // public string SoundG;
    public FMOD.Studio.EventInstance Music;

    Sound sound;


    public void Start()
    {
        m_char = GetComponent<CharacterController>();

        m_Animator = GetComponent<Animator>();

        Scr = FindObjectOfType<SCORE>();
        sound = FindObjectOfType<Sound>();

         Music = FMODUnity.RuntimeManager.CreateInstance("event:/Game process/Game Music");
        //Music = RuntimeManager.CreateInstance(SoundG);
        Music.start();
        


    }

    public void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(x - transform.position.x, y, z);
        x = Mathf.Lerp(x, NewXPos, SpeedDodge);
        m_char.Move(moveVector);
    }

    public void Update()
    {
        if (CanPlay)
            if (SWIPE.swipeLeft)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Game process/Cat movement/MAIN movement");
                if (m_Side == SIDEs.Mid)
                {

                    NewXPos = -XValue;
                    m_Side = SIDEs.Left;
                    m_Animator.Play("Left");
                }
                else if (m_Side == SIDEs.Right)
                {
                    NewXPos = 0;
                    m_Side = SIDEs.Mid;
                    m_Animator.Play("Left");
                }
            }
            else if (SWIPE.swipeRight)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Game process/Cat movement/MAIN movement");
                if (m_Side == SIDEs.Mid)
                {
                    NewXPos = XValue;
                    m_Side = SIDEs.Right;
                    m_Animator.Play("Right");
                }
                else if (m_Side == SIDEs.Left)
                {
                    NewXPos = 0;
                    m_Side = SIDEs.Mid;
                    m_Animator.Play("Right");
                }
            }

        Jump();
        Roll();
        Musics();
    }


    void OnTriggerEnter(Collider other)// экран смерти
    {
        if (Inviz)
            if (other.gameObject.CompareTag("Cloud"))
            {
                Music.setParameterByName("LIFE STATE", 1);
                CanPlay = false;
                Scr.CanPlay = false;
                PDead.Play();
                PMagnit.Stop();
                m_Animator.Play("InvizOn");



                Coin.activemag = false;
                Bonus = BonusX5 = BonusX10 = false;


                Indicarot.SetActive(false);
                Inviz = false;
                StartCoroutine(bonstart());

            }



        if (other.gameObject.CompareTag("Coin"))
        {
            PCoin.Play();
            if (Bonus == false && BonusX5 == false && BonusX10 == false)
            {
                Scr.AddMoney(1);
            }
            else if (Bonus == true)
            {
                Scr.AddMoney(2);
            }
            else if (BonusX5 == true)
            {
                Scr.AddMoney(5);
            }
            else if (BonusX10 == true)
            {
                Scr.AddMoney(10);
            }

            Destroy(other.gameObject);
            //FMODUnity.RuntimeManager.PlayOneShot("event:/Game process/Objects interraction/Coins");

        }

        if (other.gameObject.CompareTag("Bonus"))
        {
            PBonus.Play();
            Bonus = true;
            Destroy(other.gameObject);
            StartCoroutine(BonusCoin());
        }
        if (other.gameObject.CompareTag("BonusX5"))
        {
            PBonus.Play();
            BonusX5 = true;
            Destroy(other.gameObject);
            StartCoroutine(BonusCoin());
        }
        if (other.gameObject.CompareTag("BonusX10"))
        {
            PBonus.Play();
            BonusX10 = true;
            Destroy(other.gameObject);
            StartCoroutine(BonusCoin());
        }
        if (other.gameObject.CompareTag("Magnit"))
        {
            PBonus.Play();
            StartCoroutine(MagnitCoin());
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Milk"))
        {
            PBonus.Play();
            Scr.AddMilk(1);
            Destroy(other.gameObject);
        }

    }

    public void Jump()
    {

        if (m_char.isGrounded)
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Falling"))
            {

                InJump = false;
            }
            if (CanPlay)
                if (SWIPE.swipeUp)
                {

                    m_Animator.Play("Up");
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Game process/Cat movement/meow");
                    y = JumpPower;
                    InJump = true;
                }
        }
        else
        {

            y -= JumpPower * Time.deltaTime;
            if (m_char.velocity.y < -1f) ;

        }

    }
    internal float RollCounter;
    public void Roll()
    {
        // RollCounter -= Time.deltaTime;

        if (RollCounter <= 0f)
        {
            //   RollCounter = 0f;

            InRoll = false;
        }
        if (SWIPE.swipeDown)
        {
            // RollCounter = 0.2f;
            y -= 0.5f;
            InRoll = true;
            InJump = false;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Game process/Cat movement/MAIN movement");


        }
    }
    public void PlayForMilk()
    {
        if (Scr.MilkCounter >= 1)
        {
            Scr.GameForMilk();
            CanPlay = true;
            DeadPanel.SetActive(false);
            Time.timeScale = 1;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Game process/Objects interraction/Milk drink");
            Scr.CanPlay = true;
            Music.setParameterByName("LIFE STATE", 0);
            Sound.Effect.setPaused(false);
            Sound.CAT.setPaused(false);
            PDead.Play();
            m_Animator.Play("InvizOff");
            StartCoroutine(start());


        }
    }
    IEnumerator bonstart()
    {

        if (sound.effect.isOn == true)
        {
            Sound.Bonus.setMute(true);
            yield return new WaitForSeconds(1.7f);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Menu appearing");
            DeadPanel.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            Sound.Effect.setPaused(true);
            Sound.CAT.setPaused(true);

            Time.timeScale = 0;
            yield return new WaitForSeconds(8);
            Sound.Bonus.setMute(false);

        }
        else
        {

            yield return new WaitForSeconds(1.7f);
            DeadPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }
    IEnumerator start()
    {

        yield return new WaitForSeconds(2);
        Inviz = true;

    }
    public void GameOver()
    {
        if (sound.effect.isOn == true)
        {
            Music.setParameterByName("LIFE STATE", 2);
            Time.timeScale = 1;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Death screen/Tap to lose");
            
            Sound.Effect.setPaused(false);
            Sound.CAT.setPaused(false);
            Sound.Bonus.setMute(false);
            Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Music.release();
            SceneManager.LoadSceneAsync("Dead");
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync("Dead");
            Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Music.release();
        }


    }
    public void StartMenu()
    {
        if (sound.effect.isOn == true)
        {
            Music.setParameterByName("LIFE STATE", 2);
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync("StartMenu");
            Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Music.release();
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync("StartMenu");
            Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Music.release();
        }


    }

    IEnumerator Load()
    {
        Loading.fillAmount = 1;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0.9f;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0.8f;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0.7f;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0.6f;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0.5f;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0.4f;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0.3f;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0.2f;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0.1f;
        yield return new WaitForSeconds(1);
        Loading.fillAmount = 0;
        yield return null;
    }
    IEnumerator MagnitCoin()
    {
        PMagnit.Play();
        Coin.activemag = true;
        yield return new WaitForSeconds(8f);
        PMagnit.Stop();
        yield return new WaitForSeconds(2f);
        Coin.activemag = false;

    }

    IEnumerator BonusCoin()
    {
        StartCoroutine(Load());
        Indicarot.SetActive(true);
        yield return new WaitForSeconds(10);
        Indicarot.SetActive(false);
        Bonus = false;
        BonusX5 = false;
        BonusX10 = false;

    }
    public void Musics()
    {
        if (Scr.scoreCounter == 15000)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Game process/15000");
            Music.setParameterByName("Difficulty", 2);
        }
    }
}
