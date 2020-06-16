using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] saveLines;
    private DialogueManager dMan;
    public GameObject bookFace;
    void Start()
    {
        if(dMan==null)
          dMan=FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other){
      if(other.name=="Player" && Input.GetKeyDown(KeyCode.Space)){
        // saved
        dMan.setFaceObject(bookFace);
        dMan.dialogLines=saveLines;
        dMan.currentLine=0;
        dMan.ShowDialogue();

        FindObjectOfType<PlayerHealthManager>().playerCurrentHealth=FindObjectOfType<PlayerHealthManager>().playerMaxHealth;

        FindObjectOfType<PlayerStats>().SavePlayer();
        FindObjectOfType<EnemyStats>().SaveEnemy();

      }
    }
}
