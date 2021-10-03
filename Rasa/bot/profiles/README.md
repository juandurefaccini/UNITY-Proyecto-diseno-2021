# Personalidades

Compuesto por dos partes: BIG FIVE Y Emotions

## BIG FIVE

Van a ser datos obtenidos a partir del test BIG FIVE, por lo que los datos actuales son aleatorios. Solamente son usados para permitir el funcionamiento global del proyecto.


## PARAMETROS DEL BIG FIVE
1-Apertura a la experiencia ( inventivo / curioso vs. consistente / cauteloso ) 

2-Escrupulosidad ( eficiente / organizado vs. extravagante / descuidado ) 

3-Extroversión ( sociable / enérgico vs. solitario / reservado ) 

4-Amabilidad ( amigable / compasivo vs. desafiante / insensible ) 

5-Neuroticismo ( susceptible / nervioso vs. resistente / seguro) 

## Emotions:

Compuestas por: 1 Alegría.
                2 Enfado.
                3 Miedo.
                4 Tristeza.
                5 Sorpresa.
                6 Confianza.

Cada una de estas emociones tiene asociado un flotante. Este mismo es utilizado para multiplicar el vector BIG FIVE y asi generar el vector de emociones a enviar a Unity.
### Flotante:
Este flotante varia entre 0.5 y 1.5. Tome los valores mas bajos para las emociones "malas" y los valores mas altos para las emociones "buenas".
#
#



# FUNCIONAMIENTO

1. Desde UNITY se obtiene el mensaje enviado y el destinatario de ese mensaje. 

2. El destinatario se busca en el archivo personalities.json

3. Se obtiene el vector BIG FIVE del destinatario.

4. Con el mensaje enviado se busca el INTENT en el archivo index.json 

5. Se usa dicho INTENT para ver que valor del vector Emotions representa 

6. Una vez obtenido el valor del vector Emotions se multiplica por el vector BIG FIVE para obtener el vector de emociones a enviar a UNITY.

## IMPORTANTE

En caso de que el valor a multiplicar resulte en que alguno de los atributos del arreglo a enviar sea mayor a 1, se redondeara para que este quede en 1 como maximo.

### Ejemplo:

     "BIGFIVE":["0,5", "0,3", "0,7","0.6","0,1"],
     "Multiplicador" :"1.5"
     "RESULTADO" : ["0,75", "0,45", "1.05","0.9","0,15"]
     "Lo que se envia a UNITY" : ["0,75", "0,45", "1","0.9","0,15"]



