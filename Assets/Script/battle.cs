using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class battle : MonoBehaviour {

    static bool player1_first;
    static bool player1_move;
    //0: attack  / 1: defend  / 2: skill  / 3: surrender
    static int player_action;
    static int Ai_action;
    static bool game_finish;

    static Text game_result;
    static Text game_message;
    static Image player1_action;
    static Image player2_action;
    static Image player1_hp;
    static Image player1_mp;
    static Image player2_hp;
    static Image player2_mp;

    string[] players = { "Player", "Enemy" };
    static int[] hps = new int[2];
    static int[] mps = new int[2];
    static int[] defs = new int[2];

    int[] atk = { 10, 15 };
    int[] def = { 7, 10 };
    int[] skl = { 18, 23, 20 };
    bool srn = false;



    // Use this for initialization
    void Start () {
        //print("start");
        player1_first = true;
        game_finish = false;

        if (player1_first)
            player1_move = true;
        else
            player1_move = false;

        hps[0] = hps[1] = 100;
        mps[0] = mps[1] = 50;
        defs[0] = defs[1] = 0;
        game_result = GameObject.Find("txt_game_rs").GetComponent<Text>();
        game_message = GameObject.Find("txt_battle_msg").GetComponent<Text>();
        player1_action = GameObject.Find("img_ply1_act").GetComponent<Image>();
        player2_action = GameObject.Find("img_ply2_act").GetComponent<Image>();
        player1_hp = GameObject.Find("img_ply1_hp").GetComponent<Image>();
        player1_mp = GameObject.Find("img_ply1_mp").GetComponent<Image>();
        player2_hp = GameObject.Find("img_ply2_hp").GetComponent<Image>();
        player2_mp = GameObject.Find("img_ply2_mp").GetComponent<Image>();

        player1_action.enabled = false;
        player2_action.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        //print("update");
        if (game_finish)
            print("Battle finished!");
        else { 
            if (hps[1] <= 0) {
                game_result.text = "You win!";
                player1_action.enabled = false;
                player2_action.enabled = false;
                //game_message.text = "battle finished !";
                game_finish = true;
            } else if (hps[0] <= 0) {
                game_result.text = "You lose!";
                player1_action.enabled = false;
                player2_action.enabled = false;
                game_finish = true;
            } else if (srn == true) {
                game_result.text = "Surrender!";
                player1_action.enabled = false;
                player2_action.enabled = false;
                game_finish = true;
            } else if (!player1_move && !game_finish) {
                StartCoroutine(Example());
                player1_move = true;
            }
            print("Player1:\nhp: " + hps[0] + "mp: " + mps[0]);
            print("Player2:\nhp: " + hps[1] + "mp: " + mps[1]);
            player1_hp.transform.localScale = new Vector2(((hps[0] <= 0) ? 0 : hps[0] / 100.0f), 1);
            player1_mp.transform.localScale = new Vector2(((mps[0] <= 0) ? 0 : mps[0] / 40.0f), 1);
            player2_hp.transform.localScale = new Vector2(((hps[1] <= 0) ? 0 : hps[1] / 100.0f), 1);
            player2_mp.transform.localScale = new Vector2(((mps[1] <= 0) ? 0 : mps[1] / 40.0f), 1);
        }
    }   

    public void attack() {
        int damage;
        if (player1_move && !game_finish){
            damage = (Random.Range(atk[0], atk[1] + 1) - defs[1]);
            if(hps[1] > damage)
                game_message.text = "Player attack !\nEnemy lose " + damage + " hp!";
            else
                game_message.text = "Player attack !\nEnemy lose " + hps[1] + " hp!";
            hps[1] -= damage;
            battle_animation(0, 0);
        }
        player1_move = false;
    }
    public void defend() {
        if (player1_move && !game_finish) { 
            defs[0] = Random.Range(def[0], def[1] + 1);
            game_message.text = "Player defend raised up !";
            battle_animation(0, 1);
        }
        player1_move = false;
    }
    public void skill(){
        int damage;
        if (player1_move && !game_finish)
            if (mps[0] > skl[2]) {
                damage = Random.Range(skl[0], skl[1] + 1);
                mps[0] -= skl[2];
                if (hps[1] > damage)
                    game_message.text = "Player used skill !\nEnemy lose " + damage + " hp!";
                else
                    game_message.text = "Player used skill !\nEnemy lose " + hps[1] + " hp!";
                hps[1] -= damage;
                battle_animation(0, 2);
                player1_move = false;
            }else
                game_message.text = "Have no enough mp!";
    }
    public void surrender() {
        if (player1_move && !game_finish)
            srn = true;
        battle_animation(0, 3);
        player1_move = false;
    }
    public void Ai_move() {
        print("Ai moved");
        int damage;
        defs[1] = 0;
        Ai_action = Random.Range(0, 9);

        if (Ai_action < 3) {
            damage = (Random.Range(atk[0], atk[1] + 1) - defs[1]);
            if (hps[0] > damage)
                game_message.text = "Enemy attack !\nPlayer lose " + damage + " hp!";
            else
                game_message.text = "Enemy attack !\nPlayer lose " + hps[0] + " hp!";
            hps[0] -= damage;
        } else if (Ai_action < 5) { 
            defs[1] = Random.Range(def[0], def[1] + 1);
            game_message.text = "Enemy defend raised up !";
        } else
           if (mps[1] > skl[2]) {
                damage = Random.Range(skl[0], skl[1] + 1);
                mps[1] -= skl[2];
                if (hps[0] > damage)
                    game_message.text = "Enemy used skill !\nPlayer lose " + damage + " hp!";
                else
                    game_message.text = "Enemy used skill !\nPlayer lose " + hps[0] + " hp!";
                hps[0] -= damage;
        } else {
                damage = (Random.Range(atk[0], atk[1] + 1) - defs[1]);
                Ai_action = 0;
                if (hps[0] > damage)
                    game_message.text = "Enemy attack !\nPlayer lose " + damage + " hp!";
                else
                    game_message.text = "Enemy attack !\nPlayer lose " + hps[0] + " hp!";
                hps[1] -= damage;
        }
        battle_animation(1, Ai_action);
        defs[0] = 0;
    }
    public void battle_animation(int player, int player_action) {
        string img = "battle_img";
        //print("Player: " + player + "\taction: " + player_action);
        string ply_file_nm = img += player_action;
        Sprite battle_amt = Resources.Load(ply_file_nm, typeof(Sprite)) as Sprite;

        if (player == 0) {
            player2_action.enabled = false;
            player1_action.sprite = battle_amt;
            //change sprite based on  players' action
            player1_action.enabled = true;
            player1_action.sprite = battle_amt;

        } else {
            player1_action.enabled = false;
            player2_action.sprite = battle_amt;
            //change sprite based on  players' action
            player2_action.enabled = true;
            
        } 
     
    }
    IEnumerator Example() {
        yield return new WaitForSeconds(2.5f);
        Ai_move();
    }
}
