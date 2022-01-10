namespace GitNode.Application.Common.Interfaces
{
    public interface ICryptography
    {
        string Encrypt(string plainText);

        string Decrypt(string cipherText);
    }
}