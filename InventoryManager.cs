using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update

    public ItemController[] inv;
    public static bool exists;

    public string[] names;
    public string[] descriptions;
    public int healFactors;
    public int attackFactors;
    public int defenseFactors;
    public int specialFactors;
    public bool extras;
    public bool isWeapon;
    public bool isArmor;
    public string activations;

    void Start()
    {

     if(!exists){
        exists=true;
        DontDestroyOnLoad(transform.gameObject);
      }else{
        Destroy(gameObject);
      }




    }

    // Update is called once per frame
    void Update()
    {
      if(name!="Inventory")
        Destroy(gameObject);

    }

    public void addItem(ItemController item){
      ItemController[] temp = inv;
      inv=new ItemController[inv.Length+1];
      for(int i = 0; i<temp.Length; i++){
        inv[i]=temp[i];
      }
      inv[inv.Length-1]=item;
    }

    public void removeItem(int index){
      inv[index]=null;
      for(int i = index; i<inv.Length-1; i++){
        inv[i]=inv[i+1];
      }
      ItemController[] temp = inv;
      inv = new ItemController[inv.Length-1];
      for(int i = 0; i<inv.Length; i++)
        inv[i]=temp[i];

    }
    public bool checkForItem(string itemToFind){
      bool response=false;
      for(int i = 0; i<inv.Length; i++){
        if(inv[i].name==itemToFind){
          response=true;
          break;
        }
      }
      return response;
    }
    public void removeItem(string itemToRemove){
      for(int i = 0; i<inv.Length; i++){
        if(inv[i].name==itemToRemove){
          removeItem(i);
          break;
        }
      }
    }

    public string[] getNames(){
      string[] given = new string[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].name;
      }
      Debug.Log("length: "+given.Length);
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.name;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.name;

      return given;
    }

    public string[] getDescriptions(){
      string[] given = new string[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].description;
      }
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.description;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.description;
      return given;

    }

    public int[] getHealFactors(){
      int[] given = new int[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].healFactor;
      }
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.healFactor;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.healFactor;
      return given;

    }

    public int[] getAttackFactors(){
      int[] given = new int[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].attackFactor;
      }
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.attackFactor;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.attackFactor;
      return given;

    }

    public int[] getDefenseFactors(){
      int[] given = new int[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].defenseFactor;
      }
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.defenseFactor;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.defenseFactor;
      return given;

    }
    public int[] getSpecialFactors(){
      int[] given = new int[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].specialFactor;
      }
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.specialFactor;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.specialFactor;
      return given;

    }

    public bool[] getExtras(){
      bool[] given = new bool[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].extra;
      }
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.extra;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.extra;
      return given;

    }
    public bool[] getIsWeapons(){
      bool[] given = new bool[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].isWeapon;
      }
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.isWeapon;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.isWeapon;
      return given;

    }
    public bool[] getIsArmors(){
      bool[] given = new bool[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].isArmor;
      }
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.isArmor;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.isArmor;
      return given;

    }

    public string[] getActivations(){
      string[] given = new string[inv.Length+2];
      for(int i = 0; i<inv.Length; i++){
        given[i]=inv[i].activation;
      }
      if(FindObjectOfType<PlayerController>().weapon!=null)
        given[given.Length-2]=FindObjectOfType<PlayerController>().weapon.activation;
      if(FindObjectOfType<PlayerController>().armor!=null)
        given[given.Length-1]=FindObjectOfType<PlayerController>().armor.activation;
      return given;

    }
    public int FindAll(string itemToFind){
      int count=0;
      for(int i =0; i<inv.Length; i++)
        if(inv[i].name==itemToFind)
          count++;
      return count;
    }

    public void Reconstruction(string[] names, string[] descriptions, int[] healFactors, int[] attackFactors,int[] defenseFactors, int[] specialFactors, bool[] extras, bool[] isWeapons, bool[] isArmors, string[] activations){
      inv=new ItemController[0];
      for(int i = 0; i<names.Length-2; i++){
        GameObject temp = new GameObject();
        temp.AddComponent<ItemController>();
      //  ItemController temp = temp.gameObject.AddComponent<ItemController>() as ItemController;
        temp.GetComponent<ItemController>().name=names[i];
        temp.GetComponent<ItemController>().description=descriptions[i];
        temp.GetComponent<ItemController>().healFactor=healFactors[i];
        temp.GetComponent<ItemController>().attackFactor=attackFactors[i];
        temp.GetComponent<ItemController>().defenseFactor=defenseFactors[i];
        temp.GetComponent<ItemController>().specialFactor=specialFactors[i];
        temp.GetComponent<ItemController>().extra=extras[i];
        temp.GetComponent<ItemController>().isWeapon=isWeapons[i];
        temp.GetComponent<ItemController>().isArmor=isArmors[i];

        temp.GetComponent<ItemController>().activation=activations[i];

        Instantiate(temp.gameObject, new Vector3(-9999f,-9999f,-9999f), Quaternion.identity);
        Debug.Log("adding an item");
        addItem(temp.GetComponent<ItemController>());
        temp.gameObject.transform.parent=gameObject.transform;
      }
      if(names[names.Length-2]!=null){
        Debug.Log("is def running");
        GameObject temp1 = new GameObject();
        temp1.AddComponent<ItemController>();
      //  ItemController temp1 = temp1.gameObject.AddComponent<ItemController>() as ItemController;
        temp1.GetComponent<ItemController>().name=names[names.Length-2];
        temp1.GetComponent<ItemController>().description=descriptions[names.Length-2];
        temp1.GetComponent<ItemController>().healFactor=healFactors[names.Length-2];
        temp1.GetComponent<ItemController>().attackFactor=attackFactors[names.Length-2];
        temp1.GetComponent<ItemController>().defenseFactor=defenseFactors[names.Length-2];
        temp1.GetComponent<ItemController>().specialFactor=specialFactors[names.Length-2];
        temp1.GetComponent<ItemController>().extra=extras[names.Length-2];
        temp1.GetComponent<ItemController>().isWeapon=isWeapons[names.Length-2];
        temp1.GetComponent<ItemController>().activation=activations[names.Length-2];
        Instantiate(temp1.gameObject, new Vector3(-9999f,-9999f,-9999f), Quaternion.identity);
        if(FindObjectOfType<PlayerController>().weapon==null){
          FindObjectOfType<PlayerController>().setWeapon(temp1.GetComponent<ItemController>());
          Debug.Log("Attack of weapon: "+FindObjectOfType<PlayerController>().weapon.attackFactor);
          temp1.gameObject.transform.parent=FindObjectOfType<PlayerController>().gameObject.transform;
        }


      }

      if(names[names.Length-1]!=null){
        GameObject temp2 = new GameObject();
        temp2.AddComponent<ItemController>();
        //ItemController temp2 = temp2.gameObject.AddComponent<ItemController>() as ItemController;
        temp2.GetComponent<ItemController>().name=names[names.Length-1];
        temp2.GetComponent<ItemController>().description=descriptions[names.Length-1];
        temp2.GetComponent<ItemController>().healFactor=healFactors[names.Length-1];
        temp2.GetComponent<ItemController>().attackFactor=attackFactors[names.Length-1];
        temp2.GetComponent<ItemController>().defenseFactor=defenseFactors[names.Length-1];
        temp2.GetComponent<ItemController>().specialFactor=specialFactors[names.Length-1];
        temp2.GetComponent<ItemController>().extra=extras[names.Length-1];
        temp2.GetComponent<ItemController>().isArmor=isArmors[names.Length-1];
        temp2.GetComponent<ItemController>().activation=activations[names.Length-1];
        Instantiate(temp2.gameObject, new Vector3(-9999f,-9999f,-9999f), Quaternion.identity);
        if(FindObjectOfType<PlayerController>().armor==null){
          FindObjectOfType<PlayerController>().setArmor(temp2.GetComponent<ItemController>());
          temp2.gameObject.transform.parent=FindObjectOfType<PlayerController>().gameObject.transform;

        }

      }


    }








}
