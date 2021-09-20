# This files contains your custom actions which can be used to run
# custom Python code.
#
# See this guide on how to implement these action:
# https://rasa.com/docs/rasa/custom-actions


# This is a simple example for a custom action which utters "Hello World!"

from typing import Any, Text, Dict, List

from rasa_sdk import Action, Tracker
from rasa_sdk.executor import CollectingDispatcher
from rasa_sdk.events import SlotSet
import json


# class ActionHelloWorld(Action):

#     def name(self) -> Text:
#         return "action_hello_world"

#     def run(self, dispatcher: CollectingDispatcher,
#             tracker: Tracker,
#             domain: Dict[Text, Any]) -> List[Dict[Text, Any]]:

#         dispatcher.utter_message(text="Hello World!")

#         return []

# persona = 'developer1'

# class AccionRespuesta(Action):
#     """Esta funcion se encarga de agregarle a la respusta el identificador de la animacion 1
#     para luego ser utilizada por Unity"""

#     def name(self) -> Text:
#         return "accion_respuesta"

#     def run(self, dispatcher: CollectingDispatcher,
#         tracker: Tracker,
#         domain: Dict[Text, Any]) -> List[Dict[Text, Any]]:
         
#         ultimo_intent =  tracker.latest_message['intent'].get('name')

#         jsonfile = open("./developers/" + persona + ".json", "r")
#         jsondata = jsonfile.read()
#         obj = json.loads(jsondata)

#         accion_a_responder = obj[ultimo_intent]['accion'] + "=" + obj[ultimo_intent]['rtas'][0]       

#         print(accion_a_responder)

#         dispatcher.utter_message(text=accion_a_responder)

#         return []