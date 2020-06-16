using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyData
{
  //public Dictionary<string,bool> map = new Dictionary<string, bool>();
  public string[] activations_Save;

  public EnemyData(EnemyStats stats){
  //  map=stats.map;
    
    activations_Save=stats.activations;
  }

}
