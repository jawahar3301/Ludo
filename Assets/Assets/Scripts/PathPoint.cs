using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{

    public PathPointParent pathPointParent;
    public List<Players> playersList = new List<Players>();
    void Start()
    {
        pathPointParent = GetComponentInParent<PathPointParent>();
    }

    public bool AddPlayer(Players players_)
    {
        if(playersList.Count==1)
        {
            string prePlayerName = playersList[0].name;
            string curPlayerName = players_.name;
            curPlayerName = curPlayerName.Substring(0, curPlayerName.Length - 4);

            if(!prePlayerName.Contains(curPlayerName))
            {
                playersList[0].isReady = false;
                reverOnStart(playersList[0]);
                playersList[0].numberStepsAlreadyMoved = 0;
                RemovePlayer(playersList[0]);
                playersList.Add(players_);
                return false;
            }

        }
        addPlayer(players_);
        return true;
    }

    void reverOnStart (Players player_)
    {
        if (player_.name.Contains("Blue")) { GameManager.gm.bluePlayerOut -= 1; }
        else if (player_.name.Contains("Red")) { GameManager.gm.redPlayerOut -= 1; }
        else if (player_.name.Contains("Green")) { GameManager.gm.greenPlayerOut -= 1; }
        else { GameManager.gm.yellowPlayerOut -= 1; }

        player_.transform.position = pathPointParent.basePoint[BasePointPosition(player_.name)].transform.position;
          
    }

    int BasePointPosition(string name)
    {
        for( int i=0; i < pathPointParent.basePoint.Length; i++)
        {
            if(pathPointParent.basePoint[i].name==name)
            {
                return i;
            }

        }
        return -1;


    }
    void addPlayer(Players players_)
    {
        playersList.Add(players_);
        RescaleAndRepositionPlayers();
    }
    public void RemovePlayer(Players players_)
    {
        if(playersList.Contains(players_))
        {
            playersList.Remove(players_);

        }
    }

    public void RescaleAndRepositionPlayers()
    {
        int plscont = playersList.Count;
        bool isOdd = (plscont / 2) == 0 ? false : true;

        int extent = plscont / 2;
        int counter = 0;
        int SpriteLayer = 0;

        if(isOdd)
        {
            for(int i= -extent;i<=extent;i++)
            {
                playersList[counter].transform.localScale = new Vector3(pathPointParent.scale[plscont - 1], pathPointParent.scale[plscont - 1], 1f);
                playersList[counter].transform.position = new Vector3(transform.position.x + (i * pathPointParent.position[plscont - 1]), transform.position.y, 0f);
            }
        }
        else
        {
           for (int i = -extent; i < extent; i++)
             {
               playersList[counter].transform.localScale = new Vector3(pathPointParent.scale[plscont - 1], pathPointParent.scale[plscont - 1], 1f);
               playersList[counter].transform.position = new Vector3(transform.position.x + (i * pathPointParent.position[plscont - 1]), transform.position.y, 0f);
             }
        }
        for(int i=0; i<playersList.Count;i++)
        {
            playersList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = SpriteLayer;
            SpriteLayer++;
        }
    }
}

