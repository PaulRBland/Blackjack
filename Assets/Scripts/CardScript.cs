using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardScript : MonoBehaviour
{
    private SpriteRenderer rend;
    [SerializeField]
    //private Sprite faceSprite, backSprite;
    private Sprite faceSprite, aceclub,twoclub,threeclub,fourclub,fiveclub,sixclub,sevclub,eigclub,ninclub,tenclub,jackclub,queenclub,kingclub,
    acediamond,twodiamond,threediamond,fourdiamond,fivediamond,sixdiamond,sevdiamond,eigdiamond,nindiamond,tendiamond,jackdiamond,queendiamond,kingdiamond,
    acespad,twospad,threespad,fourspad,fivespad,sixspad,sevspad,eigspad,ninspad,tenspad,jackspad,queenspad,kingspad,
    aceheart,twoheart,threeheart,fourheart,fiveheart,sixheart,sevheart,eigheart,ninheart,tenheart,jackheart,queenheart,kingheart,emptysprite;
    private bool coroutineAllowed, faceUp;
    int cardnum,ccolor;
    Color orig;
    int playercardsdealt,dealercardsdealt;
    // Start is called before the first frame update
    WorldControl deck;
    Vector3 startloc, originloc;
    Vector3 destloc,dealerdest;
    bool flipped = false;
    float pdx,pdy, ddx, ddy;
    public float speed = 0.0000000000000005f;
    bool cardkind;

    void Start()
    {
        deck = GameObject.FindGameObjectWithTag("World").GetComponent<WorldControl>();
        rend = GetComponent<SpriteRenderer>();
        startloc = transform.position;
        originloc = transform.position;
        //rend.sprite = backSprite;
        ccolor = deck.GetCardColorNum();
        orig = this.GetComponent<Renderer>().material.color;
        if (ccolor == 1){
            this.GetComponent<Renderer>().material.color = Color.red;
            
        }
        if (ccolor == 2){
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (ccolor == 3){
            this.GetComponent<Renderer>().material.color = Color.green;
        }
        if (ccolor == 4){
            this.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
        pdy = -3;
        ddy = 2;
        coroutineAllowed = true;
        faceUp = false;
        playercardsdealt = deck.getPlayerCardsDealt();
        dealercardsdealt = deck.getDealerCardsDealt();
        pdx = -7+playercardsdealt;
        ddx = -7+dealercardsdealt;
        cardkind = deck.getDest();
        //Debug.Log("Card Kind " + cardkind);
        if (cardkind == true){destloc = new Vector3 (pdx,pdy,0f);}
        if (cardkind == false) {destloc = new Vector3 (ddx,ddy,0f);}
        cardnum = deck.getCardNum();

        switch (cardnum) {
            case 1:
                emptysprite = aceclub;
                break;
            case 2:
                emptysprite = twoclub;
                break;
            case 3:
                emptysprite = threeclub;
                break;
            case 4:
                emptysprite = fourclub;
                break;
            case 5:
                emptysprite = fiveclub;
                break;
            case 6:
                emptysprite = sixclub;
                break;
            case 7:
                emptysprite = sevclub;
                break;
            case 8:
                emptysprite = eigclub;
                break;
            case 9:
                emptysprite = ninclub;
                break;
            case 10:
                emptysprite = tenclub;
                break;
            case 11:
                emptysprite = acediamond;
                break;
            case 12:
                emptysprite = twodiamond;
                break;
            case 13:
                emptysprite = threediamond;
                break;
            case 14:
                emptysprite = fourdiamond;
                break;
            case 15:
                emptysprite = fivediamond;
                break;
            case 16:
                emptysprite = sixdiamond;
                break;
            case 17:
                emptysprite = sevdiamond;
                break;
            case 18:
                emptysprite = eigdiamond;
                break;
            case 19:
                emptysprite = nindiamond;
                break;
            case 20:
                emptysprite = tendiamond;
                break;
            case 21:
                emptysprite = acespad;
                break;
            case 22:
                emptysprite = twospad;
                break;
            case 23:
                emptysprite = threespad;
                break;
            case 24:
                emptysprite = fourspad;
                break;
            case 25:
                emptysprite = fivespad;
                break;
            case 26:
                emptysprite = sixspad;
                break;
            case 27:
                emptysprite = sevspad;
                break;
            case 28:
                emptysprite = eigspad;
                break;
            case 29:
                emptysprite = ninspad;
                break;
            case 30:
                emptysprite = tenspad;
                break;
            case 31:
                emptysprite = aceheart;
                break;
            case 32:
                emptysprite = twoheart;
                break;
            case 33:
                emptysprite = threeheart;
                break;
            case 34:
                emptysprite = fourheart;
                break;
            case 35:
                emptysprite = fiveheart;
                break;
            case 36:
                emptysprite = sixheart;
                break;
            case 37:
                emptysprite = sevheart;
                break;
            case 38:
                emptysprite = eigheart;
                break;
            case 39:
                emptysprite = ninheart;
                break;
            case 40:
                emptysprite = tenheart;
                break;
            case 41:
                emptysprite = jackclub;
                break;
            case 42:
                emptysprite = queenclub;
                break;
            case 43:
                emptysprite = kingclub;
                break;
            case 44:
                emptysprite = jackdiamond;
                break;
            case 45:
                emptysprite = queendiamond;
                break;
            case 46:
                emptysprite = kingdiamond;
                break;
            case 47:
                emptysprite = jackheart;
                break;
            case 48:
                emptysprite = queenheart;
                break;
            case 49:
                emptysprite = kingheart;
                break;
            case 50:
                emptysprite = jackspad;
                break;
            case 51:
                emptysprite = queenspad;
                break;
            case 52:
                emptysprite = kingspad;
                break;

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(startloc, destloc,speed);
        startloc = transform.position;
        if (startloc == destloc && flipped == false && coroutineAllowed){
            //Debug.Log("Arrived?");
            StartCoroutine(RotateCard());
            flipped = true;
        }
    }

    //void OnClick (InputValue value) {
    /*private void OnMouseDown() {
        Debug.Log("Clicked");
        if (coroutineAllowed){
            StartCoroutine(RotateCard());
        }
    } */

    private IEnumerator RotateCard()
    {
        //Debug.Log("Enumerator Thing");
        coroutineAllowed = false;
        
        if (!faceUp)
        {
            //Debug.Log("Faced Not up");
            this.GetComponent<Renderer>().material.color = orig;
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i , 0f);
                if (i == 90f)
                {
                    rend.sprite = emptysprite;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        coroutineAllowed = true;
        faceUp = !faceUp;
        this.GetComponent<Renderer>().material.color = orig;
    }

    public void TheOrder(){
        Destroy(this.gameObject);
    }
}
