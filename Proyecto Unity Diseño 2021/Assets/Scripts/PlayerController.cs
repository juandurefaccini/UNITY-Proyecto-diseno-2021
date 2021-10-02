using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UI_Manager uI_Manager;

    private void FixedUpdate()
    {
        var isHoveringCharacter = checkHoveringCharacter();
        uI_Manager.setInteractDialogueState(isHoveringCharacter);
        if (Input.GetKeyUp(KeyCode.E) && isHoveringCharacter)
        {
            uI_Manager.setChatState(true);
        }
    }

    bool checkHoveringCharacter()
    {
        // ESte metodo revisa si estamos mirando a otra persona
        // Builds a ray from camera point of view to the mouse position 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit 
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Interactuable"))
            {
                if (hit.distance < 3f)
                {
                    return true;
                }
            }
        }
        return false;
    }

}
