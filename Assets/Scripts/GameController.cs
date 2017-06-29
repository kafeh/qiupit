using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{
    public static GameController control;
    public Text textSmall; //Solo esta acá para cuestiones de prueba
    public int small, kamikaze, cluster, cluser, levelWon; //No puede ser serializedfield, es usado por PlayerData class
    private PlayerData data;
    private BinaryFormatter formatter;
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
        textSmall.text = "Small: " + Convert.ToString(small); //Solo esta acá para cuestiones de prueba
        Load();
    }
    void Update()
    {
        textSmall.text = "Small: " + Convert.ToString(small);
    }
    public void Load() 
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            Debug.Log("Entro a load!");
            formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            data = (PlayerData)formatter.Deserialize(file);
            file.Close();
            small = data.smallQiupit;
            kamikaze = data.kamikazeQiupit;
            cluster = data.clusterQiupit;
            cluser = data.cluserQiupit;
            levelWon = data.levelWon;
        }
    }
    public void Save() 
    {
        formatter = new BinaryFormatter();
        data = new PlayerData(small, kamikaze, cluster, cluser, levelWon);
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
        formatter.Serialize(file, data);
        file.Close();
    }
}
