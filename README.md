# 25-days-of-serverless

Builded during Twitch streaming:

https://www.twitch.tv/rmaurodev

Check my discord server:

https://discord.gg/cQ547A




tree folder

- src 		#codigo fonte
- docs 		#documentacao especifica e.g. arquitetura, banco (MER), Diagrama de autenticacao SAML
- misc 		
	.gitkeep
	- sql	# script p gerar o banco de dados inicial
		initial.sql - criar tabelas
		procedures.sql 
		views.sql
	- containers	#dockerfiles
		Dockerfile.mysql
		Dockerfile.sqlserver
		Dockerfile.elasticsearch
	
Readme.md

## Nome do Projeto

### Contatos
R2SIS - Nome e Email

Cliente - Nome e Email

### Tecnologias

C# e AspNet 5 [Link](docs.microsoft.com)

Azure Storage [Link](azure.docs.microsoft.com)

SQL Server  [Link](azure.docs.microsoft.com)

Twilio SMS  [Link](azure.docs.microsoft.com)

### Ferramenta
- Visual Studio
- Windows com WSL2
- Docker Enabled

### Preparação Ambiente
- Abrir Solution no Visual Studio e roda
- Rodar script SQL [/misc/sql/initial.sql](/misc/sql/initial.sql) no banco de dados

#### Criar conta de blob storage
- Criar conta com nome *Storage-CTG*
- Adicionar secrets no appsettings.json

#### Criar Elastic Search
- Abrir o bash
- Rodar o comando `docker run -p 80:80 -f /misc/containers/Dockerfile.elasticsearch .`

### Particularidades do sistema

- Sistema de validação baseado no artigo [Artigo](https://google.com)
