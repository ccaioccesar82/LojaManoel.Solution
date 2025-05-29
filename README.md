Passos para rodar a API no computador:

Requisitos:
Ter o repositório clonado para a sua máquina local.

Seu Docker já estar ligado na sua máquina.

Passos :
Abra a solução no seu Visual Studio.
Vá no "docker-compose", clique com o botão direito e selecione "compose up" para que as imagens subam


![dockerup](https://github.com/user-attachments/assets/f7317521-82f2-47db-903b-ef847f8c89c8)

Após as imagens subirem, o botão de rodar o sistema pelo docker compose será habilitado no topo do visual studio. É só selecionar ele e depois rodar o sistema pelo docker compose.
![escolher docker compose](https://github.com/user-attachments/assets/082c2898-e9fb-403e-b01f-2f85abfa2c03)
![clicar em docker compose](https://github.com/user-attachments/assets/d8d860d7-4a56-4f1f-ba79-c653a780d0e6)

Após rodar, o Swagger deverá abrir na porta :8080 com os dois endpoints de serviço:


/api/create/pedido - Cria um pedido com uma lista de itens da sua escolha(obs: comprimento, largura e altura só aceitam números inteiros.)


/caixa-produto - devolve todos os pedidos, dizendo quantas caixas serão usadas no pedido e quais produtos vão em cada caixa

![swagger](https://github.com/user-attachments/assets/0cd0a061-aa00-4e5a-b7e8-f38501f33e51)




Obs: Após o docker com as configurações subirem, caso você feche a aplicação e abra de novo, e o sistema dê algum erro do tipo "o database 'lojamanoel' já existe", é porque ele está tentando aplicar as migrações novamente. A única coisa que você precisa fazer, é ir no arquivo de docker-compose e trocar o "APPLY_MIGRATIONS=true" para "APPLY_MIGRATIONS=false".
