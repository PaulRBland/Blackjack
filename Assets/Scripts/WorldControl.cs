using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class WorldControl : MonoBehaviour
{
    public int[] deck;
    public int cardnum,flex,stash;
    public int playercardsdealt,dealercardsdealt;
    public int spot = 0;
    public String num;
    public GameObject card, deckobj;
    public int hworth, dworth,cardcolor;
    public bool cardkind, inplay;
    public GameObject[] Cards;
    CanvasScript text;
    CardScript cards;
    // Start is called before the first frame update
    void Start()
    {
        inplay = false;
        stash = 1000;
        deck = getUniqueRandomArray(1,52,52);
        text = GameObject.FindGameObjectWithTag("Text").GetComponent<CanvasScript>();
        //StartCoroutine(GAMING());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public static int[] getUniqueRandomArray(int min, int max, int count) {
        int[] result = new int[count];
        List<int> numbersInOrder = new List<int>();
        for (var x = min; x <= max; x++) {
            Debug.Log("Cards Prepared: " +x);
            numbersInOrder.Add(x);
        }
        for (var x = 0; x < count-1; x++) {
            var randomIndex = UnityEngine.Random.Range(1, numbersInOrder.Count);
            result[x] = numbersInOrder[randomIndex];
            Debug.Log("Cards loaded: " +x);
            numbersInOrder.RemoveAt(randomIndex);
    }

    return result;
    }

    public int getCardNum(){
        Debug.Log("Spot?? " +spot);
        cardnum = deck[spot];
        spot = spot+1;
        
        if (cardkind == true) {
            playercardsdealt++;
            Appraisal(cardnum);
            text.UpdateHandTotal(hworth);
        }
        else if (cardkind == false ) {
            dealercardsdealt++;
            DAppraisal(cardnum);
            text.UpdateDealerHandTotal(dworth);
        }
        
        text.UpdateHandTotal(hworth);
        if (spot == 50) {Shuffle();}
        return cardnum;
    }

    public int getPlayerCardsDealt() {
        return playercardsdealt;
    }
    public int getDealerCardsDealt() {
        return dealercardsdealt;
    }
    public bool getDest(){
        return cardkind;
    }

    public void PlayerHacks(){
        hworth = hworth -10;
        text.UpdateHandTotal(hworth);
    }
    public void DealerHacks(){
        dworth = dworth -10;
        text.UpdateDealerHandTotal(dworth);
    }


    public void Hit(){
        if (inplay == true){
            cardkind = true;
            Instantiate(card,gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    public void Appraisal(int cardnum){
        if (cardnum == 1){hworth = hworth + 11; text.IncreasePlayerAces();} //Ace
        else if (cardnum == 2){hworth = hworth + 2;} 
        else if (cardnum == 3){hworth = hworth + 3;}
        else if (cardnum == 4){hworth = hworth + 4;}
        else if (cardnum == 5){hworth = hworth + 5;}
        else if (cardnum == 6){hworth = hworth + 6;}
        else if (cardnum == 7){hworth = hworth + 7;}
        else if (cardnum == 8){hworth = hworth + 8;}
        else if (cardnum == 9){hworth = hworth + 9;}
        else if (cardnum == 10){hworth = hworth + 10;}
        else if (cardnum == 11){hworth = hworth + 11; text.IncreasePlayerAces();} //Ace
        else if (cardnum == 12){hworth = hworth + 2;}
        else if (cardnum == 13){hworth = hworth + 3;}
        else if (cardnum == 14){hworth = hworth + 4;}
        else if (cardnum == 15){hworth = hworth + 5;}
        else if (cardnum == 16){hworth = hworth + 6;}
        else if (cardnum == 17){hworth = hworth + 7;}
        else if (cardnum == 18){hworth = hworth + 8;}
        else if (cardnum == 19){hworth = hworth + 9;}
        else if (cardnum == 20){hworth = hworth + 10;}
        else if (cardnum == 21){hworth = hworth + 11; text.IncreasePlayerAces();} //Ace
        else if (cardnum == 22){hworth = hworth + 2;}
        else if (cardnum == 23){hworth = hworth + 3;}
        else if (cardnum == 24){hworth = hworth + 4;}
        else if (cardnum == 25){hworth = hworth + 5;}
        else if (cardnum == 26){hworth = hworth + 6;}
        else if (cardnum == 27){hworth = hworth + 7;}
        else if (cardnum == 28){hworth = hworth + 8;}
        else if (cardnum == 29){hworth = hworth + 9;}
        else if (cardnum == 30){hworth = hworth + 10;}
        else if (cardnum == 31){hworth = hworth + 11; text.IncreasePlayerAces();} //Ace
        else if (cardnum == 32){hworth = hworth + 2;}
        else if (cardnum == 33){hworth = hworth + 3;}
        else if (cardnum == 34){hworth = hworth + 4;}
        else if (cardnum == 35){hworth = hworth + 5;}
        else if (cardnum == 36){hworth = hworth + 6;}
        else if (cardnum == 37){hworth = hworth + 7;}
        else if (cardnum == 38){hworth = hworth + 8;}
        else if (cardnum == 39){hworth = hworth + 9;}
        else if (cardnum == 40){hworth = hworth + 10;}
        else if (cardnum == 41){hworth = hworth + 10;}
        else if (cardnum == 42){hworth = hworth + 10;}
        else if (cardnum == 43){hworth = hworth + 10;}
        else if (cardnum == 44){hworth = hworth + 10;}
        else if (cardnum == 45){hworth = hworth + 10;}
        else if (cardnum == 46){hworth = hworth + 10;}
        else if (cardnum == 47){hworth = hworth + 10;}
        else if (cardnum == 48){hworth = hworth + 10;}
        else if (cardnum == 49){hworth = hworth + 10;}
        else if (cardnum == 50){hworth = hworth + 10;}
        else if (cardnum == 51){hworth = hworth + 10;}
        else if (cardnum == 52){hworth = hworth + 10;}
    }

    public void DAppraisal(int cardnum){
        if (cardnum == 1){dworth = dworth + 11; text.IncreaseDealerAces();} //Ace
        else if (cardnum == 2){dworth = dworth + 2;} 
        else if (cardnum == 3){dworth = dworth + 3;}
        else if (cardnum == 4){dworth = dworth + 4;}
        else if (cardnum == 5){dworth = dworth + 5;}
        else if (cardnum == 6){dworth = dworth + 6;}
        else if (cardnum == 7){dworth = dworth + 7;}
        else if (cardnum == 8){dworth = dworth + 8;}
        else if (cardnum == 9){dworth = dworth + 9;}
        else if (cardnum == 10){dworth = dworth + 10;}
        else if (cardnum == 11){dworth = dworth + 11; text.IncreaseDealerAces();} //Ace
        else if (cardnum == 12){dworth = dworth + 2;}
        else if (cardnum == 13){dworth = dworth + 3;}
        else if (cardnum == 14){dworth = dworth + 4;}
        else if (cardnum == 15){dworth = dworth + 5;}
        else if (cardnum == 16){dworth = dworth + 6;}
        else if (cardnum == 17){dworth = dworth + 7;}
        else if (cardnum == 18){dworth = dworth + 8;}
        else if (cardnum == 19){dworth = dworth + 9;}
        else if (cardnum == 20){dworth = dworth + 10;}
        else if (cardnum == 21){dworth = dworth + 11; text.IncreaseDealerAces();}  //Ace
        else if (cardnum == 22){dworth = dworth + 2;}
        else if (cardnum == 23){dworth = dworth + 3;}
        else if (cardnum == 24){dworth = dworth + 4;}
        else if (cardnum == 25){dworth = dworth + 5;}
        else if (cardnum == 26){dworth = dworth + 6;}
        else if (cardnum == 27){dworth = dworth + 7;}
        else if (cardnum == 28){dworth = dworth + 8;}
        else if (cardnum == 29){dworth = dworth + 9;}
        else if (cardnum == 30){dworth = dworth + 10;}
        else if (cardnum == 31){dworth = dworth + 11; text.IncreaseDealerAces();} //Ace
        else if (cardnum == 32){dworth = dworth + 2;}
        else if (cardnum == 33){dworth = dworth + 3;}
        else if (cardnum == 34){dworth = dworth + 4;}
        else if (cardnum == 35){dworth = dworth + 5;}
        else if (cardnum == 36){dworth = dworth + 6;}
        else if (cardnum == 37){dworth = dworth + 7;}
        else if (cardnum == 38){dworth = dworth + 8;}
        else if (cardnum == 39){dworth = dworth + 9;}
        else if (cardnum == 40){dworth = dworth + 10;}
        else if (cardnum == 41){dworth = dworth + 10;}
        else if (cardnum == 42){dworth = dworth + 10;}
        else if (cardnum == 43){dworth = dworth + 10;}
        else if (cardnum == 44){dworth = dworth + 10;}
        else if (cardnum == 45){dworth = dworth + 10;}
        else if (cardnum == 46){dworth = dworth + 10;}
        else if (cardnum == 47){dworth = dworth + 10;}
        else if (cardnum == 48){dworth = dworth + 10;}
        else if (cardnum == 49){dworth = dworth + 10;}
        else if (cardnum == 50){dworth = dworth + 10;}
        else if (cardnum == 51){dworth = dworth + 10;}
        else if (cardnum == 52){dworth = dworth + 10;}
    }
    
    
    public void movin(){
        if (inplay == true){ StartCoroutine(DealerMotions());}
    }
    public void letsgo(){
        StartCoroutine(GAMING());
    }
    IEnumerator  DealerMotions(){
        cardkind = false;
        Instantiate(card,gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(1);
        if (dworth < 21){
            StartCoroutine(DealerMotions());
        }
    }

    public void BackColor(int ccode){
        cardcolor = ccode;
        if (ccode == 1){
            deckobj.GetComponent<Renderer>().material.color = Color.red;
        }
        if (ccode == 2){
            deckobj.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (ccode == 3){
            deckobj.GetComponent<Renderer>().material.color = Color.green;
        }
        if (ccode == 4){
            deckobj.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
    public int GetCardColorNum(){
        return cardcolor;
    }


    IEnumerator GAMING(){
        //yield return new WaitForSeconds(0.5f);
        cardkind = false;
        Instantiate(card,gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        cardkind = true;
        //Hit();
        Instantiate(card,gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        //Hit();
        Instantiate(card,gameObject.transform.position, gameObject.transform.rotation);
        inplay = true;
    }

    public void cut(){
        Debug.Log("CUT!");
        inplay = false;
    }

    public void Shuffle(){
        spot = 0;
        deck = getUniqueRandomArray(1,52,51);

    }

    public void Continue(){
        Cards = GameObject.FindGameObjectsWithTag("Card");
        flex = totalcardsdealt();
        dealercardsdealt = 0;
        playercardsdealt = 0;
        hworth = 0;
        dworth = 0;
        text.UpdateHandTotal(hworth);
        text.UpdateDealerHandTotal(dworth);
        for (int x = 0; x<flex;x++){
            Destroy(Cards[x]);
        }
        //StartCoroutine(GAMING());
        inplay = false;
    }

    public int totalcardsdealt(){
        return playercardsdealt+dealercardsdealt;
    }


}
