using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit_Button : MonoBehaviour
{
    public GameObject chatDialogue;
    public Button yourButton;
    public PlayerController activePlayer;


    void TaskOnClick()
    {
        //Debug.Log("hola");
        chatDialogue.SetActive(false);
        activePlayer.triggerInteract(false);
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
