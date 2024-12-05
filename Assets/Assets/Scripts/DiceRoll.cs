using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] Sprite[] numberSprite;
    [SerializeField] SpriteRenderer numberSpriteHolder;
    [SerializeField] SpriteRenderer diceRollAnimation;
    [SerializeField] int numberGot;

    Coroutine generateRandomDiceNumber;

    public Players players;
    
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        generateRandomDiceNumber = StartCoroutine(diceRoll());
    }

    IEnumerator diceRoll()
    { 

        yield return new WaitForEndOfFrame();

        if(GameManager.gm.canRollDice)
        {
            GameManager.gm.canRollDice = false;

            numberSpriteHolder.gameObject.SetActive(false);
            diceRollAnimation.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            numberGot = Random.Range(0, 6);
            numberSpriteHolder.sprite = numberSprite[numberGot];
            numberGot++;
            GameManager.gm.numberOfStepsToMove = numberGot;
            GameManager.gm.diceRoll = this;


            numberSpriteHolder.gameObject.SetActive(true);
            diceRollAnimation.gameObject.SetActive(false);

            if(GameManager.gm.numberOfStepsToMove!=6 && playersOut()==0)
            {
                yield return new WaitForSeconds(1f);
                GameManager.gm.diceTransfer=true;
                GameManager.gm.DiceRollTransfer();
            }
            
            if (generateRandomDiceNumber != null)
            {
                StopCoroutine(diceRoll());
            }
        }

    }

    public int playersOut()
    {
        if(GameManager.gm.diceRoll == GameManager.gm.diceRollList[0]) 
        {
            return GameManager.gm.bluePlayerOut;
        }
        else if (GameManager.gm.diceRoll == GameManager.gm.diceRollList[1])
        {
            return GameManager.gm.yellowPlayerOut;
        }
        else if (GameManager.gm.diceRoll == GameManager.gm.diceRollList[2])
        {
            return GameManager.gm.redPlayerOut;
        }
        
        else 
        {
            return GameManager.gm.greenPlayerOut;
        }
    }
}
