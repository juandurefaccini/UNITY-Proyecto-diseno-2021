
from typing import Any, Text, Dict, List

from rasa_sdk import Action, Tracker
from rasa_sdk.executor import CollectingDispatcher
from rasa_sdk.events import SlotSet
import json

class ActionVector(Action):
    """Esta accion se encarga de seleccionar la respuesta determinada al intent detectado por rasa, acorde a la persona que interpreta el asistente"""

    def name(self) -> Text:
        return "accion_vector"

    def run(self, dispatcher: CollectingDispatcher,
        tracker: Tracker,
        domain: Dict[Text, Any]) -> List[Dict[Text, Any]]:
         
        ultimo_intent =  tracker.latest_message['intent'].get('name')
  
        emocion = tracker.current_state()['latest_message']['response_selector']['default']['response']['responses'][0]['text'].split('/')[1]

        sender_id = tracker.current_state()['sender_id']

        print("Sender: ", sender_id)
        print("Intent detectado: ", ultimo_intent)
        print("Emocion detectada: ", emocion)

        accion_a_responder = "utter_" + ultimo_intent + "_" + emocion + "_" + sender_id
        
        index = self.get_mood(emocion)
        print("INDEX: ", index)
        vectorResultado = self.calcularVector(sender_id, index)

        print("Vector resultado: ", vectorResultado)
        print("Accion a responder: ", accion_a_responder) 

        dispatcher.utter_message(response=accion_a_responder, vector=vectorResultado)

        return []

    def calcularVector(self, name, mood):

        with open("profiles/personalities.json", "r") as file:
            personality = json.load(file)[name]
        BF = personality["BIGFIVE"]
        multiplicador = personality["Emotions"][mood]     
        for i in range(0, len(BF)):
            BF[i] = float(BF[i]) * float(multiplicador)
            if BF[i] > 1:
                BF[i] = 1
        return str(BF)

    def get_mood(self, intentname): 

        with open("profiles/index.json", "r") as file:
            personality = json.load(file)["EMOTIONS-INDEX"]
        for key, value in personality.items():
            if key == intentname:
                print ("El valor de ", key, "es ", value)
                return value