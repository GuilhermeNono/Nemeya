﻿namespace Idp.CrossCutting.Messages;

public static class ErrorMessage
{
    /// <summary>
    /// Classe Responsável pelas Mensagens de Exceção do Sistema
    /// </summary>
    public static class Exception
    {
        public static string ExternalOrderWithInternalPagination() =>
            "Não é possível declarar a ordenação nos métodos de adição. Faça isso utilizando o Método OrderBy() presente na declaração da Query.";
        public static string EntityNotFound(long id, string entityName) =>
            $"Não foi possível encontrar um registro de Id: {id} para {entityName}.";
        
        public static string EntityNotFound(Guid id, string entityName) =>
            $"Não foi possível encontrar um registro de Id: {id} para {entityName}.";

        public static string EntityNotFound(string entityName) =>
            $"Não foi possível encontrar um registro para {entityName}.";
        
        public static string EntityDeleteNotFoundException(string entity) =>
            $"Não foi possível deletar, pois não há registro em {entity} com este Id.";
        
        public static string MigrationFailed() => "Houve uma falha ao executar a migração do banco de dados.";

        public static string UserNotFound(Guid id) => $"Não foi possível encontrar um usuário com o Id {id}";

        public static string LoginNotFound() => "Credenciais inexistentes ou inválidas.";

        public static string DocumentEmpty() => "O numero do documento não pode ser nulo e nem vazio.";

        public static string DocumentNumberHasToBeFormated(string documentNumber) => $"O numero do document {documentNumber} é inválido. Envie o numero utilizando a mascara 000.000.000-00(CPF) ou 00.000.000/0000-00(CNPJ).";

        public static string DocumentCpfInvalid() => "O numero de CPF não é válido.";

        public static string DocumentCnpjInvalid() => "O numero d CNPJ não é válido.";

        public static string UserEmailNotFound() => "Não foi possível encontrar o email desse usuario.";

        public static string EmailIsAlreadyInUseException(string email) => $"O e-mail: {email} já está sendo utilizado.";

        public static string DocumentIsAlreadyInUseException(string document) =>
            $"O documento: {document} já está sendo utilizado.";

        public static string UserAlreadyHasThatRole(string role) => $"Esse usuario já possui o cargo {role}.";

        public static string PermissionRoleNotFound(string role) =>
            $"Não foi possível encontrar um cargo de nome {role}.";

        public static string PersonNotFound() => "Não foi possível encontrar um usuário com esse Id.";

        public static string RefreshNotFound() => "Não foi possível encontrar esse refresh token.";

        public static string ExpiredTokenException() => "O token se encontra expirado.";

        public static string WalletPublicKeyNotFound(string publicKey) => $"Não foi encontrada nem uma carteira com a chave {publicKey}.";

        public static string WalletUserNotFound(Guid userId) => $"Nâo foi possivel encontrar uma carteira para o usuario {userId}.";

        public static string WalletNotFound(Guid walletId) => $"A carteira de id {walletId} não foi encontrada.";

        public static string LastBlockNotFound() =>
            "Não foi possivel completar a transação, pois o ultimo bloco não foi encontrado.";

        public static string TransactionsNotFound() => "Não foi possivel localizar as transações.";

        public static string LoggedPersonNotFound() => "Não foi possivel encontrar o usuario logado na base de dados.";

        public static string TransactionForYourself() =>
            "Não é possivel enviar os pontos, pois a carteira alvo é a sua.";

        public static string InsufficientBalance() => "Não foi possivel completar a transação, pois você não possui pontos o suficiente para isso.";

        public static string ReceiverWalletIsUnavailable() =>
            "A carteira do destinatario se encontra indisponivel para novas transações.";

        public static string ProhibitedBalanceAmount(decimal points) => $"A quantidade atual de pontos presentes na carteira é inválida: {points}";

        public static string SenderWalletUnavailable() => "A carteira do rementente se encontra indisponivel para novas transações.";

        public static string InvalidLeafsToCreateAMerkleTree() => "Não foi possivel prosseguir com a criação da Merkle Tree, pois não foram informados dados o suficiente.";

        public static string BlockCorruption(Guid blockId) => $"As transações do bloco {blockId} estão corrompidas.";

        public static string BlockTransactionNotFound(Guid blockId) =>
            $"Não foi possivel encontrar as transações do bloco {blockId}.";

        public static string CheckpointsNotFoundFromThisBatch() => "Não foi possivel encontrar checkpoints com esse Id de validação.";

        public static string DescriptionAttributeNotFound() => "Não foi possivel encontrar a anotação [Description].";

        public static string WalletHashNotFound(string hash) => $"Não foi possivel encontrar uma carteira de codigo {hash}.";

        public static string SignatureIsInvalid() =>
            "Não foi possivel completar uma transação com a assinatura informada.";

        public static string MigrationConnection(string? connectionString) => $"Não foi possivel estabelecer uma conexão estavel com \"{connectionString ?? "null"}\".";
    }
}
