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
    private static Image game_bg;
    private static Text game_message;
    private static Image player1_action;
    private static Image player2_action;
    private static Image player1_attack;
    private static Image player2_attack;
    private static Image player1;
    private static Image player2;
    private static Image player1_hp;
    private static Image player1_mp;
    private static Image player2_hp;
    private static Image player2_mp;
    private static Image btns_cover;

    public Sprite spt_grass;
    public Sprite spt_snow;
    public Sprite spt_player_attack;
    public Sprite spt_player_magic;
    public Sprite spt_monster_attack;
    public Sprite spt_monster_magic;
    public Sprite spt_deffend;
    public Sprite spt_player;
    public Sprite spt_monster;

    private string[] players = { "Player", "Enemy" };
    static int[] hps = new int[2];
    static int[] mps = new int[2];
    static float[] hps_m = new float[2];
    static float[] mps_m = new float[2];
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

        


        

        //battle_start(true, 0, 0, 100, 50, 1, 100, 50);

        
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
            if (mps[0] >= skl1[2])
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
    public void auto_play()
    {
        btns_cover.enabled = true;
        double w = ((hps[0] - hps[1]) + 0.2 * (mps[0] - mps[1]));
        Debug.Log(w);
        int a = Random.Range(0, 9);
        Debug.Log(a);
        if (w > 0)
        {
            if (a >= 3)
                hps[1] = 0;
            else
                hps[0] = 0;
        }
        else if (w == 0)
        {
            if (a >= 3)
                hps[0] = 0;
            else
                hps[1] = 0;
        }
        else
        {
            if (a <= 4)
                hps[1] = 0;
            else
                hps[0] = 0;
        }
        game_finish = true;
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
        battle_animation(1, Ai_action);
        defs[0] = 0;
        rs();
    }
    public void battle_animation(int player, int player_action) {

        if (player == 0) {

            player2_action.enabled = false;
            player2_attack.enabled = false;

            if (player_action == 1 || player_action == 3)
            {
                if (player_action == 1)
                    player1_attack.sprite = spt_player_attack;
                else
                    player1_attack.sprite = spt_player_magic;
                player1_attack.enabled = true;
            }
            else
            {
                player1_action.sprite = spt_deffend;
                player1_action.enabled = true;
            }

        } else {
            player1_action.enabled = false;
            player1_attack.enabled = false;
            if (player_action == 1 || player_action == 3)
            {
                if (player_action == 1)
                    player2_attack.sprite = spt_monster_attack;
                else
                    player2_attack.sprite = spt_monster_magic;
                player2_attack.enabled = true;
            }
            else
            {
                player2_action.sprite = spt_deffend;
                player2_action.transform.eulerAngles = new Vector3(0, 180, 0);
                player2_action.enabled = true;
            }
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
            btns_cover.enabled = true;
            game_message.text = game_message.text + "\nYou win!";
            player1_action.enabled = false;
            player2_action.enabled = false;     
            game_finish = true;
            Destroy(player2_gameObject);
        }
        else if (hps[0] <= 0)
        {
            hps[0] = 0;
            btns_cover.enabled = true;
            game_message.text = game_message.text + "\nYou lose!";
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

        player1_hp.transform.localScale = new Vector2(((hps[0] <= 0) ? 0 : hps[0] / hps_m[0]), 1);
        player1_mp.transform.localScale = new Vector2(((mps[0] <= 0) ? 0 : mps[0] / mps_m[0]), 1);
        player2_hp.transform.localScale = new Vector2(((hps[1] <= 0) ? 0 : hps[1] / hps_m[1]), 1);
        player2_mp.transform.localScale = new Vector2(((mps[1] <= 0) ? 0 : mps[1] / mps_m[1]), 1);
        if (mps[0] < 20) {
            Text player_mp_btn = GameObject.Find("txt_skl").GetComponent<Text>();
            player_mp_btn.color = Color.gray;
        }
        if (game_finish)

        {
            StartCoroutine(end_game());
        }
    }
    /*
     * battle start : to reset the values of battle
     * player1_first (bool) :       true -> player starts battle  / false -> AI starts battle
     * bg (int):                    the backgroud for battle   0: grass / 1: snow
     * py1 (int):                   player's character type
     * hp1 (int):                   player's hp
     * mp1 (int):                   player's mp
     * py2, hp2, mp2 :              enemy's information as same as player's
     */
    public void battle_start(bool player1_first,int bg, int py1, int hp1, int mp1,int py2, int hp2, int mp2) {

        game_bg = GameObject.Find("Players_view").GetComponent<Image>();
        game_message = GameObject.Find("txt_battle_msg").GetComponent<Text>();
        player1 = GameObject.Find("img_ply1").GetComponent<Image>();
        player2 = GameObject.Find("img_ply2").GetComponent<Image>();
        player1_action = GameObject.Find("img_ply1_act").GetComponent<Image>();
        player2_action = GameObject.Find("img_ply2_act").GetComponent<Image>();
        player1_attack = GameObject.Find("img_ply1_at").GetComponent<Image>();
        player2_attack = GameObject.Find("img_ply2_at").GetComponent<Image>();
        player1_hp = GameObject.Find("img_ply1_hp").GetComponent<Image>();
        player1_mp = GameObject.Find("img_ply1_mp").GetComponent<Image>();
        player2_hp = GameObject.Find("img_ply2_hp").GetComponent<Image>();
        player2_mp = GameObject.Find("img_ply2_mp").GetComponent<Image>();
        btns_cover = GameObject.Find("img_btns_cover").GetComponent<Image>();

        player1_first = true;
        game_finish = false;

        if (player1_first)
            player1_move = true;
        else
            player1_move = false;

        ply1 = py1;
        hps[0] = hp1;
        mps[0] = mp1;
        hps_m[0] = hp1;
        mps_m[0] = mp1;

        ply2 = py2;
        hps[1] = hp2;
        mps[1] = mp2;
        hps_m[1] = hp2;
        mps_m[1] = mp2;
        defs[0] = defs[1] = 0;

        //set for battle bg
        if (bg == 0)
            game_bg.sprite = spt_grass;
        else if (bg == 1)
            game_bg.sprite = spt_snow;
        //set for player's character image
        player1.sprite = spt_player;
        //set for enemy's character image
        player2.sprite = spt_monster;

        player1_action.enabled = false;
        player1_attack.enabled = false;
        player2_action.enabled = false;
        player2_attack.enabled = false;
        btns_cover.enabled = false;
    }
}
