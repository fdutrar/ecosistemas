Desenvolva um projeto em .NET Core MVC para “consumir” a nossa API seguindo os passos a seguir:

1. Receba o token de acesso pelo metodo GetToken()
2. Receba os dados de um paciente pelo metodo GetPaciente()
3. Edite e envie no formato Json os campos [usu_nome], [email] e [telefone]

Endereço da API : https://dadosbi.sistemasdesaude.com.br/EcoVacina2

Passo 1:

GET
api/Desafio/GetToken

Este metodo é utilizado para receber um novo token que será usado para fazer as requisições posteriores, lembre-se de incluir o token no seu “header”.
Os passos subsequentes estarão nas mensagens de retorno.
Utiliza autorização: Não.
Content Type: application/json
Token tipo: Bearer
Token expiração: 30 minutos.
Objetos de retorno: mensagem, proximaEtapa, statusCode, data


Passo 2:

GET
api/Desafio/GetPaciente

Este metodo é utilizado para receber os dados de um determinado paciente
Utiliza autorização: Sim.
Content type: application/json
Objetos de retorno: mensagem, proximaEtapa, statusCode, data


Passo 3:

POST
api/Desafio/UpdatePaciente

Este método é utilizado para enviar os dados de um determinado paciente.
Os campos para envio são: usu_nome, email, telefone.
Utiliza autorização: Sim
Content Type: application/json
Objetos de retorno: mensagem, statusCode
