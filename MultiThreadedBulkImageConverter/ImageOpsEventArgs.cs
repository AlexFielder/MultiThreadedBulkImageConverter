using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadedBulkImageConverter
{
    /// <summary>
    /// A class used to communicate ImageOps events
    /// </summary>
    public class ImageOpsEventArgs : EventArgs
    {
        protected string _imageFilename;

        public string ImageFilename
        {
            get { return _imageFilename; }
        }

        public ImageOpsEventArgs(string filename) : base()
        {
            _imageFilename = filename;
        }
    }

}
