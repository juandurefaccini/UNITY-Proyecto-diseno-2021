using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendButton : MonoBehaviour
{
    public NetworkManager networkManager;
    public Button yourButton;


    void TaskOnClick()
    {
        if (!System.String.IsNullOrEmpty(networkManager.chatManager.input.text))
        {
            string message = networkManager.chatManager.input.text;
            networkManager.chatManager.input.text = "";
            GameObject receiver = networkManager.chatManager.last_receiver;
            networkManager.SendMessageToRasa(receiver, message);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        //Detect when the Return key is pressed down NO FUNCIONA
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TaskOnClick();
        }
    }
}
