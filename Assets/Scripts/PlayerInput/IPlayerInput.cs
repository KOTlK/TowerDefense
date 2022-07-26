using System;

namespace PlayerInput
{
    public interface IPlayerInput : IPointerInput
    {
        event Action CancelPressed;
        void Bind();
        void Execute();
        void Unbind();
    }
}