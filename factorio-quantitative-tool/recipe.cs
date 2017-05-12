using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorio_quantitative_tool
{
    class recipe
    {
        string type;
        string name;
        bool enabled;
        Dictionary<string, int> ingredients = new Dictionary<string, int>();
        string result;

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }

            set
            {
                enabled = value;
            }
        }

        public Dictionary<string, int> Ingredients
        {
            get
            {
                return ingredients;
            }

            set
            {
                ingredients = value;
            }
        }

        public string Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }
    }
}
