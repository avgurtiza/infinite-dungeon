using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
	[SerializeField]
	public TextAsset dialogFile;

  private Dialog dialog;

  private GameObject dialogCanvas;

  private Text conversationText;

  private Speech currentConversation;

  private GameObject elf;

  void Awake() {
    elf = GameObject.Find("Elf");
    dialog = JsonUtility.FromJson<Dialog>(dialogFile.text);    
    initializeDialog();
  }

  void Start()
  {
  }

  private void initializeDialog() {
    GameObject canvas = GameObject.Find("DialogCanvas");
    GameObject canvasText = new GameObject("CanvasText");

    canvasText.transform.SetParent(canvas.transform, false);
    conversationText = canvasText.AddComponent<Text>();

    Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

    conversationText.font = ArialFont;
    
    RectTransform textTransform = canvasText.GetComponent<RectTransform>();

    textTransform.sizeDelta = new Vector2 (400f, 200f);
    textTransform.anchoredPosition = new Vector3(20f, -80f,0f);

  }

  public void beginConversation(string speechIndex) {
    Speech speech = findIndex(speechIndex);

    if(speech.text != null) {
      speakNPC(speech);

      while(speech.next != null) {
        speech = findIndex(speech.next); 
        if(speech.text != null) {
          speakNPC(speech);
        }
      }
    }
  }


  // TODO re-evaluate. Does this really need to be public?
  public void clearConversation() {
    StartCoroutine(waitAndClear(3));
  }

  private IEnumerator waitAndClear(int seconds = 3)
  {
    yield return new WaitForSecondsRealtime(seconds);
    conversationText.text = "";

    // TODO move this to an event
    elf.GetComponent<ElfMovement>().unPause();
  }

  public void setPCResponse(string response) {
    ReplyOption option = findOption(response, currentConversation);
    
    Speech speech = findIndex(option.next);
    
    speakNPC(speech);
  }

  private void speakNPC(Speech conversation) {
    currentConversation = conversation;

    conversationText.text += conversation.text + "\n\n";

    if(conversation.exit) {
      clearConversation();
      return;
    } 

    if(conversation.replyOptions != null) {
      showPCReplyOptions(conversation.replyOptions);
    }
  }

  private void showPCReplyOptions(ReplyOption[] options) {
    foreach(ReplyOption option in options) {
      conversationText.text += option.text + "\n";
    }

    conversationText.text += "\n";
  }

  private ReplyOption findOption(string indexName, Speech speech) {
    ReplyOption[] options = speech.replyOptions;
    
    foreach (ReplyOption option in options) {

      if(option.index == indexName) {
        return option;
      }
    }

    return new ReplyOption();
  }

  private Speech findIndex(string indexName)  {
    foreach(Speech speech in dialog.speech) {
      if(speech.index == indexName) {
        return speech;
      }
    }

    return new Speech();
  }

  void Update()
  {
      
  }
}
