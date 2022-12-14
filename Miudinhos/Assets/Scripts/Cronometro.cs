using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    public Image timer_text;
    public Image go;
    private bool firstfivesecs;

    public float timer;

    [Header("Tempo para as medalhas (segundos)")]
    public int timeGoldenMedal;
    public int timeSilverMedal;
    public int timeBronzeMedal;
    public GameObject GoldenMedal;
    public GameObject SilverMedal;
    public GameObject BronzeMedal;

    public GameObject EndPanel;

    private int minigame1_placed;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        timer_text.gameObject.SetActive(false);
        Time.timeScale = 1f;

        minigame1_placed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        setTimer();
        CheckMinigame1();
        if (firstfivesecs && timer <= 3)
        {
            go.gameObject.SetActive(true);
        }
    }

    void CheckMedal()
    {
        if (timer < timeGoldenMedal) {
            GoldenMedal.SetActive(true);
        } else if (timer < timeSilverMedal) {
            SilverMedal.SetActive(true);
        } else {
            BronzeMedal.SetActive(true);
        }
    }

    private void setTimer()
    {
        if (timer >= 60)
        {
            timer_text.gameObject.SetActive(true);
            timer = 0f;
        }
        else if (timer >= 5)
        {
            timer_text.gameObject.SetActive(false);
            go.gameObject.SetActive(false);
            firstfivesecs = false;
        }
    }

    public void AddMinigame1()
    {
        minigame1_placed += 1;
    }

    private void CheckMinigame1()
    {
        if (minigame1_placed >= 5)
        {
            EndPanel.SetActive(true);
            Time.timeScale = 0f;
            CheckMedal();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
