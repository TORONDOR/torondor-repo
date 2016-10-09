using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Interfaces
{
    interface INumberGenerator
    {
        Task<Queue<int>> GetNumberSequenceAsync(int quantity);
        Queue<int> GetRandomNumbersUsingBCL(int quantity);
    }
}
