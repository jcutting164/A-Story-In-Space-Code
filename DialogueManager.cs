using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dBox;
    public GameObject wBox;
    public GameObject dBox_Face;
    public GameObject wBox_Face;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

    private PlayerController thePlayer;
    private bool check;

    private string currentText;
    private int currentChar;
    public AudioSource blip;

    public GameObject face;
    private int skip;
    void Start()
    {
      thePlayer = FindObjectOfType<PlayerController>();
      if(thePlayer!=null)
        thePlayer.canMove=true;
      skip=0;
    }

    // Update is called once per frame
    void Update()
    {
      if(dialogActive){
        if(dialogActive && Input.GetKeyUp(KeyCode.Space)){
            //dBox.SetActive(false);
            //dialogActive=false;
            if(!check){
              currentLine++;
              currentChar=0;
              currentText="";
            }
            else
              check=false;
        }
        // TEMPORARY FOR TEST

        if(currentLine>=dialogLines.Length){
          face.SetActive(false);
          wBox.SetActive(false);

          dBox.SetActive(false);
          wBox_Face.SetActive(false);

          dBox_Face.SetActive(false);
          dialogActive=false;

          currentLine=0;
          if(thePlayer!=null)
            thePlayer.canMove=true;

        }
        if(dialogActive && currentChar!=dialogLines[currentLine].Length){
          currentText+=dialogLines[currentLine][currentChar];
          if((dialogLines[currentLine][currentChar].CompareTo(' '))!=0 && skip!=2){
            blip.Play();
            Debug.Log("blip");
            skip++;
          }else if(skip==2)
            skip=0;
          currentChar++;

        }

        if(currentChar!=dialogLines[currentLine].Length){
          check=true;
        }else
          check=false;
        dText.text=currentText;
      }
    }


    public void ShowBox(string dialogue){

      dialogActive=true;
      face.SetActive(true);

      wBox.SetActive(true);

      dBox.SetActive(true);

      wBox_Face.SetActive(true);

      dBox_Face.SetActive(true);
      currentText="";
      dText.text=currentText;
      currentChar=0;
      //dText.text=dialogue;
    }
    public void ShowDialogue(){
      face.SetActive(true);

      dialogActive=true;
      wBox.SetActive(true);
      dBox.SetActive(true);
      wBox_Face.SetActive(true);

      dBox_Face.SetActive(true);
      if(thePlayer!=null)
        thePlayer.canMove=false;
    // MAKE SURE THIS CHANGE DOES NOT RUIN CODE...
      check=true;

    }
    public void ShowDialogue(GameObject imgFace){
      if(imgFace.GetComponent<Image>()!=null)
        face.GetComponent<Image>().sprite=imgFace.GetComponent<Image>().sprite;
      Debug.Log("Happens");
      face.gameObject.SetActive(true);
      Debug.Log(face.gameObject.activeSelf);


      dialogActive=true;
      wBox.SetActive(true);
      dBox.SetActive(true);
      wBox_Face.SetActive(true);

      dBox_Face.SetActive(true);
      if(thePlayer!=null)
        thePlayer.canMove=false;
    // MAKE SURE THIS CHANGE DOES NOT RUIN CODE...
      check=true;

    }

    public void ShowQuestDialogue(){
      dialogActive=true;
      face.SetActive(false);

      wBox.SetActive(true);
      dBox.SetActive(true);
      wBox_Face.SetActive(true);

      dBox_Face.SetActive(true);
      if(thePlayer!=null)
        thePlayer.canMove=false;

    }

    public bool isActive(){
      return (wBox.activeSelf && dBox.activeSelf);
    }

    public void setFaceObject(GameObject newFace){
      face.GetComponent<Image>().sprite=newFace.GetComponent<Image>().sprite;
    }
}
