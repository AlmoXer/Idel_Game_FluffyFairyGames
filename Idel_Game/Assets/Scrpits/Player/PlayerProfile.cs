using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerProfile : MonoBehaviour
{

    public static Player player;
    public static PlayerProfile playerProfile;
    public PlayerContainer playerContainer;

    private bool firstTick = true;

    [SerializeField]
    public static Money[] farmIncomes;

    public static Money incomeOffline;
    private Money money;
    // Use this for initialization
    void Awake()
    {
        if (playerProfile)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            playerProfile = this;
        }

        playerContainer = new PlayerContainer();
        if (null != playerContainer.Load(Path.Combine(Application.dataPath, "Saves/players.xml")))
            playerContainer = playerContainer.Load(Path.Combine(Application.dataPath, "Saves/players.xml"));


            if (playerContainer.Players.Count != 0)
            player = playerContainer.Players[0];

        if (player == null)
        {
            createPlayer("ME");
            for (int i = 0; i < player.farmIDs.Length; i++)
            {
                player.farmIDs[i] = - 1;
            }
            for (int i = 0; i < player.farmLevels.Length; i++)
            {
                player.farmLevels[i] = 0;
            }
            saveFile();
        }

    }

    public void Update()
    {
        if(firstTick)
        {
            for (int i = 0; i < FarmBuilder.instance.farms.Length; i++)
            {
                FarmBuilder.instance.farms[i].ID = player.farmIDs[i];
                FarmBuilder.instance.farms[i].level = player.farmLevels[i];
            }
            firstTick = false;
            return;
        }

        //Income Summe wird auf 0 gesetz
        for (int i = 0; i < money.money.Length; i++)       
            money.money[i] = 0;
        //Income Summe wird Berechnet
        for (int i = 0; i < farmIncomes.Length; i++)        
            for (int j = 0; j < money.money.Length; j++)
                money.money[j] += farmIncomes[i].money[j];
        //Income Summe wird auf den Spieler übertragen
        for (int i = 0; i < money.money.Length; i++)              
            player.incomeOnline[i] = money.money[i];
        //Income Summe Offline wird auf den Spieler übertragen
        for (int i = 0; i < money.money.Length; i++)
        {
            player.incomeOffline[i] = money.money[i] / 10;
            incomeOffline.money[i] = money.money[i] / 10;
        }
            
    }

    public void createPlayer(string name)
    {
        Player newPlayer = new Player();
        newPlayer.playerName = name;
        playerContainer.Players.Add(newPlayer);
        player = newPlayer;
    }

    public void saveFile()
    {
        player.offlineTime = System.DateTime.Now.ToBinary();
        playerContainer.Save(Path.Combine(Application.dataPath, "Saves/players.xml"));
    }

    private void OnApplicationQuit()
    {
        saveFile();
    }
}
