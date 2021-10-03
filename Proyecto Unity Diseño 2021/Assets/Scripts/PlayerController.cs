using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UI_Manager uI_Manager;
    public FirstPersonLook fpl;
    public bool estaInteractuando = false;
    public BotUI bot_UI;

    Camera m_MainCamera;
    //This is the second Camera and is assigned in inspector
    public Camera m_CameraTwo;

    public void triggerInteract(bool applyLock){
        if (applyLock){
            fpl.changelockState(false);
            gameObject.GetComponent<FirstPersonMovement>().enabled = false;
            estaInteractuando = true;
        }
        else{
            fpl.changelockState(true);
            gameObject.GetComponent<FirstPersonMovement>().enabled = true;
            estaInteractuando = false;
        }
    }
    private void FixedUpdate()
    {
        if (!estaInteractuando)
        {
            GameObject HoveringCharacter = checkHoveringCharacter();
            bool isHoveringCharacter = HoveringCharacter != null;
            uI_Manager.setInteractDialogueState(isHoveringCharacter);
            if (Input.GetKeyUp(KeyCode.E) && isHoveringCharacter)
            {
                uI_Manager.setChatState(true);
                triggerInteract(true);
                bot_UI.last_receiver = HoveringCharacter;
            }
            if (!isHoveringCharacter){
                uI_Manager.setInteractDialogueState(false);
            }

            if (Input.GetKeyUp(KeyCode.C))
            {
                m_MainCamera.enabled = !m_MainCamera.enabled;
                m_CameraTwo.enabled = !m_CameraTwo.enabled;
            }
        }
    }

    GameObject checkHoveringCharacter()
    {
        // ESte metodo revisa si estamos mirando a otra persona
        // Builds a ray from camera point of view to the mouse position
        Ray ray = m_CameraTwo.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit 
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Interactuable"))
            {
                if (hit.distance < 3f)
                {
                    return hit.transform.gameObject;
                }
            }
        }
        return null;
    }

    void Start()
    {
         m_MainCamera = Camera.main;
        //This enables Main Camera
        m_MainCamera.enabled = true;
        //Use this to disable secondary Camera
        m_CameraTwo.enabled = false;
    }

}
