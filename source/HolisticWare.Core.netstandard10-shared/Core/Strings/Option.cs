using System;

namespace Core.Strings
{
    public partial class Option
    {
        public Option(string content)
        {
            this.Content = content;

            string[] key_value = content.Split
                                        (
                                            this.SeparatorsAssigment,
                                            StringSplitOptions.RemoveEmptyEntries
                                        );

            switch(key_value.Length)
            {
                case 1:
                    this.Key = key_value[0];
                    this.Value = key_value[0];
                    break;
                case 2:
                    this.Key = key_value[0];
                    this.Value = key_value[1];
                    break;
                default:
                    throw new InvalidOperationException($"Unable to parse {nameof(content)}");
            }

            this.Values = this.Value.Split
                                        (
                                            this.SeparatorsAssigment,
                                            StringSplitOptions.RemoveEmptyEntries
                                        );

            return;
        }

        public string Key
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string[] Values
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public string[] SeparatorsAssigment
        {
            get;
            set;
        } = new string[]
                    {
                        "=",
                        ":",
                    };

        public string[] SeparatorsList
        {
            get;
            set;
        } = new string[]
                    {
                        ",",
                        ";",
                    };
    }
}
