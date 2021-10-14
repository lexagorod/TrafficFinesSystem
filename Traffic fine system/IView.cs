using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system
{
    public interface IView<T> where T: IViewModel
    {
        void Initialize(T viewModel);
    }
}
