using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class CareTaker
    {
        public readonly Stack<Memento> mementos = new Stack<Memento>();

        public void add (Memento memento)
        {
            mementos.Push(memento);
        }

        public Memento undo ()
        {
            return mementos.Count > 0 ? mementos.Pop() :null;
        }
    }
}
