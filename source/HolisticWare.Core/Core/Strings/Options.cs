using System;
using System.Collections.Generic;

namespace Core.Strings
{
    public partial class Options
    {
        public Options()
        {
        }

        public string ContentTextual
        {
            get;
            set;
        }

        public List<Option> Content
        {
            get
            {
                return Parse(ContentTextual, SeparatorsByLevel[1]);
            }
        }

        public Dictionary<int, string[]> SeparatorsByLevel
        {
            get;
            set;
        } = new Dictionary<int, string[]>()
            {
                { 1, new string[] { " " } },
                { 2, new string[] { ";", "," } },
            };


        public List<Option> Parse(string content_textual, string[] separators)
        {
            List<Option> retval = null;

            string[] options_textual = content_textual.Split
                                                        (
                                                            separators,
                                                            StringSplitOptions.RemoveEmptyEntries
                                                        );

            if (options_textual != null)
            {
                retval = new List<Option>();
                foreach(string ot in options_textual)
                {
                    Option o = new Option(ot);
                    retval.Add(o);
                }
            }

            return retval;
        }

    }
}
