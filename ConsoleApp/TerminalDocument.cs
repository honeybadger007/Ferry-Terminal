using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class TerminalDocument
    {
        public int DocumentId { get;  set; }
        
        public List<int> ParcelsIds { get;  set; }

        public List<int> InvoicesIds { get; set; }

        public TerminalDocument()
        {
            // To avoid checking if it is null when the class is consumed
            ParcelsIds = new List<int>();
            InvoicesIds = new List<int>();

        }

    }
}
