using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataWorks2App
{
    public class Node
    {
        public string Name { set; get; }
        public ObservableCollection<Node> Nodes { get; set; }
    }
}
