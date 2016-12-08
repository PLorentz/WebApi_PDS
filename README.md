# Trabalho Final

#### Especialização em Arquitetura de Software Distribuído
#### Plataformas de Produtividade no Desenvolvimento de Software
##### Professor: Marco Aurélio de Souza Mendes
##### Aluno: Pedro H. Lorentz G. Amaral - 68072

##TECNOLOGIA: ASP.NET Web API

##### 1. Descrição da tecnologia

> <p align="justify">O ASP.NET Web API faz parte da família ASP.NET criada sobre o .Net Framework pela Microsoft como uma forma de construir serviços que podem ser facilmente consumidos por diversos clientes. Essa tecnologia utiliza o padrão REST em cima do protocolo HTTP, que tem suporte em praticamente todas as plataformas e dispositivos (pois tudo hoje é feito para ser possível conectar-se à internet). Embora o Windows Communication Foundation (WCF) também dê suporte a serviços RESTful, Web API é o caminho recomendado pela Microsoft para serviços nesse padrão.</p>

> <p align="justify">O ASP.NET Web API foi construído em cima da estrutura criada para o ASP.NET MVC 4, aproveitando dos conceitos e implementações de rotas, controllers e actions. A versão 2 do Web API foi lançada junto com o MVC 5, trazendo rotas por atributos, implementação de CORS (Cross Origin Resource Sharing), suporte a ODATA e melhorias em testabilidade e “self host”, isto é, a capacidade da Web API se hospedar como processo próprio, sem precisar de estar dentro de um servidor web.</p>

> <p align="justify">Recentemente, a criação do .Net Core, uma reescrita reformulada no .Net Framework totalmente de código aberto no GitHub, levou também à criação do ASP.NET Core. O ASP.NET Core é distribuído dividido em vários pacotes NuGet e tem uma nova forma de organizar os arquivos (parecida com a do Node.js) e uma nova forma de realizar as configurações, além de um sistema nativo de injeção de dependências e um novo pipeline http mais leve. Caso seja utilizado junto com o .Net Core, a aplicação possuirá os benefícios do novo framework, como ser multiplataforma e independente de servidor web, que são características que limitavam muito a disseminação e uso por muitos desenvolvedores das tecnologias Microsoft, que antigamente estavam amarradas ao Windows. O ASP.NET Core também pode ser utilizado junto com o .Net Framework, permitindo compatibilidade com as bibliotecas já existentes, e até mesmo um híbrido, possibilitando que uma solução não necessite de ser migrada de uma só vez para o .Net Core.</p>

> <p align="justify">O ASP.NET Core juntou, mais do que nunca, Web API e MVC no universo .Net. Agora as actions das duas tecnologias são implementadas através da herança da mesma classe base Controller (antes existia a classe ApiController para a Web API no framework), utilizando das mesmas configurações de rotas, permitindo que o mesmo controller possa responder com o HTML de uma página (uma view) ou com o json da serialização de um simples objeto.</p>

> <p align="justify">Podendo utilizar de algumas convenções de nomes, o programador consegue facilmente criar métodos que respondem a um verbo (GET, POST, PUT, DELETE, PATCH, etc) em uma rota (template da url), da mesma forma como o protocolo HTTP trabalha com o endereçamento do que fazer com algum recurso. As urls indicam claramente qual recurso o cliente está desejando e os verbos têm semântica definida e amplamente reconhecida de forma que o consumo não só é simples como também é intuitivo. O corpo e o cabeçalho da requisição também podem ser utilizados pelo servidor para entender o que o cliente deseja e como.</p>

> | Método        | Descrição   |
| --------------- |-------------|
| GET | Retorna o valor atual de um objeto ou coleção de objetos. | 
| PUT | Troca o conteúdo do objeto pelo os dados enviados. | 
| DELETE | Exclui o objeto. | 
| POST | Cria um novo objeto com os dados enviados. | 
| HEAD | Retorna os metadados de um objeto que pode ser retornado pelo GET. | 
| PATCH | Aplica uma atualização de parte dos dados de um objeto com base nos dados informados. |

> <p align="justify">Quando a requisição chega, de acordo com as rotas definidas, ela é encaminhada para alguma ação (método) de algum controller. O roteamento é utilizado também para fazer o inverso: descobrir qual é a URL para alguma ação em algum recurso. É comum que parâmetros da requisição sejam extraídos da rota, mas também é possível extrair do restante da url que não casou diretamente com o template, como as query strings.</p>

> <p align="justify">Os parâmetros que um método necessita são desserializados da requisição, mesmo se forem de tipos complexos, de forma automática, bastando que o desenvolvedor indique de onde ele será extraído. Esse processo de Model Binding pode ser customizado, fazendo com que o objeto da requisição seja interpretado de forma diferente e que os métodos já recebam com alguma conversão.</p> 

> <p align="justify">Após o recebimento dos dados do cliente, é executada o passo de Model Validation. A validação dos objetos é feita principalmente por atributos e existem muitos prontos para uso disponibilizados, bastando decorar as propriedades da sua classe, como de campo obrigatório, valores máximos e mínimos, formatos de telefone, e-mail, cartão de crédito ou url e expressões regulares. É possível criar os seus próprios atributos herdando de ValidationAttribute ou alterando seu modelo para implementar a interface IValidatableObject. O programador acessar e retornar os erros da validação e é possível pedir a revalidação do objeto após alterações.</p> 

> <p align="justify">A resposta da Web API respeita os códigos de status definidos pelo HTTP e podem ser acompanhados de algum objeto. O objeto é serializado não sendo necessário definir previamente um serializador ou herdar de classes especificas, permitindo que POCOs (“Plain Old CLR Objects”, objetos de classes simples) possam ser utilizadas. A serialização tenta respeitar o que o cliente informou que aceita no cabeçalho, caso tenha sido informado, se possível. O padrão é a serialização em JSON.</p> 

> | Código de Status |	Significado |
| ------------- | ---------------------------------- |
| **1xx** | **Informacionais** |
| **2xx** | **Sucesso** |
| 200 | OK – Código geral de sucesso |
| 201 | Criado – Novo recurso criado e a localização do recurso também é retornada |
| 202 | Aceito – A requisição foi aceita e o processamento vai acontecer ou ainda não completado |
| 204 | Sem Conteúdo – A requisição foi atendida e não há necessidade de retornar conteúdo |
| **3xx** | **Redirecionamento** |
| 301 | Movido permanentemente – O recurso requisitado for transferido e todas as requisições futuras devem ser feitas para a url retornada |
| 304 | Não modificado – Indica que o recurso não foi modificado desde a última vez que foi obtido (GET), comparando com as condicionais informadas no cabeçalho |
| **4xx** | **Erro do cliente** |
| 400 | Requisição Ruim – A requisição não foi atendida pelo servidor por não estar formatada corretamente, portanto não deve ser resubmetida sem alterações |
| 401 | Não autorizado – Apesar do nome (que talvez fosse melhor como “Não Autenticado”), significa que para atender o que o cliente quer é necessário que ele se autentique ou que a autenticação passada não foi entendida |
| 403 | Proibido – O servidor entendeu a requisição e quem o cliente é, mas se recusou a atender, podendo ser por causa do perfil do usuário ou mesmo por algum outro motivo que não permite acesso naquele momento |
| 404 | Não encontrado – O servidor não encontrou algo que case com o endereço informado |
| 405 | Método não permitido – O método informado não é válido para aquela uri |
| **5xx** | **Erro do servidor** |
| 500 | Erro interno do servidor – Mensagem genérica de erro no servidor, indica que ele encontrou alguma exceção não esperada que impediu de atender a requisição |
| 503 | Serviço indisponível – O servidor está temporariamente sem conseguir atender à requisição |

> Exemplos de chamadas:

> | Requisição | Semântica | Resposta |
| ------------- | ------- | ---------------------------------- |
| POST https://api.contoso.com/produtos<br/>{<br/>    “nome”: “Arroz Xpto”,<br/>    “preco”: 12.3,<br/>    “unidades”: 100<br/>} | Cria o produto <br/> “Arroz Xpto” com <br/> os atributos informados. | Status: 201<br/>Location: “/produtos/10”<br/>{<br/>    “id”: 10,<br/>    “nome”: “Arroz Xpto”,<br/>    “preco”: 12.3,<br/>    “unidades”: 100<br/>} |
| GET https://api.contoso.com/produtos<br/>|Busca todos os produtos. | Status: 200<br/>[<br/>    {<br/>        “id”: 3,<br/>        “nome”: “Macarrão”,<br/>        “preco”: 9.99,<br/>        “unidades”: 51<br/>    },<br/>    {<br/>        “id”: 7,<br/>        “nome”: “Carne de X”,<br/>        “preco”: 49.9,<br/>        “unidades”: 23<br/>    },<br/>    {<br/>        “id”: 10,<br/>        “nome”: “Arroz Xpto”,<br/>        “preco”: 12.3,<br/>        “unidades”: 100<br/>    }<br/>] |
| GET https://api.contoso.com/produtos/10 |<br/>Busca o produto 10. | Status: 200<br/>{<br/>    “id”: 10,<br/>    “nome”: “Arroz Xpto”,<br/>    “preco”: 12.3,<br/>    “unidades”: 100<br/>} |
| GET https://api.contoso.com/produtos/maisVendidos |<br/>Busca os produtos <br/> mais vendidos. | Status: 200<br/>[<br/>    {<br/>        “id”: 3,<br/>        “nome”: “Macarrão”,<br/>        “preco”: 9.99,<br/>        “unidades”: 51<br/>    },<br/>    {<br/>        “id”: 10,<br/>        “nome”: “Arroz Xpto”,<br/>        “preco”: 12.3,<br/>        “unidades”: 100<br/>    }<br/>] |
| GET https://api.contoso.com/produtos?preco=10.5 |<br/>Busca os produtos <br/> com preço 10,50. | Status: 200<br/>[]<br/> |
| GET https://api.contoso.com/lojas/10/vendedores/9  |<br/>Busca o vendedor <br/> 9 da loja 10. | Status: 404 |
| DELETE https://api.contoso.com/produtos/10 | <br/>Exclui o produto 10. | Status: 200<br/>{<br/>    “id”: 10,<br/>    “nome”: “Arroz Xpto”,<br/>    “preco”: 12.3,<br/>    “unidades”: 100<br/>} |
| PUT https://api.contoso.com/produtos/10<br/>{<br/>    “nome”: “Feijão Xpto”,<br/>    “preco”: 22.5,<br/>    “unidades”: 200<br/>} | Troca o produto <br/> 10 pelo produto <br/> informado no corpo <br/> da requisição. | Status: 204 |
| PATCH  https://api.contoso.com/produtos/10<br/>{<br/>    “nome”: “Feijão Asd”<br/>} | Atualiza o nome <br/> do produto 10. | Status: 200<br/>{<br/>    “id”: 10,<br/>    “nome”: “Feijão Asd”,<br/>    “preco”: 22.5,<br/>    “unidades”: 200<br/>} |


