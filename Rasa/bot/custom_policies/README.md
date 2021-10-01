# FUNCIONAMIENTO DE POLITICA

# IDEA PRINCIPAL

La politica se tiene que encargar de generar el JSON respuesta para enviar a la API. De ser necesario se pueden levantar acciones para ello.

Recibe el JSON de la API que contiene el mensaje y el receptor del mismo. Con ello arma el JSON de respuesta (compuesto por mensaje y vector de acciones).

## Todos los cambios de la politica se hacen en el metodo: 

### predict_action_probabilities

De ser necesario se pueden generar otros metodos para el funcionamiento deseado (por ejemplo get_mood) que se usaran dentro de predict_action_probabilities