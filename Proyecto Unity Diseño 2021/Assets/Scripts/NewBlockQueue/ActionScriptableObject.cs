using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ActionScriptableObject", order = 1)]
public class ActionScriptableObject : ScriptableObject
{
    public string actionName;
    public string layernName;
}