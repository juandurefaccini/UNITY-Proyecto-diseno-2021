using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit_Button : MonoBehaviour
{
    public GameObject chatDialogue;
    public Button yourButton;
    public PlayerController activePlayer;
    public NetworkManager networkManager;


    void TaskOnClick()
    {
        chatDialogue.SetActive(false);
        activePlayer.triggerInteract(false);
        networkManager.botUI.ResetDisplay();
    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

}
