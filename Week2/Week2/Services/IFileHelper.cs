using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Week2
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}