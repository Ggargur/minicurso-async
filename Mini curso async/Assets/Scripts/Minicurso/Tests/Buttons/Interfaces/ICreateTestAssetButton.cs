namespace Minicurso.Tests.Buttons.Interfaces
{
    public interface ICreateTestAssetButton
    {
        public int Amount { get; }
        void CreateTestAsset();
    }
}