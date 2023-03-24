using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue/New Conversation")]
public class Conversation : ScriptableObject
{
    [SerializeField] public DialogueLine[] allLines;

    public DialogueLine GetLineByIndex(int index){
        return allLines[index];
    }

    public int GetLength(){
        return allLines.Length - 1;
    }

}
