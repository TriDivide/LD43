using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerModel {

    private static PlayerModel _instance;

    private Player mPlayer;


    public static PlayerModel Instance {
        get {
            if (_instance == null) {
                _instance = new PlayerModel();
            }
            return _instance;
        }
    }

    private PlayerModel() {

    }

    public void CreatePlayer(String name, Player.ClassType classType) {
        var player = new Player();

        player.name = name;
        player.playerClass = classType;

        switch(classType) {
            case Player.ClassType.Fighter:
                player.attackStat = player.attackStat * 2;
                player.defenceStat = player.defenceStat / 2;
                break;
            case Player.ClassType.Defender:
                player.attackStat = player.attackStat / 2;
                player.defenceStat = player.defenceStat * 2;
                break;
        }

        this.mPlayer = player;
    }

    public Player GetPlayer() {
        return mPlayer;
    }

    public void UpdatePlayer(Player player) {
        mPlayer = player;
    }

}
