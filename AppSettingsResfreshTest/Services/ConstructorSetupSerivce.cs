namespace AppSettingsResfreshTest.Services
{
    public interface IConstructorSetupSerivce
    {
        string Url { get; set; }
        int GetANumber();
    }

    public class ConstructorSetupSerivce : IConstructorSetupSerivce
    {
        public string Url { get; set; }

        public int GetANumber() => 777;
    }
}
