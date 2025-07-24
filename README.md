
# 🏥 Consultorio API

API desenvolvida em ASP.NET Core 8 para gerenciamento de consultas, pacientes, profissionais e especialidades médicas.

---

## 🔧 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Injeção de Dependência
- Fluent API


---

## 📁 Estrutura do Projeto

```bash
Consultorio/
├── Controllers/        # Controllers da API
├── Data/               # Configuração do DbContext
├── Dtos/               # Data Transfer Objects (entrada/saída)
├── Interfaces/         # Interfaces para services e repos
├── Models/             # Entidades principais
├── Services/           # Regras de negócio
├── Settings/           # Configurações externas como Twilio
├── appsettings.json    # Configurações da aplicação
```

---

## 🗃️ Endpoints Principais

### 🔹 Pacientes
- `GET /api/pacientes`
- `POST /api/pacientes`
- `PUT /api/pacientes/{id}`
- `DELETE /api/pacientes/{id}`

### 🔹 Profissionais
- `GET /api/profissionais`
- `POST /api/profissionais`

### 🔹 Especialidades
- `GET /api/especialidades`
- `POST /api/especialidades`

### 🔹 Consultas
- `POST /api/consultas` → Cria uma nova consulta
- `GET /api/consultas/por-paciente/{id}` → Lista as consultas por paciente

---

## ⚙️ Configuração do Banco de Dados

A string de conexão está em `appsettings.json` . Exemplo:

```json
"ConnectionStrings": {
  "Default": "Server=localhost\SQLEXPRESS01;Database=ConsultorioDB;User Id=seu_usuario;Password=sua_senha;"
}
```

---

## 📲 Notificações com Twilio (SMS)

As notificações por SMS estão integradas via [Twilio](https://www.twilio.com/)-
[Documentação](https://www.twilio.com/docs):

- `TWILIO__AccountSID`
- `TWILIO__AuthToken`
- `TWILIO__From`

---

## 🚀 Executando a API

```bash
# Restaure os pacotes
dotnet restore

# Rode as migrações (se usar EF Core)
dotnet ef database update

# Inicie a API
dotnet run
```

---

## 📌 Observações

- Projeto em desenvolvimento para aprendizado e portfólio.
- Boas práticas utilizadas: DTOs, Services,  e injeção de dependência.

---

## 👨‍💻 Autor

**Caio de Souza Nery**

[GitHub: CaioSNery](https://github.com/CaioSNery)
