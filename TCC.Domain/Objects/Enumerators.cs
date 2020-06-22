namespace TCC.Domain.Objects
{
    using System.ComponentModel;

    public enum eErrorGravity
    {
        SemErro = 0,
        Pequena = 1,
        Media = 2,
        Grande = 3,
        Travamento = 4
    }

    
    public enum eDiaSemana : short
    {
        [Description("DOMINGO")]
        Domingo = 1,
        [Description("SEGUNDA")]
        Segunda = 2,
        [Description("TERÇA")]
        Terca = 3,
        [Description("QUARTA")]
        Quarta = 4,
        [Description("QUINTA")]
        Quinta = 5,
        [Description("SEXTA")]
        Sexta = 6,
        [Description("SABADO")]
        Sabado = 7
    }
    

    public enum eTipoMensagem : short
    {
        Notificacao = 1
    }

    public enum eTipoAtividade : short
    {
        [Description("Musculação")]
        Musculacao = 1,
        [Description("Aula em Grupo")]
        AulaGrupo = 2
    }


    public enum eTipoPerfil : short
    {
        [Description("Administrador")]
        Admin = 1,      
        [Description("Instrutor")]
        Instrutor = 3
    }


    public enum eTipoArquivo
    {
        [Description("FOTO")]
        Foto = 1,
        [Description("LOGO")]
        Logo = 2
    }
}
