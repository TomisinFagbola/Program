using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common;
    public class Question
    {

        public string Type { get; set; }
        public List<string> Options { get; set; }
        public bool isAnswered { get; set; }
    }

