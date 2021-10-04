using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public GameObject contentDisplayObject; // gameobject texto donde se muestra toda la convers
    public InputField input; // input field donde el user escribe su mensaje

    public GameObject userBubble; // referencia al prefab de dialogo usuario
    public GameObject botBubble; // referencia al prefab de dialogo bot

    public GameObject last_receiver;


    private const int messagePadding = 15; // espacio entre dialogos
    private int allMessagesHeight = messagePadding; // int para saber donde se hara el prox mensaje

    private bool increaseContentObjectHeight; // bool para ver si hay que aumentar la altura de content object

    public NetworkManager networkManager;

    public void ResetDisplay()
    {
        allMessagesHeight = messagePadding;
        foreach (Transform child in contentDisplayObject.transform)
        {
            Destroy(child.gameObject);
        }

    }

    public void UpdateDisplay(string sender, string message, string messageType)
    {
        //Crear una burbuja de dialogo y agregar componentes
        GameObject chatBubblechild = CreateChatBubble(sender);
        AddChatComponent(chatBubblechild, message, messageType);

        // Ponerle posicion al dialogo
        StartCoroutine(SetChatBubblePosition(chatBubblechild.transform.parent.GetComponent<RectTransform>(), sender));
    }

    private IEnumerator SetChatBubblePosition(RectTransform chatBubblePos, string sender)
    {
        //Esperar al fin del frame para calcular el transform de la UI
        yield return new WaitForEndOfFrame();

        //Conseguir la posicion horizontal del sender
        int HorizontalPos = 0;
        if (sender == "user")
        {
            HorizontalPos = -20;
        }
        else if (sender == "bot")
        {
            HorizontalPos = 20;
        }

        //Poner la posicion vertical de la burbuja de dialogo
        allMessagesHeight += 15 + (int)chatBubblePos.sizeDelta.y;
        chatBubblePos.anchoredPosition3D = new Vector3(HorizontalPos, -allMessagesHeight, 0);
        if (allMessagesHeight > 340)
        {
            //Actualizar la altura de contentDisplayObject (atributo)
            RectTransform contentRect = contentDisplayObject.GetComponent<RectTransform>();
            contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, allMessagesHeight + messagePadding);
            contentDisplayObject.transform.GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 0;
        }
    }

    public IEnumerator RefreshChatBubblePosition()
    {
        //Esperar al fin del frame para calcular el transform de la UI
        yield return new WaitForEndOfFrame();

        // Recargar la posicion de los gameobjects basados en el tamaño

        int localAllMessagesHeight = messagePadding;
        foreach (RectTransform chatBubbleRect in contentDisplayObject.GetComponent<RectTransform>())
        {
            if (chatBubbleRect.sizeDelta.y < 35)
            {
                localAllMessagesHeight += 35 + messagePadding;
            }
            else
            {
                localAllMessagesHeight += (int)chatBubbleRect.sizeDelta.y + messagePadding;
            }
            chatBubbleRect.anchoredPosition3D = new Vector3(chatBubbleRect.anchoredPosition3D.x, -localAllMessagesHeight, 0);
        }

        //Actualizar la variable global de altura de mensaje
        allMessagesHeight = localAllMessagesHeight;
        if (allMessagesHeight > 340)
        {
            //Actualizar altura de contentDisplayObject
            RectTransform contentRect = contentDisplayObject.GetComponent<RectTransform>();
            contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, allMessagesHeight + messagePadding);
            contentDisplayObject.transform.GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 0;

        }
    }

    private GameObject CreateChatBubble(string sender)
    {
        GameObject chat = null;
        if (sender == "user")
        {
            //Crear burbuja de dialogo de prefab y poner su posicion
            chat = Instantiate(userBubble);
            chat.transform.SetParent(contentDisplayObject.transform, false);
        }
        else if (sender == "bot")
        {
            chat = Instantiate(botBubble);
            chat.transform.SetParent(contentDisplayObject.transform, false);
        }

        // agregar fitter de tamaño de content
        ContentSizeFitter chatSize = chat.AddComponent<ContentSizeFitter>();
        chatSize.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        chatSize.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        //Agregar verticallayoutgroup
        VerticalLayoutGroup verticalLayout = chat.AddComponent<VerticalLayoutGroup>();
        if (sender == "user")
        {
            verticalLayout.padding = new RectOffset(10, 20, 5, 5);
        }
        else if (sender == "bot")
        {
            verticalLayout.padding = new RectOffset(20, 10, 5, 5);
        }

        //que no haya overflow horizontal
        LayoutElement layoutElement = chat.AddComponent<LayoutElement>();
        layoutElement.preferredWidth = 250;
        // Devolver gameobject vacio donde se van a agregar los componentes chat
        return chat.transform.GetChild(0).gameObject;
    }

    private void AddChatComponent(GameObject chatBubbleObject, string message, string messageType)
    {
        switch (messageType)
        {
            case "text": // Por ahora SOLO vamos a tener mensajes y no imagenes o botones o attachments
                Text chatMessage = chatBubbleObject.AddComponent<Text>();
                chatMessage.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                chatMessage.fontSize = 18;
                chatMessage.alignment = TextAnchor.MiddleLeft;
                chatMessage.text = message;
                break;
            case "image": // Nuestro NetworkManager no tiene la implementacion de SetImageTextureFromUrl.
                // Image chatImage = chatBubbleObject.AddComponent<Image>();
                // StartCoroutine(networkManager.SetImageTextureFromUrl(message, chatImage));
                break;
            case "attachment":
                break;
            case "buttons":
                break;
            case "elements":
                break;
            case "quick_replies":
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}