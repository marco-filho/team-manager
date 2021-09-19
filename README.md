# Gerenciador de Times  
---
Web API de um gerenciador de times e jogadores feita em ASP.NET 5.  

# Rotas  
---
Abaixo estão exemplos de requisições e respostas.  

## Jogadores  

#### GET  
* **Jogadores**  
Retorna todos os jogadores.  
```
[
  {
    "id": 1,
    "nomeCompleto": "Arthur",
    "idade": 19,
    "timeId": 1
  }, {
    "id": 2,
    "nomeCompleto": "Rebeca",
    "idade": 32,
    "timeId": 1
  }, {
    "id": 3,
    "nomeCompleto": "Sofia",
    "idade": 24,
    "timeId": 3
  }
]
```
* **Jogadores/{id}**  
Retorna um jogador pelo `id = 1`.  
```
{
  "id": 1,
  "nomeCompleto": "Arthur",
  "idade": 19,
  "timeId": 1
}
```
* **Jogadores/TimeId/{timeId}**  
Retorna todos os jogadores pelo `timeId = 1`.  
```
[
  {
    "id": 1,
    "nomeCompleto": "Arthur",
    "idade": 19,
    "timeId": 1
  }, {
    "id": 2,
    "nomeCompleto": "Rebeca",
    "idade": 32,
    "timeId": 1
  }
]
```
* **Jogadores/Idade?min=18&max=25**  
Retorna todos os jogadores pelo intervalo de idade `min = 18` - `max = 25`.  
```
[
  {
    "id": 1,
    "nomeCompleto": "Arthur",
    "idade": 19,
    "timeId": 1
  }, {
    "id": 3,
    "nomeCompleto": "Sofia",
    "idade": 24,
    "timeId": 3
  }
]
```

#### POST  
* **Jogadores**  
Cria um registro. Os campos `nomeCompleto`, `idade` e `timeId` são obrigatórios.  
```
{
  "nomeCompleto": "Arthur",
  "idade": 19,
  "timeId": 1
}
```

#### PUT  
* **Jogadores/{id}**  
Atualiza um registro pelo `id`. Os campos `nomeCompleto`, `idade` e `timeId` são obrigatórios.  
```
{
  "nomeCompleto": "Arthur",
  "idade": 19,
  "timeId": 1
}
```

#### DELETE  
* **Jogadores/{id}**  
Exclui um registro pelo `id`.  


## Times  

#### GET  
* **Times**  
Retorna todos os times.  
```
[
  {
    "id": 1,
    "nome": "Timasso",
    "dataInclusao": "17/12/2020 15:39"
  }, {
    "id": 2,
    "nome": "Timao",
    "dataInclusao": "21/02/2021 20:28"
  }, {
    "id": 3,
    "nome": "Timinho",
    "dataInclusao": "11/06/2021 09:51"
  },
]
```
* **Times/{id}**  
Retorna um time pelo `id = 1` com seus respectivos jogadores cadastrados.  
```
{
    "id": 1,
    "nome": "Timasso",
    "dataInclusao": "17/12/2020 15:39",
    "jogadores": [
      {
        "id": 1,
        "nomeCompleto": "Arthur",
        "idade": 19,
        "timeId": 1
      }, {
        "id": 2,
        "nomeCompleto": "Rebeca",
        "idade": 29,
        "timeId": 1
      }
    ],
    "mediaDasIdades": 24
}
```
* **Times/listar**  
Retorna todos os times com seus respectivos jogadores cadastrados.  
```
[
  {
    "id": 1,
    "nome": "Timasso",
    "dataInclusao": "17/12/2020 15:39",
    "jogadores": [
      {
        "id": 1,
        "nomeCompleto": "Arthur",
        "idade": 19,
        "timeId": 1
      }, {
        "id": 2,
        "nomeCompleto": "Rebeca",
        "idade": 32,
        "timeId": 1
      }
    ],
    "mediaDasIdades": 25.5
  },
  {
    "id": 2,
    "nome": "Timao",
    "dataInclusao": "21/02/2021 20:28",
    "jogadores": []
  },
    "id": 3,
    "nome": "Timinho",
    "dataInclusao": "11/06/2021 09:51",
    "jogadores": [
      {
        "id": 3,
        "nomeCompleto": "Sofia",
        "idade": 24,
        "timeId": 3
      }
    ],
    "mediaDasIdades": 24
  },
]
```

#### POST  
* **Times**  
Cria um registro. O campo `nome` é obrigatório.  
```
{
  "nome": "Timasso"
}
```

#### PUT  
* **Times/{id}**  
Atualiza um registro pelo `id`. O campo `nome` é obrigatório.  
```
{
  "nome": "Timasso"
}
```

#### DELETE  
* **Times/{id}**  
Exclui um registro pelo `id`.  
