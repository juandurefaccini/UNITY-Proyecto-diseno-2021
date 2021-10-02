import requests
import json

# run.py se ocupa de la parte de la API

URL = "http://localhost:5005/webhooks/rest_custom/webhook"
        

def send_msg(msg, name, personality):
    data = {"sender": name, "message": msg, "metadata": { "personality": personality} }
    x = requests.post(URL, json = data)
    rta = x.json()[-1] #x.json() retorna una lista, cada elemento de la lista es un Dic
    text = rta["text"]
    
    if x.status_code == 200:
        return text
    else:
        print(x.raw)
        return None
personality = {"Neuroticism": 0, 
        "Extraversion": 0, 
        "Openness": 0, 
        "Agreeableness": 0, 
        "Conscientiousness": 0} #estas prob hacen que los mensajes pasen a ser de formato informal
rta = send_msg("Hola", "Pedro", personality) #Input
print(rta) #print del Output

"""
rta = send_msg("Fui a las reuniones {0}","Scrum",personality)
print(rta)
rta = send_msg("He estado trabajando con las tareas {0} y fui a las reuniones {1}","Scrum",personality)
print(rta)
rta = send_msg("Hola, empezamos con la daily meeting","Developers",personality)
print(rta)
rta = send_msg("Gracias por asistir a la runion, pueden continuar con su trabajo","Developers",personality)
print(rta)
"""
