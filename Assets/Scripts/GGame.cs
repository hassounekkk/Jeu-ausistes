using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GGame : MonoBehaviour
{
    public string name;
    public int game_Nbr;
    public int level;
    public Add_Score_db add_Score_Db;
    public float timer_to_finish;
    public bool finish;
    public bool pause;
    public int score;
    public GameObject PauseScean;
    public GameObject finisheScean;
    public GameObject[] njom_sofar;
    public Score score_levels;
    public float max_Timer;
    public float min_Timer;
    public GameObject[] something_To_Hide;
    public void Back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void Restart_it()
    {
        
        SceneManager.LoadScene(game_Nbr, LoadSceneMode.Single);
        
    }
    public void Pause()
    {
        pause = true;
        PauseScean.SetActive(true);
    }
    public void Resume()
    {
        pause = false;
        PauseScean.SetActive(false);
    }
    public void finish_game()
    {
        for (int i = 0; i < something_To_Hide.Length; i++) something_To_Hide[i].SetActive(false);
        finisheScean.SetActive(true);
        if (timer_to_finish < min_Timer) { score=3 ; for (int i = 0; i < 3; i++)  njom_sofar[i].SetActive(true); }
        else if (timer_to_finish > min_Timer && timer_to_finish < max_Timer) { score = 2; ; for (int i = 0; i < 3; i++) njom_sofar[i].SetActive(true); }
        else { njom_sofar[0].SetActive(true); score = 1; }
    }

}
