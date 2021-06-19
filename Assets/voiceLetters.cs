using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceLetters : GGame
{
    float timer_to_animate = 2;
    public GameObject animate_hand;
    bool animateHande;
    bool start_animate;
    public AudioSource[] voice;
    public GameObject[] Leters;
    List<GameObject> letters = new List<GameObject>();
    public int curLetter;
    public Collider2D chebka;
    Vector3[] posi = new Vector3[4];
    int lvl;
    bool add_DB;
    public GameObject horofplat;

    private void Awake()
    {
        posi[0] = new Vector3(-6, 0, 0);
        posi[1] = new Vector3(-3, 0, 0);
        posi[2] = new Vector3(0, 0, 0);
        posi[3] = new Vector3(3, 0, 0);
        score_levels = FindObjectOfType<Score>();
        add_Score_Db = FindObjectOfType<Add_Score_db>();
        score_levels.initialiserStars(6);
        min_Timer = 40;
        max_Timer = 90;
        for (int i = 0; i < 3; i++) rondomPosi();
    }

    void rondomPosi()
    {
        int a = Random.Range(0, 4);
        int b = Random.Range(0, 4);
        while(a==b) b = Random.Range(0, 4);
        Vector3 aide;
        aide = posi[a];
        posi[a] = posi[b];
        posi[b] = aide;
    }

    void Start()
    {
        
            curLetter = Random.Range(0, voice.Length);
            letters.Add(Instantiate(Leters[curLetter], posi[0], Quaternion.identity));
            letters[0].GetComponent<MoveLetter>().indice = curLetter;
            Physics2D.IgnoreCollision(letters[0].GetComponent<Collider2D>(), chebka);
        for (int i = 0; i < 3; i++) rondomPosi();
        int[] treeNbr = rondom3nbr(curLetter);
        if (lvl < 2)
        {
            letters.Add(Instantiate(Leters[treeNbr[0]], posi[1], Quaternion.identity));
            letters[1].GetComponent<MoveLetter>().indice = treeNbr[0];
            letters.Add(Instantiate(Leters[treeNbr[1]], posi[2], Quaternion.identity));
            letters[2].GetComponent<MoveLetter>().indice = treeNbr[1];
        }
        else
        {
            letters.Add(Instantiate(Leters[treeNbr[0]], posi[1], Quaternion.identity));
            letters[1].GetComponent<MoveLetter>().indice = treeNbr[0];
            letters.Add(Instantiate(Leters[treeNbr[1]], posi[2], Quaternion.identity));
            letters[2].GetComponent<MoveLetter>().indice = treeNbr[1];
            letters.Add(Instantiate(Leters[treeNbr[2]], posi[3], Quaternion.identity));
            letters[3].GetComponent<MoveLetter>().indice = treeNbr[1];
        }
        speek();
        
    }

   public void showhorof()
    {
        horofplat.SetActive(true);
    }  
    public void hidehorof()
    {
        horofplat.SetActive(false);
    }

    int[] rondom3nbr(int Cur )
    {
        int[] nbrs = new int[3];

        nbrs[0] = Random.Range(0, Leters.Length);
        while(nbrs[0] == Cur) nbrs[0]=Random.Range(0, Leters.Length);

        nbrs[1] = Random.Range(0, Leters.Length);
        while (nbrs[1] == Cur || nbrs[1] == nbrs[0]) nbrs[1]=Random.Range(0, Leters.Length);

        nbrs[2] = Random.Range(0, Leters.Length);
        while (nbrs[1] == Cur || nbrs[2] == nbrs[0] || nbrs[2] == nbrs[1]) nbrs[2] = Random.Range(0, Leters.Length);
        return nbrs;
    }

    public void nextLevel()
    {
        if (!finish)
        {
            lvl++;
            if (lvl < 6)
            {
                foreach (GameObject harf in letters) harf.SetActive(false);
                letters.Clear();
                Start();
            }
            score_levels.AddStar();
        }
    }

    private void Update()
    {
        if(!start_animate)timer_to_animate -= Time.deltaTime;
        if(timer_to_animate<=0)
        {
            start_animate = true;
            timer_to_animate = 1;
            animate_hand.SetActive(true);
            float x = letters[0].transform.position.x+1;
            float y = letters[0].transform.position.y - 1;
            animate_hand.transform.position = new Vector3(x, y, 0);
            animateHande = true;
        }
        if (!finish && !pause) timer_to_finish += Time.deltaTime;
        if (lvl >= 6)  finish = true; 
        if (finish) 
        {
            foreach (GameObject harf in letters) harf.SetActive(false);
            finish_game();
            if (!add_DB) add_Score_Db.UpdateData(PlayerPrefs.GetInt("id_user"),21, score, timer_to_finish);
            add_DB = true;
            
        }

        if (animateHande)
        {
            float x_init = animate_hand.transform.position.x;
            float y_init = animate_hand.transform.position.y;
            if (x_init <= 6) x_init = x_init + (3.5f* Time.deltaTime);
            if (y_init <= 2) y_init = y_init + (3.5f * Time.deltaTime);
            animate_hand.transform.position = new Vector3(x_init, y_init, 0);

            if (animate_hand.transform.position.x >= 6 && animate_hand.transform.position.y >= 2) { animateHande=false ; Destroy(animate_hand); };
        }

    }

    public void speek()
    {
        voice[curLetter].Play();
    }
}
