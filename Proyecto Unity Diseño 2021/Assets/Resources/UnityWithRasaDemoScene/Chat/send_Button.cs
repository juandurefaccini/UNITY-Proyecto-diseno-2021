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
        //Debug.Log("hola");
        string message = networkManager.botUI.input.text;
        
        
        
        networkManager.botUI.input.text = "";
        networkManager.botUI.UpdateDisplay("user", message, "text");
        // networkManager.sendMessageToRasa().... etc Hay que conseguir los gameobjects que pide el metodo ese y despues sacar las dos lineas anteriores
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
