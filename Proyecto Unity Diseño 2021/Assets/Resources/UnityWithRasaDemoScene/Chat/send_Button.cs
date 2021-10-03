using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class send_Button : MonoBehaviour
{
    public NetworkManager networkManager;
    public Button yourButton;


    void TaskOnClick()
    {
        string message = networkManager.botUI.input.text;
        //networkManager.botUI.UpdateDisplay("user", message, "text");
        networkManager.botUI.input.text = "";
        GameObject receiver = networkManager.botUI.last_receiver;
        networkManager.SendMessageToRasa(receiver, message);
        // networkManager.sendMessageToRasa().... etc Hay que conseguir los gameobjects que pide el metodo ese y despues sacar las tres lineas anteriores
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
        
    }
}
