using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFineSystem
{
    public interface IView<T> where T: IViewModel
    {
        void Initialize(T viewModel);
    }
}
