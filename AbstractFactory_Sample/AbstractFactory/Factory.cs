﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AbstractFactory
{
    public abstract class Factory

    {
        public static Factory GetFactory(string AsmName ,string ClassName)
        {
            Factory factory = null;
            try
            {
                Assembly asm = Assembly.Load(AsmName);
                factory = (Factory)asm.CreateInstance(
                   ClassName,
                   false,
                   BindingFlags.CreateInstance,
                   null,
                   null,
                   null,
                   null
                );
            }

            catch (TypeLoadException)
            {
                Console.Error.WriteLine($"クラス{ClassName}が見つかりません。");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
            }
            return factory;
        }

        public abstract Link CreateLink(string caption, string url);
        public abstract Tray CreateTray(string caption);
        public abstract Page CreatePage(string title, string author);
    }
}
