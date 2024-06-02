using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDL.ViewModels;

namespace TDL.Infrastructure.Extensions
{
    public static class OCExtentions
    {
        public static ObservableCollection<TodoViewModel> Replace(this ObservableCollection<TodoViewModel> collection, TodoViewModel tvm)
        {
            int position = collection.IndexOf(tvm);
            return collection;
        }
    }
}
