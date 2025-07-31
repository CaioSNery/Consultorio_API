
# 🏥 Consultorio API

API REST desenvolvida em **ASP.NET Core 8**, focada no gerenciamento de **consultas médicas**, **pacientes**, **profissionais** e **especialidades**. Com autenticação via **JWT**, regras de negócio com **Fluent API**, mapeamento com **AutoMapper** e deploy automatizado via **Azure App Service**.

---

## 🚀 Funcionalidades

- ✅ Agendamento inteligente de consultas (sem conflitos para profissionais)
- 🔐 Autenticação segura com JWT
- 🧑‍⚕️ Cadastro completo de pacientes, médicos e especialidades
- 🔁 Mapeamento automático com AutoMapper
- 📲 Notificações SMS via Twilio
- 🧭 Deploy contínuo na Azure
- 📘 Documentação via Swagger

---

## 🔧 Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT + Swagger
- AutoMapper
- Fluent API
- Azure App Service
- Twilio SMS+WhatsApp

---

## 📁 Estrutura do Projeto

```
Consultorio/
├── Controllers/        # Endpoints da API
├── Data/               # DbContext e configurações do EF Core
├── Dtos/               # Modelos de entrada e saída
├── Interfaces/         # Abstrações para services e repositórios
├── Models/             # Entidades principais
├── Services/           # Lógica de negócio
├── Mappings/           # Perfis do AutoMapper
├── Settings/           # Configurações externas (ex: Twilio)
├── appsettings.json    # Conexão com o banco e chaves
```

---

## 🔐 Autenticação JWT

- Login via: `POST /api/auth/login`  
- O token JWT deve ser enviado no header das requisições protegidas:

```http
Authorization: Bearer {token}
```

---

## 📌 Regras de Agendamento

- 🔒 Valida se **não existe outra consulta para o mesmo profissional**, no **mesmo dia e horário**
- 🧠 Verifica se o **paciente**, **profissional** e **especialidade** existem e estão ativos
- 🕓 Filtra e exibe **horários disponíveis** para o agendamento

---

## 📲 Endpoints

### Pacientes
- `GET /api/pacientes`
- `POST /api/pacientes`
- `PUT /api/pacientes/{id}`
- `DELETE /api/pacientes/{id}`

### Profissionais
- `GET /api/profissionais`
- `POST /api/profissionais`
- `DELETE /api/profissionais/{id}`

### Especialidades
- `GET /api/especialidades`
- `POST /api/especialidades`

### Consultas
- `POST /api/consultas`
- `GET /api/consultas/por-paciente/{id}`
- `PUT /api/consultas/{id}`
- `DELETE /api/consultas/{id}`

---

## ⚙️ Banco de Dados

```json
"ConnectionStrings": {
  "Default": "Server=azure_sql_server_url;Initial Catalog=ConsultorioDB;Persist Security Info=False;User ID=Your_ADMIN;Password=Your_Password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
}
```

> Use `dotnet ef database update` para aplicar as migrações.

---

## 🔁 AutoMapper

Mapeia DTOs e Entidades utilizando perfis definidos em `Mappings/AutoMapperProfile.cs`.

---

## 🌐 Azure

Deploy feito via CLI ou Visual Studio.

- URL pública: [consultoriocaio-h9fab5bud3aghnaf.brazilsouth-01.azurewebsites.net/swagger](consultoriocaio-h9fab5bud3aghnaf.brazilsouth-01.azurewebsites.net/swagger)
- Documentação Swagger: `/swagger`

---

## 📘 Swagger

Interface visual para testar os endpoints da API.  
Suporta autenticação via JWT Token.

---

## 👨‍💻 Autor

**Caio de Souza Nery**  
Desenvolvedor backend apaixonado por organização, automação e APIs confiáveis.

---
