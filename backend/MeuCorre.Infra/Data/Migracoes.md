# Comandos e passos para migra��es (Entity Framework Core)

Este arquivo explica, passo a passo, como criar e aplicar migra��es usando o EF Core. Instru��es pensadas para uso no Visual Studio (__Abrir no Terminal__) ou via linha de comando. Assuma que o projeto alvo � MeuCorre.Infra e que a aplica��o de inicializa��o (startup) � MeuCorre.

## Pr�-requisitos
- .NET SDK (compat�vel com .NET 8) instalado.
- Pacote NuGet `Microsoft.EntityFrameworkCore.Design` instalado no projeto que cont�m o DbContext.
- (Opcional) Ferramenta global CLI `dotnet-ef` instalada: `dotnet tool install --global dotnet-ef` ou use o `dotnet ef` fornecido pelo SDK.
- Verifique a string de conex�o e o DbContext corretamente registrados em MeuCorre.Infra/MeuDbContext.cs.
- Compile a solu��o antes de criar migra��o: `dotnet build` ou __Build__ no Visual Studio.

---

## 1) Abrir o terminal no projeto correto
No Visual Studio:
- Clique com o bot�o direito no projeto MeuCorre.Infra e selecione __Abrir no Terminal__.
Ou abra um terminal no diret�rio do projeto MeuCorre.Infra (pasta que cont�m o arquivo .csproj do projeto de infra).

---

## 2) Adicionar uma nova migra��o
Recomenda��es de nome: use PascalCase e descreva a mudan�a (ex.: `AddUsuarioIsActive`, `RemoveEnderecoCampoX`, `Ticket1234_AddIndex`).

Com o terminal aberto no diret�rio do projeto que cont�m o DbContext:
`dotnet ef migrations add NomeDaMigracao`

Exemplo:
`dotnet ef migrations add AddUsuarioIsActive`

Caso queira adicionar uma descri��o � migra��o, acrescente um h�fen e a descri��o ap�s o nome da migra��o.
Exemplo: `dotnet ef migrations add AddUsuarioIsActive-AddCampoIsActive`

**Aten��o:** Se houver mais de um projeto na solu��o, � necess�rio especificar o projeto de startup (normalmente MeuCorre) com a op��o `--startup-project` se o mesmo n�o estiver definido como projeto de inicializa��o padr�o. Exemplo:
`dotnet ef migrations add NomeDaMigracao --startup-project ../caminho/do/projeto/MeuCorre`

Se precisar especificar projeto e startup:
```bash
dotnet ef migrations add NomeDaMigracao --project MeuCorre.Infra --startup-project MeuCorre
```

- -p / --project: projeto que cont�m as migra��es (onde fica o DbContext).
- -s / --startup-project: projeto que cont�m a configura��o de inicializa��o (ex.: Program.cs).

Se houver m�ltiplos DbContext, especifique o nome do contexto:
---

## 3) Aplicar (atualizar) o banco de dados
Com o terminal ainda no diret�rio apropriado:
`dotnet ef database update`

Esse comando aplica todas as migra��es pendentes para o banco de dados. Durante a atualiza��o, o EF Core executa as opera��es necess�rias para trazer o banco de dados para o estado mais recente conforme definido pelas migra��es.

---

## 4) Reverter a �ltima migra��o (se necess�rio)
Caso precise desfazer a �ltima migra��o aplicada, utilize o comando:
`dotnet ef database update �ltimaMigra��oAntesDaQueDesejaReverter`

Exemplo:
`dotnet ef database update 20230315_InitialCreate`

Em que `20230315_InitialCreate` seria o nome da migra��o que est� imediatamente antes da migra��o que voc� deseja reverter.

---

## 5) Dicas e resolu��o de problemas
- Se o comando n�o for reconhecido, verifique se o `dotnet-ef` est� instalado ou se o pacote `Microsoft.EntityFrameworkCore.Design` est� presente.
- Se a migra��o n�o reflete mudan�as esperadas, confirme que as classes de entidade e o DbContext foram salvas e a solu��o foi compilada.
- Use `dotnet ef migrations list` para ver migra��es existentes.
- Para reverter a �ltima aplica��o: `dotnet ef database update NomeDaMigracaoAnterior`.
- Mantenha as migra��es sob controle de vers�o (commitar a pasta Migrations).

---

Boas pr�ticas: crie migra��es pequenas e at�micas, documente o prop�sito no nome e no commit, e sempre teste as migra��es em um ambiente local antes de aplicar em produ��o.

---

## 6) Problemas Comuns
- Se ao rodar `dotnet ef` ocorrer um erro dizendo que o comando n�o foi encontrado, verifique se o `dotnet-ef` est� instalado corretamente ou se o caminho para o mesmo est� adicionado nas vari�veis de ambiente do sistema.
- Erros de conex�o com o banco de dados normalmente est�o relacionados � string de conex�o. Verifique se as credenciais, o servidor e o banco de dados est�o corretos e acess�veis.

---

## 7) Documenta��o Adicional
Para mais detalhes sobre as altera��es em massa (bulk changes) e outras funcionalidades avan�adas, consulte a [documenta��o oficial do EF Core](https://docs.microsoft.com/ef/core/cli/dotnet).