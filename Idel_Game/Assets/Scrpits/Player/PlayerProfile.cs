﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerProfile : MonoBehaviour
{

    public static Player player;
    public static PlayerProfile playerProfile;
    public PlayerContainer playerContainer;

    
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

        for (int i = 0; i < FarmBuilder.instance.farms.Length; i++)
        {
             FarmBuilder.instance.farms[i].ID = player.farmIDs[i];
            FarmBuilder.instance.farms[i].level = player.farmLevels[i];
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
        playerContainer.Save(Path.Combine(Application.dataPath, "Saves/players.xml"));
    }

    private void OnApplicationQuit()
    {
        saveFile();
    }
}
