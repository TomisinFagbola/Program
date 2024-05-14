using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum EQuestionType
    {
        [Description("Paragraph")]
        Paragraph = 1,

        [Description("YesNo")]
        YesNo = 2,

        [Description("Dropdown")]
        Dropdown = 3,

        [Description("MultipleChoice")]
        MultipleChoice = 4,

        [Description("Date")]
        Date = 5,

        [Description("Number")]
        Number = 6,

    }
}
