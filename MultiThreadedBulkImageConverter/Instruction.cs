using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace MultiThreadedBulkImageConverter
{
    public class Instruction
    {
        private string inputFileName;
        private string outputFileName;
        private ImageFormat formatToOutput;
        private ParallelOptions parallelOptions;

        public delegate void ImageEvent(ImageOpsEventArgs args);
        public static event ImageEvent OnImageConversionStart;
        public static event ImageEvent OnImageConversionComplete;

        public Instruction(string inputFileName, string outputFileName, ImageFormat formatToOutput, ParallelOptions parallelOptions)
        {
            this.inputFileName = inputFileName;
            this.outputFileName = outputFileName;
            this.formatToOutput = formatToOutput;
            this.parallelOptions = parallelOptions;
        }

        internal void Process()
        {
            byte[] photoBytes = File.ReadAllBytes(inputFileName);

            Size size = new Size(150, 0);
            //If OnImageConversionStart event is being subscribed to, raise it
            OnImageConversionStart?.Invoke(new ImageOpsEventArgs(inputFileName));

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        // Load, resize, set the format and quality and save an image.
                        //imageFactory.Load(inStream).Resize(size).Format(format).Save(outStream);
                        imageFactory.Load(inStream).Save(outStream);
                        //imageFactory.Load(inStream).Format(format).Save(outStream);
                    }
                    // Do something with the stream.
                    using (Image img = new Bitmap(outStream))
                    {
                        using (Image originalFile = new Bitmap(inputFileName))
                        {
                            foreach (PropertyItem item in originalFile.PropertyItems)
                            {
                                img.SetPropertyItem(item);
                            }
                            img.Save(outputFileName, formatToOutput);
                        }
                    }
                }
            }
            //If OnImageConversionComplete event is being subscribed to, raise it
            OnImageConversionComplete?.Invoke(new ImageOpsEventArgs(outputFileName));
        }
    }
}