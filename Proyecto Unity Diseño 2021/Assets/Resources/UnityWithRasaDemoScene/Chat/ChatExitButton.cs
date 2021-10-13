using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatExitButton : MonoBehaviour
{
    public GameObject chatDialogue;
    public Button yourButton;
    public NetworkManager networkManager;


    void TaskOnClick()
    {
        chatDialogue.SetActive(false);
        networkManager.chatManager.ResetDisplay();
    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           TaskOnClick();
        }
    }

}
