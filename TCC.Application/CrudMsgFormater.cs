using TCC.Application.Interfaces;

namespace TCC.Application
{
    public class CrudMsgFormater : ICrudMsgFormater
    {

        public string CreateErrorCrudMessage()
        {
            var errorMessage = "Não foi possível concluir a operação. Tente novamente mais tarde.";
            return errorMessage;
        }

        public string CreateSuccesCrudMessage()
        {
            var succesMessage = "Operação concluída com sucesso.";
            return succesMessage;
        }

        public string CreateSuccesAutomaticCrudMessage()
        {
            var succesMessage = "Salvo automaticamente com sucesso.";
            return succesMessage;
        }
    }
}
