using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue, navButtonText;
    public Image speakerSprite;
    public GameObject dialogueBox;

    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;
    private Coroutine typing;
    // public GameManager _gameManager;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    // void Start(){
    //     _gameManager = GameObject.FindObjectOfType<GameManager>();
    // }

    public static void StartConversation(Conversation convo){
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.navButtonText.text = ">";

        instance.ReadNext();
    }

    public void ReadNext(){
        if (currentIndex > currentConvo.GetLength()){
            // Destroy(dialogueBox);
            dialogueBox.SetActive(false);
            // _gameManager.ResumeGame();
            return;
        }
        
        speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
        
        if (typing == null){
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }
        else{
            instance.StopCoroutine(typing);
            typing = null;
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }
        // dialogue.text = currentConvo.GetLineByIndex(currentIndex).dialogue;
        speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
        currentIndex++;

        if (currentIndex >= currentConvo.GetLength()){
            navButtonText.text = "X";
        }
    }

    private IEnumerator TypeText(string text){
        dialogue.text = "";
        bool complete = false;
        int index = 0;

        while (!complete){
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(0.02f);

            if (index == text.Length){
                complete = true;
            }
        }
        typing = null;
    }
}
