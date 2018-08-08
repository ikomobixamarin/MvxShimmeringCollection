using System;
namespace MvxShimmering
{
    public class InvalidRootViewException : System.Exception
    {
        public InvalidRootViewException()
            : base("You must use a 'io.supercharge.shimmerlayout.ShimmerLayout' view as the root of your MvxShimmerTemplate")
        {
        }
    }
}
