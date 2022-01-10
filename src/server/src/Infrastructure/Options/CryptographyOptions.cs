namespace GitNode.Infrastructure.Options
{
    internal class CryptographyOptions
    {
        public const string OptionName = "Cryptography";
        
        public string PrivateKey { get; set; }
    }
}