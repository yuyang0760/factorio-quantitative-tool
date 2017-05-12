using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuaTool;
using Neo.IronLua;
using System.IO;

namespace factorio_quantitative_tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // 读取配方
            List<recipe> recipe_list = new List<recipe>();
            recipe_list =readReipes("recipe.lua");

            // 读取汉化

        }

        private   List<recipe> readReipes(string path)
        {
            // 读取文件

        
            StreamReader reader = new StreamReader(path, Encoding.UTF8);

            string factorioData = reader.ReadToEnd().Trim().Replace("data:extend(", "factorioData=").Replace(")", "");

            // 读取lua
            LuaConfig lc = new LuaConfig();


            LuaTable lt = lc.ReadLua(factorioData, false);
            // LuaTable lt =lc.ReadLua(path, Encoding.UTF8, false );

            LuaTable lt1 = (LuaTable)lt["factorioData"];

            object o = lt1[1];

            List<recipe> recipe_list = new List<recipe>();


            for (int i = 1; i < lt1.Length + 1; i++)
            {
                recipe recipe = new recipe();


                IDictionary<string, object> d = (((LuaTable)lt1[i]).Members);




                recipe.Type = d["type"].ToString();
                recipe.Name = d["name"].ToString();
                LuaTable lt_ingredients = null;
                if (d.ContainsKey("normal"))
                {


                    d = ((LuaTable)d["normal"]).Members;

                }
                lt_ingredients = ((LuaTable)d["ingredients"]);

                for (int j = 1; j < lt_ingredients.Length + 1; j++)
                {
                    IList<object> ilist = (((LuaTable)lt_ingredients[j])).ArrayList;
                    if (ilist.Count > 0)
                    {
                        recipe.Ingredients.Add(ilist[0].ToString(), (int)ilist[1]);
                    }

                }
                recipe_list.Add(recipe);

            }
            return recipe_list;
        }
    }

}

