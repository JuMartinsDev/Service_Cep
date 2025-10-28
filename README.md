
# Serviço de CEP - Atividade

Projeto desenvolvido como atividade de Sistemas de Informação na FIAP. Este projeto implementa um serviço completo de CEP, que consome a API do Via CEP e persiste os dados em um banco de dados SQLite.

---

## 📝 Funcionalidades

- Consultar CEP usando a API Via CEP.
- Persistir CEP consultado no banco de dados.
- Listar todos os CEPs salvos.
- Estrutura organizada em camadas: Domain, Repository, Service e Controller.
- Validações de CEP e tratamento de erros.

---

## 📦 Estrutura do Projeto

```

ServicoCepAtividade/
│
├─ Domain/                 # Classes de entidades (Cep, ViaCepResponse)
├─ Repository/             # Interface e implementação do repositório
├─ Service/                # Interface e implementação do serviço
├─ Controllers/            # Controller da API (CepController)
├─ Properties/             # Configurações de inicialização
├─ ServicoCepAtividade.csproj
└─ Program.cs

````

---

## ⚙️ Requisitos

- .NET 9.0 SDK
- Ferramenta para testar API: navegador, Postman ou Insomnia

---

## 🚀 Como rodar o projeto

1. **Clonar o repositório**

git clone <link-do-repo>

2. **Entrar na pasta do projeto**

cd ServicoCepAtividade

3. **Restaurar pacotes**

dotnet restore


4. **Rodar o projeto**

dotnet run


5. **Acessar Swagger no navegador** (opcional, para testar os endpoints)

http://localhost:5101/swagger

## 💾 Banco de Dados

* SQLite (`ceps.db`) criado automaticamente pelo Entity Framework.
* Estrutura da tabela `Ceps`:

```sql
CREATE TABLE Ceps (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Cep TEXT NOT NULL,
    Logradouro TEXT,
    Complemento TEXT,
    Bairro TEXT,
    Localidade TEXT,
    Uf TEXT,
    Ibge TEXT,
    Gia TEXT,
    Ddd TEXT,
    Siafi TEXT,
    DataConsulta DATETIME NOT NULL
);


