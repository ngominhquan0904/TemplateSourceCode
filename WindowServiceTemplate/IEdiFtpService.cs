namespace WindowServiceTemplate
{
    public interface IEdiFtpService
    {
        string WriteOrderMessageFile(string fName, string mes);
        string WriteTestScriptFile(string scriptName, string script); 
    }
}