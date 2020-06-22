namespace TCC.Application.Interfaces
{
    public interface ICrudMsgFormater
    {      
        string CreateErrorCrudMessage();
        string CreateSuccesCrudMessage();
        string CreateSuccesAutomaticCrudMessage();
    }
}
