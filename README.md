# Placemarks
A tarefa consiste em desenvolver uma Web API em .NET para processar e filtrar dados contidos em um arquivo KML chamado DIRECIONADORES1.kml

# Teste - Web API em .NET

## Descrição do Teste

Desenvolver uma Web API em .NET que permita aos usuários filtrar dados de um arquivo KML (`DIRECIONADORES1.kml`). A API deve seguir o padrão REST e fornecer os seguintes endpoints:

### Endpoints Principais

1. **Exportar novo arquivo KML**: Permite a exportação de um novo arquivo KML com base em um filtro aplicado.
2. **Listar elementos no formato JSON**: Retorna uma lista dos dados filtrados.
3. **Obter elementos disponíveis para filtragem**: Retorna os valores únicos dos campos de pré-seleção disponíveis no arquivo KML.

---

## Requisitos de Filtragem

Os dados contidos no elemento `Placemark` devem ser filtráveis pelos seguintes campos:

- **CLIENTE** (pré-seleção de valores).
- **SITUAÇÃO** (pré-seleção de valores).
- **BAIRRO** (pré-seleção de valores).
- **REFERÊNCIA** (texto parcial, mínimo de 3 caracteres).
- **RUA/CRUZAMENTO** (texto parcial, mínimo de 3 caracteres).

### Validação de Filtros

- **Pré-seleção**:
  - Os campos `CLIENTE`, `SITUAÇÃO` e `BAIRRO` devem conter apenas itens previamente lidos e disponibilizados.
- **Texto parcial**:
  - Os campos `REFERÊNCIA` e `RUA/CRUZAMENTO` devem ter pelo menos 3 caracteres.
- Caso um filtro seja passado incorretamente, a API deve retornar um **erro 400** com uma mensagem apropriada.

---

## Requisitos Não Funcionais

- **Princípios do SOLID**: Aplicação de boas práticas de design orientado a objetos.
- **Foco em performance**.
- **Uso de POO**: Estruturação da solução com boa lógica orientada a objetos.

---

## Instruções para Implementação

1. **Carregar o Arquivo KML**: Faça a leitura do arquivo `DIRECIONADORES1.kml`.
2. **Criar os Endpoints da Web API**:

### a. Filtrar e Exportar KML
- **Endpoint**: `/api/placemarks/export`
- **Método**: `POST`
- **Parâmetros**: Filtros para `CLIENTE`, `SITUAÇÃO`, `BAIRRO`, `REFERÊNCIA` e `RUA/CRUZAMENTO`.
- **Retorno**: Novo arquivo KML gerado com base nos filtros aplicados.
- **Validação**: Retornar **erro 400** se os filtros forem inválidos.

### b. Listar em Formato JSON
- **Endpoint**: `/api/placemarks`
- **Método**: `GET`
- **Parâmetros**: Filtros para `CLIENTE`, `SITUAÇÃO`, `BAIRRO`, `REFERÊNCIA` e `RUA/CRUZAMENTO`.
- **Retorno**: Lista dos elementos filtrados no formato JSON.
- **Validação**: Retornar **erro 400** se os filtros forem inválidos.

### c. Obter Elementos Disponíveis para Filtragem
- **Endpoint**: `/api/placemarks/filters`
- **Método**: `GET`
- **Retorno**: Valores únicos para os campos `CLIENTE`, `SITUAÇÃO` e `BAIRRO`.

---

## Considerações Finais

- Certifique-se de aplicar validações robustas para os filtros.
- Utilize práticas recomendadas de desenvolvimento em .NET para garantir a escalabilidade e manutenibilidade do código.
- O foco na performance e na aplicação de princípios de design (SOLID) é essencial para a qualidade da solução.

