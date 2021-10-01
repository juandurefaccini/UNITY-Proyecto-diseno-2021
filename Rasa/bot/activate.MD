# COMANDOS

rasa run -p 5005 --enable-api --cors "*" --debug
rasa run actions --port 5055 --debug 


# COMANDOS QUE SI SIRVEN
rasa run -p 5005

URL: http://localhost:5005/webhooks/rest/webhook

Json ejemplo a enviar at this moment

{
    "message": "Hola",
    "sender": "Camila"
}
