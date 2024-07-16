using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Story/New Speaker")]
[System.Serializable]
public class Speaker : ScriptableObject
{
    public int speakerIndex;
    public string speakerName;
    public Color nameColor;
}