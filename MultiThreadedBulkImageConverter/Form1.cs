using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using ImageProcessor.Imaging.Formats;

namespace MultiThreadedBulkImageConverter
{
    public partial class Form1 : Form
    {
        BackgroundWorker workerThread = null;
        public delegate void ImageEvent(ImageOpsEventArgs args);
        public static event ImageEvent OnImageConversionStart;
        public static event ImageEvent OnImageConversionComplete;
        public Form1()
        {
            InitializeComponent();
            //InstatiateWorkerThread();
            SetupControls();
            OnImageConversionStart += new ImageEvent(ImageOps_OnImageConversionStart);
            OnImageConversionComplete += new ImageEvent(ImageOps_OnImageConversionComplete);

        }

        private void ImageOps_OnImageConversionComplete(ImageOpsEventArgs args)
        {
            lblStatus.Text = "Converting " + args.ImageFilename + "...";
            lblStatus.Refresh();
            //prgStatus.Value++;
        }

        private void ImageOps_OnImageConversionStart(ImageOpsEventArgs args)
        {
            lblStatus.Text = "Converted " + args.ImageFilename;
            lblStatus.Refresh();
            prgStatus.Value++;
        }

        /// <summary>
        /// Sets up the controls on the form.  No kidding.
        /// </summary>
        protected void SetupControls()
        {
            PopulateImageTypeCombo(cboSourceTypes);
            PopulateImageTypeCombo(cboOutputTypes);
            //cboSourceTypes.Items = cboSourceTypes.Items;
        }

        private void PopulateImageTypeCombo(ComboBox pCombo)
        {
            PropertyInfo[] props;

            try
            {
                //Get the static properties of the ImageFormat class
                //props = typeof(System.Drawing.Imaging.ImageFormat).GetProperties(BindingFlags.Static);
                props = typeof(System.Drawing.Imaging.ImageFormat).GetProperties(BindingFlags.Static | BindingFlags.Public);

                //Loop through each property and add to the specified ComboBox
                //pCombo.Items.AddRange(props); //Can't do it this way, as ToString() returns the long name
                foreach (PropertyInfo prop in props)
                {
                    if (prop.Name != "MemoryBmp" && prop.Name != "Icon")
                        pCombo.Items.Add(prop.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to load available image types:\n\n" + ex.Message,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                props = null;
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = null;

            try
            {
                dlg = new FolderBrowserDialog();
                if (dlg.ShowDialog() != DialogResult.Cancel)
                    txtImageDirectory.Text = dlg.SelectedPath;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dlg != null)
                    dlg.Dispose();
            }
        }

        /// <summary>
        /// Gets the file extensions for the selected input ImageFormat
        /// </summary>
        /// <returns>An array of strings containing the file extensions which apply to the selected input 
        /// ImageFormat</returns>
        protected string[] GetFileMasks()
        {
            string imageType = cboSourceTypes.Text;

            try
            {
                switch (imageType)
                {
                    case "Icon":
                        return new string[] { "*.ico", "*.icon" };

                    case "Jpeg":
                        return new string[] { "*.jpg", "*.jpeg" };

                    case "Tiff":
                        return new string[] { "*.tif", "*.tiff" };

                    default:
                        return new string[] { "*." + imageType };
                }
            }
            finally
            {
                imageType = null;
            }
        }


        /// <summary>
        /// Gets the appropriate extension to use for the selected output image format
        /// </summary>
        /// <returns>A string containing the appropriate file extenstion to use for output files</returns>
        protected string GetOutputExtension()
        {
            switch (cboOutputTypes.Text)
            {
                case "Icon":
                    return "ico";

                case "Jpeg":
                    return "jpg";

                case "Tiff":
                    return "tif";

                default:
                    return cboOutputTypes.Text;
            }
        }


        /// <summary>
        /// Toggles the Enabled property of the input controls
        /// </summary>
        /// <param name="Enable">A boolean indicating whether or not the controls should be enabled</param>
        protected void ToggleInputEnable(bool Enable)
        {
            txtImageDirectory.Enabled = Enable;
            BtnBrowse.Enabled = Enable;
            cboSourceTypes.Enabled = Enable;
            cboOutputTypes.Enabled = Enable;
            chkDeleteAfterConvert.Enabled = Enable;
            btnStart.Enabled = Enable;
            btnExit.Enabled = Enable;
        }


        private void LnkSourceForgeProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Open link to my SourceForge page
            System.Diagnostics.Process.Start("http://sourceforge.net/users/slade73/");
        }

        /// <summary>
        /// Gets the number of files from the specified directory which match the supplied filemask
        /// </summary>
        /// <param name="directory">The directory to get a file count from</param>
        /// <param name="fileMasks">The filemask(s) to count</param>
        /// <param name="includeSubDirs">Specifies whether subdirectories of the specified directory should 
        /// be included</param>
        /// <returns>The total number of files from the specified directory which match the supplied filemask</returns>
        private int GetFileCount(string directory, string[] fileMasks, bool includeSubDirs)
        {
            int totalFiles = 0;

            foreach (string fileMask in fileMasks)
            {
                totalFiles += Directory.GetFiles(directory, fileMask).Length;
            }

            //If we're including subdirectories, recursively call this function for each subdirectory
            if (includeSubDirs)
            {
                foreach (string dir in Directory.GetDirectories(directory))
                {
                    totalFiles += GetFileCount(dir, fileMasks, true);
                }
            }

            return totalFiles;
        }

        /// <summary>
        /// Gets the appropriate type of ImageFormat based on the user's output format selection
        /// </summary>
        /// <returns>The ImageFormat object for the user's output format selection</returns>
        protected ImageFormat GetSelectedOutputImageFormat()
        {
            Type type = null;

            try
            {
                type = typeof(ImageFormat);
                return (ImageFormat)type.InvokeMember(cboOutputTypes.SelectedItem.ToString(), BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty, null, null, null);
            }
            finally
            {
                type = null;
            }
        }
        private void BtnStart_ClickAsync(object sender, EventArgs e)
        {
            ImageFormat format = null;
            string[] inputFileMasks = null;
            inputFileMasks = GetFileMasks(cboSourceTypes.Text);
            format = GetSelectedOutputImageFormat();
            SearchOption subfolders;
            if (chkIncludeSubDirs.Checked)
            {
                subfolders = SearchOption.AllDirectories;
            }
            else
            {
                subfolders = SearchOption.TopDirectoryOnly;
            }
            int totalFiles = GetFileCount(txtImageDirectory.Text, inputFileMasks, chkIncludeSubDirs.Checked);
            if (totalFiles == 0)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("There are no files of the type you specified in the chosen directory.",
                    "No files to convert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                prgStatus.Value = 0;
                prgStatus.Maximum = totalFiles;
            }
            ReadAndProcessFilesAsync(txtImageDirectory.Text, subfolders, inputFileMasks, format, chkDeleteAfterConvert.Checked, FilenameAlreadyExistsOption.Ask);
            if (!OKToProceed()) return;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReadAndProcessFilesAsync(
            string filePath, 
            SearchOption includeSubDirs, 
            string[] convertFromFileMasks, 
            ImageFormat convertTo, 
            bool deleteAfterConversion,
            FilenameAlreadyExistsOption filenameAlreadyExistsOption)
        {
            // Our thread-safe collection used for the handover.
            var instructionsToProcess = new BlockingCollection<Instruction>();
            frmFileExists frmExists = null;
            string newFilename = null;
            string outputExt = null;
            ParallelOptions parallelOptions = FigureOutParallelOptions(cbParallelOptions.Text);
            int parallelInt = 1;
            bool filesizeChecked = false;

            // Build the pipeline.
            var stage1 = Task.Run(() =>
            {
                try
                {
                    outputExt = GetOutputExtension(convertTo.ToString()).ToLower();
                    foreach (var fileMask in convertFromFileMasks)
                    {
                        foreach (string item in System.IO.Directory.EnumerateFiles(filePath, fileMask, includeSubDirs))
                        {
                            if (!filesizeChecked)
                            {
                                
                                //parallelOptions = FigureOutParallelOptions(item, chkRunParallel.Checked);
                                parallelInt = parallelOptions.MaxDegreeOfParallelism;
                                filesizeChecked = true;
                            }
                            newFilename = Path.GetDirectoryName(item) + "\\" + Path.GetFileNameWithoutExtension(item) + "." + outputExt;
                            Instruction instruction = new Instruction(inputFileName: item, outputFileName: newFilename, formatToOutput: convertTo, parallelOptions: parallelOptions);
                            if (File.Exists(item))
                            {
                                switch (filenameAlreadyExistsOption)
                                {
                                    case FilenameAlreadyExistsOption.Ask:
                                        //Display dialog asking user what to do
                                        if (frmExists == null)
                                            frmExists = new frmFileExists(filePath + "\\" + newFilename);
                                        else
                                            frmExists.Filename = filePath + "\\" + newFilename;

                                        frmExists.ShowDialog();
                                        if (frmExists.AlwaysUseSelectedOption)
                                        {
                                            if (frmExists.Overwrite)
                                                filenameAlreadyExistsOption = FilenameAlreadyExistsOption.Overwrite;
                                            else
                                                filenameAlreadyExistsOption = FilenameAlreadyExistsOption.Skip;
                                        }
                                        break;
                                    case FilenameAlreadyExistsOption.Overwrite:
                                        break;
                                    case FilenameAlreadyExistsOption.Skip:
                                        continue;
                                }
                            }

                            instructionsToProcess.Add(instruction);
                        } 
                    }
                }
                finally
                {
                    instructionsToProcess.CompleteAdding();
                }
            });
            

            var stage2 = Task.Run(() =>
                {
                // Process lines on a ThreadPool thread
                // as soon as they become available.
                

                    //parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = parallelInt };
                    Parallel.ForEach(instructionsToProcess.GetConsumingEnumerable(), parallelOptions, instruction =>
                    {
                        instruction.Process();
                    });
                });

            // Block until both tasks have completed.
            // This makes this method prone to deadlocking.
            // Consider using 'await Task.WhenAll' instead.
            //await Task.WhenAll(stage1, stage2);
            Task.WaitAll(stage1, stage2);
        }

        private ParallelOptions FigureOutParallelOptions(string selectedText)
        {
            switch (selectedText)
            {
                case "100%":
                    return new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
                    break;
                case "75%":
                    return new ParallelOptions { MaxDegreeOfParallelism =  Convert.ToInt32(Environment.ProcessorCount * 0.75) };
                    break;
                case "50%":
                    return new ParallelOptions { MaxDegreeOfParallelism = Convert.ToInt32(Environment.ProcessorCount * 0.5) };
                    break;
                case "25%":
                    return new ParallelOptions { MaxDegreeOfParallelism = Convert.ToInt32(Environment.ProcessorCount * 0.25) };
                    break;
                case "0":
                    return new ParallelOptions { MaxDegreeOfParallelism = 1 };
                    break;
                default:
                    return new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
                    break;
            }
        }

        /// <summary>
        /// Allows us to automatically set the parallelism for the conversion task.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="wasParallelChecked"></param>
        /// <returns></returns>
        private ParallelOptions FigureOutParallelOptions(string file, bool wasParallelChecked)
        {
            if (wasParallelChecked)
            {
                int OneMegaByte = 1 * 1024 * 1024;
                int FiveMegaBytes = 5 * 1024 * 1024;
                int TenMegaBytes = 10 * 1024 * 1024;
                int OneHundredMegaBytes = 100 * 1024 * 1024;

                FileInfo fileToCheck = new FileInfo(file);
                var fileSize = fileToCheck.Length;
                if (fileSize < OneMegaByte)
                {
                    return new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
                }
                else if (fileSize > OneMegaByte && fileSize < FiveMegaBytes)
                {
                    return new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount / 2 };
                }
                else if (fileSize > FiveMegaBytes && fileSize < TenMegaBytes)
                {
                    return new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount / 4 };
                }
                else
                {
                    return new ParallelOptions { MaxDegreeOfParallelism = 1 };
                } 
            }
            else
            {
                return new ParallelOptions { MaxDegreeOfParallelism = 1 };
            }

        }

        private static ISupportedImageFormat GetFormatFromSelectedOutput(ImageFormat convertTo)
        {
            ISupportedImageFormat format = null;
            switch (convertTo.ToString())
            {
                case "Jpeg":
                    format = new JpegFormat { };
                    break;
                case "Png":
                    format = new PngFormat { };
                    break;
                case "Tiff":
                    format = new TiffFormat { };
                    break;
                default:
                    break;
            }
            return format;

        }

        /// <summary>
        /// Determines whether or not all of the required information for converting images has been supplied and 
        /// is valid
        /// </summary>
        /// <returns>true if the required information is present and valid, false otherwise</returns>
        protected bool OKToProceed()
        {
            DialogResult delete;

            //Make sure a directory has been specified
            if (txtImageDirectory.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Please specify a directory containing images you wish to convert.",
                    "No directory specified",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            //Make sure specified directory exists
            if (!Directory.Exists(txtImageDirectory.Text))
            {
                MessageBox.Show("The directory you specifed, \"" + txtImageDirectory.Text + "\", does not exist.",
                    "Directory not found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            //Make sure user has selected image formats
            if (cboSourceTypes.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the type of image files you wish to convert.",
                    "No source image format selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (cboOutputTypes.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the format to convert your image files to.",
                    "No output image format selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            //If the user has specified that the original images should be deleted after conversion, prompt to
            //confirm
            if (chkDeleteAfterConvert.Checked)
            {
                /*
                if (MessageBox.Show("You have chen to delete the original image files after they're converted.\n\nAre you sure?",
                    "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
                */
                delete = MessageBox.Show("You have chosen to delete the original image files after they're converted.\n\n" +
                                        "This should only be done if you are sure that the converted images will be satisfactory.\n\n" +
                                        "Are you sure you want to delete the original image files after conversion?",
                    "WARNING - Please confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (delete)
                {
                    case DialogResult.Cancel:
                        return false;

                    case DialogResult.No:
                        chkDeleteAfterConvert.Checked = false;
                        break;

                    case DialogResult.Yes:
                        break; //No change required.  Keep going.
                }
            }

            //Still here?  Everything's OK, return true.
            return true;
        }

        /// <summary>
        /// Gets the appropriate extension to use for the selected output image format
        /// </summary>
        /// <param name="inputExtension"></param>
        /// <returns>A string containing the appropriate file extenstion to use for output files</returns>
        private string GetOutputExtension(string inputExtension)
        {
            switch (inputExtension)
            {
                case "Icon":
                    return "ico";

                case "Jpeg":
                    return "jpg";

                case "Tiff":
                    return "tif";

                default:
                    return inputExtension;
            }
        }

        private enum FilenameAlreadyExistsOption
        {
            Ask,
            Overwrite,
            Skip
        }

        private static Bitmap GetGrayscale(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);

            using (Graphics gfx = Graphics.FromImage(output))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                      {
                         new float[] {.3f, .3f, .3f, 0, 0},
                         new float[] {.59f, .59f, .59f, 0, 0},
                         new float[] {.11f, .11f, .11f, 0, 0},
                         new float[] {0, 0, 0, 1, 0},
                         new float[] {0, 0, 0, 0, 1}
                      });

                ImageAttributes attributes = new ImageAttributes();

                attributes.SetColorMatrix(colorMatrix);

                gfx.DrawImage(input, new Rectangle(0, 0, input.Width, input.Height),
                   0, 0, input.Width, input.Height, GraphicsUnit.Pixel, attributes);
            }

            return output;
        }

        /// <summary>
        /// Gets the file masks which apply to the specified image type
        /// </summary>
        /// <param name="imageType"></param>
        /// <returns></returns>
        public static string[] GetFileMasks(string imageType)
        {
            switch (imageType)
            {
                case "Icon":
                    return new string[] { "*.ico", "*.icon" };

                case "Jpeg":
                    return new string[] { "*.jpg", "*.jpeg" };

                case "Tiff":
                    return new string[] { "*.tif", "*.tiff" };

                default:
                    return new string[] { "*." + imageType };
            }
        }
    }
}
