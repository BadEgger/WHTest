using System;
using System.Collections.Generic;
using System.Text;

namespace WHTest
{
    public class ExceptionLoged
    {
        //将日志保存起来，并且存在根目录下。
        public static void W(Exception ex)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append(ex.Message);
            //像这些小功能，全部打成小包。找个机会。比如读取照片，比如添加哪个目录。要把功能分解，不能再写这些小东西了。。
            var logpath = @"D:\VS2017工程\Xamarin\WHTest\WHTest\WHTest\暂时性的log.txt";
            Console.WriteLine(ex);//或者搞个弹窗弹出来。
            
        }
    }
}
