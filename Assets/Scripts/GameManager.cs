using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;

    public GameObject menu;

    public GameObject gameOver;

    public GameObject worldUI;

    public GameObject winScreen;

    private int currentCoins;

    public Text coinsText;

    public Text catsText;

    public bool fireAbility;

    public int currentCats;

    public int totalCats;

    public AudioSource aS;

    public AudioClip shootClip;

    public Controls c;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        c = new Controls();
        c.Enable();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Reset"))
        {
            StartGame();
            PlayerPrefs.DeleteAll();
        }
    }

    private void Update()
    {
        catsText.text = currentCats.ToString() + "/" + totalCats.ToString();
    }

    public void StartGame()
    {
        menu.SetActive(false);

        worldUI.SetActive(true);
    }

    public void AddCoin()
    {
        currentCoins++;

        coinsText.text = currentCoins.ToString();
    }

    public void UnlockAbility(CatType type)
    {
        currentCats++;

        if(currentCats == 1)
        {
            GameManager.instance.ChangeAudio();
        }

        if(currentCats >= totalCats)
        {
            Win();
        }

        switch (type)
        {
            case CatType.Fire: fireAbility = true;
                break;
        }
    }

    public void ChangeAudio()
    {
        if(aS.clip != shootClip)
        {
            aS.Stop();
            aS.clip = shootClip;
            aS.Play();
        }
    }

    public void GameOver()
    {
        worldUI.SetActive(false);
        gameOver.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego, esto solo funciona en la build");
        Application.Quit();
    }

    public void RestartGame()
    {
        PlayerPrefs.SetFloat("Reset",1f);
        SceneManager.LoadScene(0);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        player.gameObject.SetActive(false);
        c.Disable();
        worldUI.SetActive(false);
        winScreen.SetActive(true);
    }
}