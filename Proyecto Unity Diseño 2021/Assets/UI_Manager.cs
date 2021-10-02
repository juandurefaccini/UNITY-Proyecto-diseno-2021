using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject interactDialogue;
    public GameObject chatDialogue;

    public void setInteractDialogueState(bool state)
    {
        interactDialogue.SetActive(state);
    }

    public void setChatState(bool state)
    {
        chatDialogue.SetActive(state);
    }
}
