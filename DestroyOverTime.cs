using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeToDestroy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy-=Time.deltaTime;
        if(timeToDestroy<=0){
          Destroy(gameObject);
        }
    }
}
