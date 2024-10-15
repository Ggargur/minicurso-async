
using UnityEngine;

namespace Minicurso.Movement.Interfaces
{
    public interface IMoveable
    {
        float Speed { get; set; }
        Vector3 Direction { get; set; }
        float Amplitude { get; set; }

        void Move();
    }

}