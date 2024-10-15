using Minicurso.Movement;

namespace Minicurso.Tests.Buttons
{
    public class PseudoParallelTestButton : BaseTestButton
    {
        public override void CreateTestAsset() => TestManager.Instance.Spawn<PseudoParallelMovement>(Amount);
    }
}