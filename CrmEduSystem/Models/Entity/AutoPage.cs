using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
   public  class AutoPage
    {
        public string ParPath { get; set; }
        public string ParName { get; set; }

        public List<ChildPage> ChildFile = new List<ChildPage>();
       
    }

   public class ChildPage
    {
        public string ChPath { get; set; }
        public string ChName { get; set; }
        public string ChTxtPath { get; set; }
        public AutoPage parent=new AutoPage();
    }
}
