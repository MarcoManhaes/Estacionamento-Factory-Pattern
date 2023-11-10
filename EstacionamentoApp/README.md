# Estacionamento-Factory-Pattern
Projeto de Simulação de Estacionamento em C# .Net Core  - Aplica Design Patterns (Factory), Injeção de Dependências (Singleton e Scoped), Herança, Composição, Polimorfismo, Interfaces, Abstract Class, Generic Clçass, Solid, Clean Code e DDD em C#.&nbsp;

## __***Descrição***__

Desenvolvimento do projeto Console App 'Simulação de Estacionamento' com o propósito de aplicar teorias e melhores práticas de Programação Orientada a Objetos, Design Patteners, SOLID, Clean Code e DDD.&nbsp;

Este é um projeto do tipo Console App .Net Core 6, onde a interação com o usuário ocorre por meio do terminal. Entradas fornecidas pelo usuário são processadas, e os resultados obtidos são registrados no terminal usando logs através de `Console.WriteLine`. &nbsp;

Esses logs simulam o FrontEnd da aplicação, sendo essenciais para demonstrar o progresso e os resultados do processamento das entradas.&nbsp;

### O enunciado proposto para orientar o desenvolvimento foi:

__***Objetivos***__: <br />

Projetar um estacionamento usando princípios orientados a objetos
- Diga-nos quantas vagas restam<br />
- Diga-nos quantas vagas totais há no estacionamento<br />
- Diga-nos quando o estacionamento estiver cheio<br />
- Diga-nos quando o estacionamento estiver vazio<br />
- Diga-nos quando certos lugares estão cheios, por exemplo quando todas as vagas de moto são ocupadas<br />
- Diga-nos quantas vagas as vans estão ocupadas<br />

__***Orientações para desenvolvimento***__:<br />
- O estacionamento pode acomodar motos, carros e vans<br />
- O estacionamento tem vagas para motos, vagas para carros e vagas grandes<br />
- Uma moto pode estacionar em qualquer lugar<br />
- Um carro pode estacionar em uma única vaga para carro, ou em uma vaga grande<br />
- Uma van pode estacionar, mas ocupará 3 vagas de carro, ou uma vaga grande<br />

__***Técnicas, Arquitetura, Padrões e Abordagens aplicadas***__:<br />
- Arquitetura Monolita em única camada (visto a simplicidade do projeto)<br />
- Design Patterns (Factory)<br />
- Injeção de Dependências (Singleton e Scoped)<br />
- Herança<br />
- Composição<br />
- Polimorfismo<br />
- Interfaces<br />
- Abstract Class<br />
- Generic Class<br />
- Princípios SOLID<br />
- Práticas Clean Code <br />
- Abordagem DDD<br />

## __***Manual de utilização***__

As entradas são através de "Menus Numéricos" ou seja, para cada item de função do menu, deve-se infoprmar o número corresponmdente à função desejada, exemplo:

```c++
------------------------------------------
Selecione o tipo de serviço para o estacionamento:

1 - Estacionar moto
2 - Estacionar carro
3 - Estacionar van
4 - Retirar moto
5 - Retirar carro
6 - Retirar van
------------------------------------------

Digite o número para serviço desejado:

```
### Observação importante:
Não foi implemenmtada a validação e tratamento de erros para entrada de dados diferente de **NUMÉRICOS** por não ser este o foco do projeto.
A sugestão é não realizar teste de entradas diferente da proposta, afim de ser mais efetivo na utilização, teste de execução e funcionalidades.

## __***Dependências***__
* Microsoft.Extensions.Hosting (utiliz\ada para registrar a injeção de dependências na classe Program.cs

## __***Execução***__

Os comandos abixo precisam ser executados em linha de comando, estando no diretório do projeto:
* 'dotnet run' --> para executar a aplicação Estacionamento (Console App) no terminal
* Executar diretamente pelo Visual Studio 

## __***Autor***__
* __***Marco Manhães Júnior***__  <o/

