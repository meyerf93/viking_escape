using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCore : MonoBehaviour {

    public static GameCore Instance;
    [SerializeField] Level[] levels;
    [SerializeField] WaterTimer timer;
    [SerializeField] PlayerController[] players;
    [SerializeField] Area[] areas;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject victory;
    [SerializeField] Image blackPanel;
    [SerializeField] Health health;
    [SerializeField] GameMusic gameMusic;

    public Color[] colorControler;

    public int playerCount = 2;
    bool changing;
    Level currentLevel;
    int levelIdx;

    // Use this for initialization
    void Start () {
        changing = false;
        playerCount = 0;
        int index = 0;

 
        string[] tempArray = Input.GetJoystickNames();


        for (int i = 0; i< tempArray.Length; i++)
        {
            if (tempArray[i].Length > 0)
            {
                areas[index].controllerID = i+1;
                playerCount++;
                index++;
            }
        }
        

        Instance = this;
        InitColor();
        FirstLevel();
        StartCoroutine(StartAnim());
        StartCoroutine(CheckUnderWater());
    }

    public void InitColor()
    {
        for( int i = 0; i< 4; i++)
        {
            if(i<playerCount)
            {
                areas[i].UpdateRendererArea(colorControler[i]);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator CheckUnderWater()
    {
        while (true)
        {
            if (!changing)
            {
                foreach (PlayerController p in players)
                {
                    if (p.transform.position.y - timer.transform.position.y+ 2 <= timer.GetTime())
                    {
                        gameMusic.ActivateLowPassFilter(true);
                        health.ChangeHealth(-1);
                    } else
                        gameMusic.ActivateLowPassFilter(false);

                    yield return new WaitForSeconds(1f);
                }
            }
        }
    }

    public void UpdateUI()
    {
        players[0].GetComponent<Inventory>().IdSwaped();
        players[1].GetComponent<Inventory>().IdSwaped();
        players[2].GetComponent<Inventory>().IdSwaped();
        players[3].GetComponent<Inventory>().IdSwaped();
    }

    public void ModifieHealth(int toAdd)
    {
        health.ChangeHealth(toAdd);
    }

    void FirstLevel()
    {
        levelIdx = 0;
        timer.Stop();
        currentLevel = Instantiate(levels[levelIdx]);
        currentLevel.Initialize(players);
        print("Show Anim");
        timer.Restart();
    }

    public void NextLevel()
    {
        if (!changing)
        {
            changing = true;
            StartCoroutine(NextLevelAnim());
        }
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
    }

    public void Victory()
    {
        victory.gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        StartCoroutine(BackMenuAnim());
    }
    public void Replay()
    {
        StartCoroutine(ReplayAnim());
    }

    IEnumerator NextLevelAnim()
    {
        timer.Stop();
        print("Characters End Level Anim");

        levelIdx++;
        if (levelIdx >= levels.Length)
        {
            Victory();
        }
        else
        {
            yield return ShowBlackPanel();
            Destroy(currentLevel.gameObject);
            currentLevel = Instantiate(levels[levelIdx]);
            currentLevel.Initialize(players);
            yield return HideBlackPanel();
            timer.Restart();
        }
        changing = false;
    }

    IEnumerator StartAnim()
    {
        print("Music start !");
        yield return HideBlackPanel();
    }

    IEnumerator BackMenuAnim()
    {
        print("music volum fading");
        StartCoroutine(gameMusic.GetComponent<FadeAudio>().FadeOut(1f));
        yield return ShowBlackPanel();
        SceneManager.LoadScene("Menu");
    }
    IEnumerator ReplayAnim()
    {
        print("music volum fading");
        StartCoroutine(gameMusic.GetComponent<FadeAudio>().FadeOut(1f));
        yield return ShowBlackPanel();
        SceneManager.LoadScene("Game");
    }

    public Area SwapPlayer(int areaFrom, int areaTo)
    {
        int corectionTo = areaTo - 1;
        int correctionFrom = areaFrom - 1;

        if (areas[corectionTo].controllerID > playerCount)
        {
            int temp = areas[corectionTo].controllerID;
            areas[corectionTo].controllerID = areas[correctionFrom].controllerID;
            areas[correctionFrom].controllerID = temp;

            areas[corectionTo].UpdateRendererArea(colorControler[areas[corectionTo].controllerID-1]);
            areas[correctionFrom].UpdateRendererAreaDefault();

            return areas[corectionTo];
        }
        /*
        {
            PlayerController tempPlayer = p1;
            int tempID = tempPlayer.playerID;

            p1.playerID = players[id2-1].playerID;
            players[id2 - 1].playerID = tempID;

        }
        */
        return null;
    }

    IEnumerator ShowBlackPanel()
    {
        blackPanel.gameObject.SetActive(true);
        for (float i = 0; i < 60; i++)
        {
            // float musicVolum = 1f - i / 60f;
            blackPanel.color = new Color(0, 0, 0, i / 60f);
            yield return null;
        }
    }
    IEnumerator HideBlackPanel()
    {
        blackPanel.gameObject.SetActive(true);
        for (float i = 0; i < 60; i++)
        {
            blackPanel.color = new Color(0, 0, 0, 1f - i / 60f);
            yield return null;
        }
        blackPanel.gameObject.SetActive(false);
    }
}
