using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    WorldControl world;
    public TMP_Text scoretext, dealTot,stashtxt;
    public GameObject wpanel,lpanel, hunbut,fivbut,thoubut,fiftbut,twenthoubut,
    sent,RulesPanel,ColorPanel,StartButton,RulesButton,ColorButton,MainPanel, RedButt, BlueButt, GreenButt, YellButt,GGPanel;
    public int tot,stash,ante, playeraces,dealeraces;
    bool won,lost,playing = false;
    void Start()
    {
        world = GameObject.FindGameObjectWithTag("World").GetComponent<WorldControl>();
        playing = false;
        stash = 1000;
        ante = 0;
        StashText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitButtonClick(){
        world.Hit();
    }
    public void StandButtonClick(){
        world.movin();
    }
    public void IncreasePlayerAces(){
        Debug.Log("Aced up???");
        playeraces++;
    }
    public void IncreaseDealerAces(){
        Debug.Log("Aced up???");
        dealeraces++;
    }
    
    public void HundredButton(){
        stash = stash - 100;
        ante = ante +100;
        StashText();
    }
    public void FiveHundredButton(){
        stash = stash - 500;
        ante = ante +500;
        StashText();
    }
    public void ThousandButton(){
        stash = stash - 1000;
        ante = ante +1000;
        StashText();
    }
    public void FiftyButton(){
        stash = stash - 50;
        ante = ante +50;
        StashText();
    }
    public void TwentyFiveHunButton(){
        stash = stash - 2500;
        ante = ante +2500;
        StashText();
    }

    public void RulesButt(){
        RulesPanel.SetActive(true);
    }
    public void RulesExit(){
        RulesPanel.SetActive(false);
    }
    public void Cpicker(){
        ColorPanel.SetActive(true);
    }
    public void CPickerExit(){
        ColorPanel.SetActive(false);
    }
    public void Begin(){
        MainPanel.SetActive(false);
        ColorPanel.SetActive(false);
        RulesPanel.SetActive(false);
    }

    public void Red(){
        world.BackColor(1);
    }
    public void Blue(){
        world.BackColor(2);
    }
    public void Green(){
        world.BackColor(3);
    }
    public void Yellow(){
        world.BackColor(4);
    }

    public void UpdateHandTotal(int worth){
        scoretext.SetText("Player Hand: " +worth);
        if (worth == 21){
            win();
            stash = stash+(ante*2);
            ante = 0;
            world.cut();
            StashText();
            won = true;
        }
        if (worth > 21){
            if (playeraces == 0){
                LOSER();
                world.cut();
                ante = 0;
                StashText();
                lost = true;
            }
            else {
                Debug.Log("Player Ace Detected. Player Ace Total: " +playeraces);
                playeraces--;
                world.PlayerHacks();
            }
        }
    }

    public void UpdateDealerHandTotal(int dworth){
        dealTot.SetText("Dealer Hand: "+dworth);
        if (dworth == 21){
            LOSER();
            ante = 0;
            world.cut();
            StashText();
            lost = true;
        }
        if (dworth > 21){
            if (dealeraces == 0){
                win();
                stash = stash+(ante*2);
                ante = 0;
                world.cut();
                StashText();
                won = true;
            }
            else {
                Debug.Log("Dealer Ace Detected. Dealer Ace Total: " +dealeraces);
                dealeraces--;
                world.DealerHacks();
            }
        }
    }

    public void StashText(){
        stashtxt.SetText("Stash Worth: " + stash+ "\nCurrent Ante: "+ante);
        if (stash < 2500) {twenthoubut.SetActive(false);} else {twenthoubut.SetActive(true);}
        if (stash < 1000) {thoubut.SetActive(false);} else {thoubut.SetActive(true);}
        if (stash < 500) {fivbut.SetActive(false);} else {fivbut.SetActive(true);}
        if (stash < 100) {hunbut.SetActive(false);} else {hunbut.SetActive(true);}
        if (stash < 50) {fiftbut.SetActive(false);} else {fiftbut.SetActive(true);}
        
    }
    public void SendButton(){
        if(playing == false & ante > 0){
            world.letsgo();
            playing = true;
        }
    }
    public void GameOver(){
        GGPanel.SetActive(true);
    }

    public void RunBack(){
        SceneManager.LoadScene("MainGame");
    }

    public void win(){
        wpanel.SetActive(true);
        playing = false;
    }
    public void LOSER(){
        lpanel.SetActive(true);
        playing = false;
    }
    public void Reset(){
        //SceneManager.LoadScene("MainGame");
        world.Continue();
        if (won == true){wpanel.SetActive(false); won = false;}
        if (lost == true){lpanel.SetActive(false); lost = false;}
        if (stash == 0 & ante == 0) { GameOver();}
        ante = 0;
        StashText();
        
    }

    public void KPlay(){
        world.Continue(); 
    }
}
