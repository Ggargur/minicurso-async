using Minicurso.Movement;

namespace Minicurso.Tests.Buttons
{
    public class ParallelTestButton : BaseTestButton
    {
        public override void CreateTestAsset() => TestManager.Instance.Spawn<ParallelMovement>(Amount);
    }
}