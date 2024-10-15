using System.Collections;

namespace Minicurso.Movement
{
    public class PseudoParallelMovement : BaseMovement
    {
        public bool IsRunning { get; set; } = true;

        protected override void Start()
        {
            base.Start();
            StartCoroutine(PseudoParallelMove());
        }

        protected override void Update(){}

        private IEnumerator PseudoParallelMove()
        {
            while(IsRunning){
                Move();
                yield return null;
            }
        }
    }
}