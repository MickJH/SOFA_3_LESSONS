using System;

namespace Movies.PricingStrategy
{
    public class StrategyFactory
    {
        private bool IsStudentOrder;

        public StrategyFactory(bool IsStudentOrder)
        {
            this.IsStudentOrder = IsStudentOrder;
        }

        public IPricingStrategy GetPricingStrategy()
        {
            return this.IsStudentOrder ? new StudentStrategy() : new RegularStrategy();
        }
    }
}
