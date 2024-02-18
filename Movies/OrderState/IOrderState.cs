using System;

namespace Class
{
    public interface IOrderState
    {
        void Submit(Order order);
        void Pay(Order order);
        void Cancel(Order order);
        void Remind(Order order);
    }
}
