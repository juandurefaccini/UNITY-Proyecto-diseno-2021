using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UI_Manager uI_Manager;
    public bool estaInteractuando = false;
    public ChatManager chatManager;


    public void toggleInteraction(bool activate){
        estaInteractuando = activate;
        transform.GetComponent<Movement>().estaInteractuando = activate;
        transform.GetComponent<Movement>().animator.SetFloat("VelX",0);
        transform.GetComponent<Movement>().animator.SetFloat("VelY",0);
        transform.GetComponent<CambioCamara>().estaInteractuando = activate;
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
                StartCoroutine(DoRotationAtTargetDirection(HoveringCharacter.transform));
                uI_Manager.setChatState(true);
                chatManager.last_receiver = HoveringCharacter;
                toggleInteraction(true);
            }
        }
        else if (chatManager.gameObject.activeSelf == false && estaInteractuando){
                toggleInteraction(false);
        }
    }

    GameObject checkHoveringCharacter()
    {
        // ESte metodo revisa si estamos mirando a otra persona
        // Builds a ray from camera point of view to the mouse position
        Ray ray = GetComponent<CambioCamara>().primeraPersona.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit 
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Interactuable"))
            {
                if (hit.distance < 5f)
                {
                    return hit.transform.gameObject;
                }
            }
        }
        return null;
    }

    IEnumerator DoRotationAtTargetDirection(Transform other)
    {
        Quaternion targetRotation = Quaternion.identity;
        do
        {
            Debug.Log("Rotating");
            Vector3 targetDirection = transform.position - other.position;
            targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion nextRotation = Quaternion.RotateTowards(targetRotation,
                    transform.rotation, 5f * Time.deltaTime);
            other.rotation = nextRotation;
            yield return null;

        } while (Quaternion.Angle(transform.rotation, targetRotation) > 0.05f && Vector3.Distance(transform.position, other.position) < 5f);
    }

}
