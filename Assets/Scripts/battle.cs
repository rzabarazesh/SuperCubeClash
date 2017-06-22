using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class battle : MonoBehaviour {

    public bool player1_first;
    public bool player1_move;
    public int bg = 1;
    public int ply1 = 0;
    public int ply2 = 1;
    private int Ai_action;
    public bool game_finish;

    private static GameObject player1_gameObject;
    private static GameObject player2_gameObject;
    private Image game_bg;
    private Text game_message;
    private Image player1_action;
    private Image player2_action;
    private Image player1;
    private Image player2;
    private Image player1_hp;
    private Image player1_mp;
    private Image player2_hp;
    private Image player2_mp;
    private Image btns_cover;

    public Sprite spt_tmp;
    public Sprite spt_grass;
    public Sprite spt_woods;
    public Sprite spt_attack;
    public Sprite spt_arrow;
    public Sprite spt_deffend;
    public Sprite spt_skill;
    public Sprite spt_saber;
    public Sprite spt_archer;

    private string[] players = { "Player", "Enemy" };
    int[] hps = new int[2];
    int[] mps = new int[2];
    private int[] crtl = new int[2];
    private int[] defs = new int[2];

    private int[] atk1 = { 10, 15 };
    private int[] atk2 = { 10, 15 };
    private int[] def1 = { 7, 10 };
    private int[] def2 = { 7, 10 };
    private int[] skl1 = { 18, 23, 20 };
    private int[] skl2 = { 18, 23, 20 };
    private bool srn = false;

    public void setPlayerObjects(GameObject o1, GameObject o2)
    {
        player1_gameObject = o1;
        player2_gameObject = o2;
    }

    // Use this for initialization
    void Start() {

        

        game_bg = GameObject.Find("Players_view").GetComponent<Image>();
        game_message = GameObject.Find("txt_battle_msg").GetComponent<Text>();
        player1 = GameObject.Find("img_ply1").GetComponent<Image>();
        player2 = GameObject.Find("img_ply2").GetComponent<Image>();
        player1_action = GameObject.Find("img_ply1_act").GetComponent<Image>();
        player2_action = GameObject.Find("img_ply2_act").GetComponent<Image>();
        player1_hp = GameObject.Find("img_ply1_hp").GetComponent<Image>();
        player1_mp = GameObject.Find("img_ply1_mp").GetComponent<Image>();
        player2_hp = GameObject.Find("img_ply2_hp").GetComponent<Image>();
        player2_mp = GameObject.Find("img_ply2_mp").GetComponent<Image>();
        btns_cover = GameObject.Find("img_btns_cover").GetComponent<Image>();
        

        battle_start(true, 0, 0, 100, 50, 1, 100, 50);

        
    }

    public void attack() {
        int damage;
        if (player1_move && !game_finish) {
            damage = (Random.Range(atk1[0], atk1[1] + 1) - defs[1]);
            if (hps[1] > damage)
                game_message.text = "Player attack !\nEnemy lose " + damage + " hp!";
            else
                game_message.text = "Player attack !\nEnemy lose " + hps[1] + " hp!";
            hps[1] -= damage;
            if (ply1 == 1)
                battle_animation(0, 11);
            else
                battle_animation(0, 1);
        }
        player1_move = false;
        rs();
    }
    public void defend() {
        if (player1_move && !game_finish) {
            defs[0] = Random.Range(def1[0], def1[1] + 1);
            game_message.text = "Player defend raised up !";
            battle_animation(0, 2);
        }
        player1_move = false;
        rs();
    }
    public void skill() {
        int damage;
        if (player1_move && !game_finish)
        {
            if (mps[0] > skl1[2])
            {
                damage = Random.Range(skl1[0], skl1[1] + 1);
                mps[0] -= skl1[2];
                if (hps[1] > damage)
                    game_message.text = "Player used skill !\nEnemy lose " + damage + " hp!";
                else
                    game_message.text = "Player used skill !\nEnemy lose " + hps[1] + " hp!";
                hps[1] -= damage;
                battle_animation(0, 3);
                player1_move = false;
                rs();
            }
            else
                game_message.text = "Have no enough mp!";
        }

    }
    public void surrender() {
        if (player1_move && !game_finish)
            srn = true;
        battle_animation(0, 3);
        player1_move = false;
        rs();
    }
    public void Ai_move() {
        
        int damage;
        defs[1] = 0;
        Ai_action = Random.Range(0, 9);

        if (Ai_action < 3) {
            damage = (Random.Range(atk2[0], atk2[1] + 1) - defs[0]);
            if (hps[0] > damage)
                game_message.text = "Enemy attack !\nPlayer lose " + damage + " hp!";
            else
                game_message.text = "Enemy attack !\nPlayer lose " + hps[0] + " hp!";
            hps[0] -= damage;
            Ai_action = 1;
        } else if (Ai_action < 5) {
            defs[1] = Random.Range(def2[0], def2[1] + 1);
            game_message.text = "Enemy defend raised up !";
            Ai_action = 2;
        } else
           if (mps[1] > skl2[2]) {
            damage = Random.Range(skl2[0], skl2[1] + 1) - defs[0];
            mps[1] -= skl2[2];
            if (hps[0] > damage)
                game_message.text = "Enemy used skill !\nPlayer lose " + damage + " hp!";
            else
                game_message.text = "Enemy used skill !\nPlayer lose " + hps[0] + " hp!";
            hps[0] -= damage;
            Ai_action = 3;
        } else {
            damage = (Random.Range(atk2[0], atk2[1] + 1) - defs[0]);
            Ai_action = 0;
            if (hps[0] > damage)
                game_message.text = "Enemy attack !\nPlayer lose " + damage + " hp!";
            else
                game_message.text = "Enemy attack !\nPlayer lose " + hps[0] + " hp!";
            hps[0] -= damage;
            Ai_action = 1;
        }
        if (ply2 == 1 && Ai_action == 1)
            Ai_action = 11;
        battle_animation(1, Ai_action);
        defs[0] = 0;
        rs();
    }
    public void battle_animation(int player, int player_action) {
        if (player_action == 1)
            spt_tmp = spt_attack;
        else if (player_action == 11)
            spt_tmp = spt_arrow;
        else if (player_action == 2)
            spt_tmp = spt_deffend;
        else
            spt_tmp = spt_skill;

        if (player == 0) {

            player2_action.enabled = false;
            player1_action.enabled = true;
            player1_action.sprite = spt_tmp;
            if (player_action == 1)
                player1_action.transform.eulerAngles = new Vector3(0, 0, -45);
            else if (player_action == 11)
                player1_action.transform.eulerAngles = new Vector3(0, 0, -90);
            else
                player1_action.transform.eulerAngles = new Vector3(0, 0, 0);

        } else {
            player1_action.enabled = false;
            player2_action.enabled = true;
            player2_action.sprite = spt_tmp;
            if (player_action == 1)
                player2_action.transform.eulerAngles = new Vector3(0, 0, 45);
            else if (player_action == 11)
                player2_action.transform.eulerAngles = new Vector3(0, 0, 90);
            else
                player2_action.transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
    IEnumerator delay() {
        yield return new WaitForSeconds(0.5f);
        Ai_move();
        btns_cover.enabled = false;
    }
    IEnumerator end_game()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
    public void rs() {
        
        if (hps[1] <= 0)
        {
            hps[1] = 0;
            game_message.text = game_message.text + "\nYou win!";
            player1_action.enabled = false;
            player2_action.enabled = false;     
            game_finish = true;
            Destroy(player2_gameObject);
        }
        else if (hps[0] <= 0)
        {
            hps[0] = 0;
            game_message.text = game_message.text + "\nYou lose!";
            player1_action.enabled = false;
            player2_action.enabled = false;
            game_finish = true;
            Destroy(player1_gameObject);
        }
        else if (srn == true)
        {
            game_message.text = "Surrender!";
            player1_action.enabled = false;
            player2_action.enabled = false;
            game_finish = true;
            Destroy(player1_gameObject);
        }
        else if (!player1_move)
        {
            btns_cover.enabled = true;
            StartCoroutine(delay());
            player1_move = true;

        }

        player1_hp.transform.localScale = new Vector2(((hps[0] <= 0) ? 0 : hps[0] / 100.0f), 1);
        player1_mp.transform.localScale = new Vector2(((mps[0] <= 0) ? 0 : mps[0] / 40.0f), 1);
        player2_hp.transform.localScale = new Vector2(((hps[1] <= 0) ? 0 : hps[1] / 100.0f), 1);
        player2_mp.transform.localScale = new Vector2(((mps[1] <= 0) ? 0 : mps[1] / 40.0f), 1);
        if (game_finish)
        {
            StartCoroutine(end_game());
        }
    }
    /*
     * battle start : to reset the values of battle
     * player1_first (bool) :       true -> player starts battle  / false -> AI starts battle
     * bg (int):                    the backgroud for battle
     * py1 (int):                   player's character type
     * hp1 (int):                   player's hp
     * mp1 (int):                   player's mp
     * py2, hp2, mp2 :              enemy's information as same as player's
     */
    public void battle_start(bool player1_first,int bg, int py1, int hp1, int mp1,int py2, int hp2, int mp2) {
        player1_first = true;
        game_finish = false;

        if (player1_first)
            player1_move = true;
        else
            player1_move = false;

        ply1 = py1;
        hps[0] = hp1;
        mps[0] = mp1;

        ply2 = py2;
        hps[1] = hp2;
        mps[1] = mp2;
        defs[0] = defs[1] = 0;

        //set for battle bg
        if (bg == 0)
            game_bg.sprite = spt_grass;
        else if (bg == 1)
            game_bg.sprite = spt_woods;
        //set for player's character image
        if (ply1 == 0)
            player1.sprite = spt_saber;
        else if (ply1 == 1)
            player1.sprite = spt_archer;
        //set for enemy's character image
        if (ply2 == 0)
            player2.sprite = spt_saber;
        else if (ply2 == 1)
            player2.sprite = spt_archer;
        player2.transform.eulerAngles = new Vector3(0, 180, 0);

        player1_action.enabled = false;
        player2_action.enabled = false;
        btns_cover.enabled = false;
    }
}
