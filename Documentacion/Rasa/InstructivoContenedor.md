# Instructivo para uso del contendor de rasa - FAQ - LINUX

Para mas informacion: https://rasa.com/docs/rasa/docker/building-in-docker/

Antes de comenzar, hay que aclarar algunos comandos puede llegar a ser que deban ser corridos con superusuario (agregando sudo separado antes del comando). Ademas, deben ser ejecutados con el usuario 1000 algunos.

## ¿Como entreno al chatbot?

docker run -u 1000 -v $(pwd):/app rasa/rasa:2.8.6-full train --domain domain.yml --data data --out models

## ¿Como inicio el servidor de acciones?

1era vez - Creo una red en el contenedor 
docker network create my-project 

Cada vez - Inicio el servidor de acciones y queda activo
docker run -d -v $(pwd)/actions:/app/actions --net my-project --name action-server rasa/rasa-sdk:2.8.1

## ¿Como inicio en modo shell?

docker run -it -v $(pwd):/app -p 5005:5005 --net my-project rasa/rasa:2.8.6-full shell

## ¿Como inicio en modo API?

docker run -it -v $(pwd):/app -p 5005:5005 --net my-project rasa/rasa:2.8.6-full run

## ¿Como doy de baja el servidor de acciones?

Listamos los contendores activos con : docker ps
Paramos el contenedor indicado con : docker stop <NAME>

## Cerre el servidor de acciones, lo quise volver a abrir y se rompio todo. Que hago? S.O.S.

docker rm action-server
