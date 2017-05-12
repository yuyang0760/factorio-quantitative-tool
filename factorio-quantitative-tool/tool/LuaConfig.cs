﻿using Neo.IronLua;
using System;
using System.IO;
using System.Text;

namespace LuaTool
{

    /// <summary>
    /// lua的设置文件
    /// </summary>
    class LuaConfig
    {
        /// <summary>
        /// 读取lua,并返回luaTable
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <param name="isReturn"></param>
        /// <returns></returns>
        public LuaTable ReadLua(string path, Encoding encoding,bool isReturn) {

            //lua读取
            using (Lua l = new Lua())
            {
               
                // 创建环境
                var g = l.CreateEnvironment();
   
                // 读取文件
                StreamReader reader = new StreamReader(path, encoding);
                LuaResult r = new LuaResult();
                try
                {
                     r = g.DoChunk(reader, "test.lua");
                    
                }
                catch (Exception  )
                {
                   
                }
             
                reader.Close();
                // 如果有返回值
                if (isReturn)
                {
                    LuaTable lt = (LuaTable)r[0];
                    return lt;
                }
                else {
                    LuaTable lt = g;
                    return lt;
                }
            }
        }




        /// <summary>
        /// 读取lua,并返回luaTable
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <param name="isReturn"></param>
        /// <returns></returns>
        public LuaTable ReadLua(string code, bool isReturn)
        {

            //lua读取
            using (Lua l = new Lua())
            {

                // 创建环境
                var g = l.CreateEnvironment();

                // 读取文件
              //  StreamReader reader = new StreamReader(path, encoding);
                LuaResult r = new LuaResult();
                try
                {
                    r = g.DoChunk(code, "test.lua");

                }
                catch (Exception)
                {

                }

               // reader.Close();
                // 如果有返回值
                if (isReturn)
                {
                    LuaTable lt = (LuaTable)r[0];
                    return lt;
                }
                else
                {
                    LuaTable lt = g;
                    return lt;
                }
            }
        }
    }
}
