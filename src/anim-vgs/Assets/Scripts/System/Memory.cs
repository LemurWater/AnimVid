//  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
//  ▓  ∞                                                                              ▓
//  ▓    This script requires a file named:               ▓
//  ▓    "🕹️/Assets/StreamingAssets/Memory.sg"    ▓
//  ▓                                                                                  ▓
//  ▓    DataStructure:                                                  ▓
//  ▓    [HIERARCY]                                                          ▓
//  ▓    SettingName = Value                                          ▓
//  ▓                                                  Infinity Ga∞es®   ▓                            ▓
//  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;


public class Memory : MonoBehaviour
{
    public string fileName = "Memory.sg";
    public string filePath;

    [Space(5)]
    [Header("READ DATA")]
    public List<string> memData;

    [Space(10)]
    [Header("SCRIPT REFERENCES")]
    public GameObject  player;
    public Looking sptLooking;
    public Movement sptMovement;



    // Start is called before the first frame update
    void Start()
    {
        sptLooking = player.GetComponent<Looking>();
        sptMovement = player.GetComponent<Movement>();

        LoadSettings();
        ApplySettings();
    }



    public  void LoadSettings(){
        filePath = Application.streamingAssetsPath + "/" + fileName;
        StreamReader sr = new StreamReader(filePath);
        var fileContents = sr.ReadToEnd();
        sr.Close();

        string[] lines = fileContents.Split("\n"[0]);
        foreach (string line in lines){
            memData.Add(line);
        }
    }
    public void SaveSettings(){

    }
    public void ApplySettings(){
        for(int i = 0; i< memData.Count; i++){
            if(memData[i].ToUpper().Contains("Sensitivity".ToUpper())){
                string[] dataArray = memData[i].Split("=");
                float.TryParse(dataArray[1], out float value);
                sptLooking.Sensitivity = value;
            }
        }
    }
}
