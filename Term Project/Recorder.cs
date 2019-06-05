using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;


namespace Term_Project
{
    public unsafe class Recorder
    {
        [DllImport("Dll1.dll", CharSet = CharSet.Auto)]
        public static extern Boolean start();
        [DllImport("Dll1.dll", CharSet = CharSet.Auto)]
        public static extern byte** getSaveBuffer();
        [DllImport("Dll1.dll", CharSet = CharSet.Auto)]
        public static extern byte** getPlayBuffer();
        [DllImport("Dll1.dll", CharSet = CharSet.Auto)]
        public static extern ulong getDataLength();
        /** Method to get save buffer from DLL */
        public byte** getSave() {
            return getSaveBuffer();
        }
        /** Method to get play buffer from DLL */
        public byte** getPlay()
        {
            return getPlayBuffer();
        }
        /** Method to get data length from DLL */
        public ulong getData()
        {
            return getDataLength();
        }
        /**Method to launch the recorder*/
        public void launch()
        {
            start();
        }

    }
}
