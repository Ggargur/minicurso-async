using UnityEngine;

namespace Minicurso.Movement
{
    public class ParallelMovement : BaseMovement
    {
        protected override void Update()
        {
            _ = Move();
        }

        public new async Awaitable Move()
        {
            await Awaitable.BackgroundThreadAsync();
            DoHeavyCalculations();
            await Awaitable.MainThreadAsync();
            SetNewPosition();
        }
    }
}