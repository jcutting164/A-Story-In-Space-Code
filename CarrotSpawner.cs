using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{
    public GameObject carrot;
    public float cooldown;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter=0;

    }

    // Update is called once per frame
    void Update()
    {
        counter+=Time.deltaTime;
        if(counter>=cooldown && FindObjectOfType<InventoryManager>().FindAll("Carrot")<50){
          Instantiate(carrot, new Vector3(Random.Range(-11f, 26f), Random.Range(-8f,12f),0f), Quaternion.identity);
          counter=0;
        }
    }
}
