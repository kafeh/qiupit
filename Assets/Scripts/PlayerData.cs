using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]  
class PlayerData
{
    public int smallQiupit { get; set; }
    public int kamikazeQiupit { get; set; }
    public int clusterQiupit { get; set; }
    public int cluserQiupit { get; set; }
    public int levelWon { get; set; }

    public PlayerData(int smallQiupit, int kamikazeQiupit, int clusterQiupit, int cluserQiupit, int levelWon)
    {
        this.smallQiupit = smallQiupit;
        this.kamikazeQiupit = kamikazeQiupit;
        this.clusterQiupit = clusterQiupit;
        this.cluserQiupit = cluserQiupit;
        this.levelWon = levelWon;
    }
}
