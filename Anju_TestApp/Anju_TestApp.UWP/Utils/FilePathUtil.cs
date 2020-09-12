using Anju_TestApp.Interfaces;
using Anju_TestApp.UWP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Text;
using System.Threading.Tasks;

[assembly: Dependency(typeof(FilePathUtil))]
namespace Anju_TestApp.UWP.Utils
{
    public class FilePathUtil : IBaseFilePath
    {
        public string GetFilePath()
        {
            return "ms-appx-web:///";
        }
    }
}
