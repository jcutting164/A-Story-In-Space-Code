
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
  public static void SavePlayer(PlayerStats player){
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/Player.data";
    FileStream stream = new FileStream(path, FileMode.Create);

    PlayerData data = new PlayerData(player);

    formatter.Serialize(stream, data);
    stream.Close();
  }

  public static PlayerData LoadPlayer(){
    string path = Application.persistentDataPath + "/Player.data";
    Debug.Log(path);
    if(File.Exists(path)){
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);

      PlayerData data = formatter.Deserialize(stream) as PlayerData;
      stream.Close();


      return data;
    }else{
      Debug.Log("Save file not found in "+path);
      return null;
    }
  }

  public static void SaveEnemy(EnemyStats enemies){
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/Enemies.data";
    FileStream stream = new FileStream(path, FileMode.Create);

    EnemyData data = new EnemyData(enemies);

    formatter.Serialize(stream, data);
    stream.Close();
  }

  public static EnemyData LoadEnemy(){
    string path = Application.persistentDataPath + "/Enemies.data";
    if(File.Exists(path)){
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);

      EnemyData data = formatter.Deserialize(stream) as EnemyData;
      stream.Close();


      return data;
    }else{
      Debug.Log("Save file not found in "+path);
      return null;
    }
  }

  public static void resetAllValues(PlayerStats player, EnemyStats enemies){


  }


}
