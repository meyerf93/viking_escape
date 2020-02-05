using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {

    [SerializeField] Image blackPanel;

    [SerializeField] GameObject[] buttons;
    [SerializeField] FadeAudio menuAudio;
    [SerializeField] CanvasRenderer creditsPanel;
    [SerializeField] GameObject menu;

    bool isCreditsOpen = false;
    IEnumerator creditsCoroutine;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartAnim());
        EventSystem.current.SetSelectedGameObject(buttons[0]);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("B 1") && isCreditsOpen)
        {
            OpenCredits(false);
        }
    }

    public void Quit()
    {
        StartCoroutine(QuitAnim());
    }

    public void Play()
    {
        StartCoroutine(PlayAnim());
    }

    public void OpenCredits(bool willOpen) {
        print(willOpen);
        if(creditsCoroutine != null)
            StopCoroutine(creditsCoroutine);
        
        if(!willOpen) {
            menu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(buttons[0]);
            creditsPanel.gameObject.SetActive(false);
            creditsPanel.SetAlpha(0f);
        } else {
            menu.SetActive(false);
            creditsPanel.gameObject.SetActive(true);
            creditsCoroutine = FadeCredits();
            StartCoroutine(creditsCoroutine);
        }
        isCreditsOpen = willOpen;
    }

    IEnumerator StartAnim()
    {
        print("Music start !");
        blackPanel.gameObject.SetActive(true);
        yield return null;
        for (float i = 0; i < 60; i++)
        {
            blackPanel.color = new Color(0, 0, 0, 1f - i / 60f);
            yield return null;
        }
        blackPanel.gameObject.SetActive(false);
    }
    IEnumerator QuitAnim()
    {
        blackPanel.gameObject.SetActive(true);
        print("music volum fading");
        StartCoroutine(menuAudio.FadeOut(1f));
        for (float i = 0; i < 60; i++)
        {
            // float musicVolum = 1f - i / 60f;
            blackPanel.color = new Color(0, 0, 0, i / 60f);
            yield return null;
        }
        Application.Quit();
    }

    IEnumerator PlayAnim()
    {
        blackPanel.gameObject.SetActive(true);
        print("music volum fading");
        StartCoroutine(menuAudio.FadeOut(1f));
        for (float i = 0; i < 60; i++)
        {
           // float musicVolum = 1f - i / 60f;
            blackPanel.color = new Color(0, 0, 0, i / 60f);
            yield return null;
        }
        SceneManager.LoadScene("Game");
    }

    IEnumerator FadeCredits() {
        float currentAlpha = creditsPanel.GetAlpha();
        
        for (float i = 0; i < 30; i++)
        {
            creditsPanel.SetAlpha(i / 30f);
            yield return null;
        }
    }
}
