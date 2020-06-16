using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private QuestManager theQM;
    public int questNumber;
    public bool startQuest, endQuest;

    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.gameObject.name == "Player"){
        if(!theQM.questCompleted[questNumber]){
          if(startQuest && !theQM.quests[questNumber].gameObject.activeSelf){
            theQM.quests[questNumber].gameObject.SetActive(true);
            theQM.quests[questNumber].StartQuest();
          }

          if(endQuest && theQM.quests[questNumber].gameObject.activeSelf){
            theQM.quests[questNumber].gameObject.SetActive(false);
            theQM.quests[questNumber].EndQuest();
          }

        }
      }
    }
}
