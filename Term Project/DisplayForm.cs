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
    public unsafe partial class DisplayForm : Form
    {
        
        double[] global_freq; 
        double[] global_amp; 
        Complex[] global_complex;
        double[] copiedPoints = null; 
        Selection freq_select = new Selection();
        Selection amp_select = new Selection();
        Windowing window = new Windowing();
        Recorder record = new Recorder();
        wave_file wavFile = new wave_file();
        public DisplayForm()
        {
            InitializeComponent();
            freqChart.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = Enabled;
            freqChart.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = Enabled;
            freqChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = false;
            DFTChart.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = Enabled;
            DFTChart.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = Enabled;
            DFTChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = false;
            filterToolStripMenuItem.Enabled = false;
            freqChart.Series[0].ChartType = SeriesChartType.FastLine;
            DFTChart.Series[0].ChartType = SeriesChartType.FastLine;
            this.Size = new System.Drawing.Size(1000, 500);
            DFTChart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
        }
        /**Method to apply DFT on selected points*/
        private Complex[] DFT(double[] s)
        {
            double real;
            double imaginary;
            int n = s.Length;
            Complex[] cmplx = new Complex[n];
            global_amp = new double[n];
            for (int f = 0; f < n; f++)
            {
                real = 0;
                imaginary = 0;
                for (int t = 0; t < n; t++)
                {
                    real += 1.0 / n * s[t] * Math.Cos(2 * Math.PI * t * f / n);
                    imaginary -= 1.0 / n * s[t] * Math.Sin(2 * Math.PI * t * f / n);
                }
                global_amp[f] = Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imaginary, 2));
                cmplx[f] = new Complex(real, imaginary);
            }
            return cmplx;
        }
        /**Method to plot point on Amplitude graph*/
        private void plot_DFT(double[] s)
        {
            double real;
            double imaginary;
            int n = s.Length;
            global_amp = new double[n];
            for (int f = 0; f < n; f++)
            {
                real = 0;
                imaginary = 0;
                for (int t = 0; t < n; t++)
                {
                    real += 1.0 / n * s[t] * Math.Cos(2 * Math.PI * t * f / n);
                    imaginary -= 1.0 / n * s[t] * Math.Sin(2 * Math.PI * t * f / n);
                }
               global_amp[f] = Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imaginary, 2));
            }
        }
        /**Method to apply inverse DFT */
        private double[] invDFT(Complex[] A)
        {
            int n = A.Length;
            double[] s = new double[n];

            for (int t = 0; t < n; t++)
            {
                s[t] = 0;
                for (int f = 0; f < n; f++)
                {
                    s[t] += A[f].real * Math.Cos(2 * Math.PI * f * t / n + Math.Atan2(A[f].imaginary, A[f].real));
                    s[t] -= A[f].imaginary * Math.Sin(2 * Math.PI * f * t / n + Math.Atan2(A[f].imaginary, A[f].real));
                }
            }
            return s;
        }
        /**Method to call our DFT function and plot it */
        private void applyDFT_Click(object sender, EventArgs e)
        {
            long diff = 1;

            double[] selected = new double[(int)(freq_select.getEnd() - freq_select.getStart())];
            for (int i = 0; i < (int)(freq_select.getEnd() - freq_select.getStart()); i++)
            {
                selected[i] = global_freq[(int)freq_select.getStart() + i];
            }
            if (selected.Length > 0)
            {
               diff = wavFile.SampleRate / selected.Length;
            }
            global_complex = DFT(selected);
            DFTChart.Series[0].Points.Clear();
            for ( int i = 0; i < selected.Length; i++)
            {
                double d = Math.Sqrt(Math.Pow(global_complex[i].getReal(), 2) + Math.Pow(global_complex[i].getImaginary(), 2));
                DFTChart.Series[0].Points.AddXY((i*diff),d);
            }
            windowingToolStripMenuItem.Enabled = true;
            filterToolStripMenuItem.Enabled = true;
            copiedPoints = null;
        }
        /**Method to call our inverseDFT function and plot it */
        private void inverseDFT_Click(object sender, EventArgs e)
        {
            global_freq = invDFT(global_complex);
            plotFreqWaveChart(global_freq);
        }
        /**Method to store selection points in our array.*/
        private void freqChart_Click(object sender, EventArgs e)
        {
            double start = freqChart.ChartAreas[0].CursorX.SelectionStart;
            double end = freqChart.ChartAreas[0].CursorX.SelectionEnd;
            if (selection_button.Text == "Selection")
            {
                if (start < end)
                {
                    freq_select.setStart(start);
                    freq_select.setEnd(end);
                }
                else
                {
                    freq_select.setStart(end);
                    freq_select.setEnd(start);
                }
            }
           
            freqChart.Series[0].ChartArea = "ChartArea1";
        }
        /**Selection for point on our Amplitude chart. */
        private void DFTChart_Click(object sender, EventArgs e)
        {
            double start = DFTChart.ChartAreas[0].CursorX.SelectionStart;
            double end = DFTChart.ChartAreas[0].CursorX.SelectionEnd;
            if (selection_button.Text == "Selection")
            {
                if (start < end)
                {
                    amp_select.setStart(start);
                    amp_select.setEnd(end);
                }
                else
                {
                    amp_select.setStart(end);
                    amp_select.setEnd(start);
                }
            }
        }
        /**Allows us to open a wav file and display its' data.*/
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               OpenFile(openFileDialog1.FileName);
            }
        }
        /**Method to read in a wave file and convert it into an array.*/
        public double[] readWave(string fileName)
        {
            byte[] byteArray;

            BinaryReader reader = new BinaryReader(File.OpenRead(fileName));
            wavFile.clear();
            wavFile.ChunkID = reader.ReadInt32();
            wavFile.ChunkSize = reader.ReadInt32();
            wavFile.Format = reader.ReadInt32();
            wavFile.SubChunk1ID = reader.ReadInt32();
            wavFile.SubChunk1Size = reader.ReadInt32();
            wavFile.AudioFormat = reader.ReadUInt16();
            wavFile.NumChannels = reader.ReadUInt16();
            wavFile.SampleRate = reader.ReadUInt32();
            wavFile.ByteRate = reader.ReadUInt32();
            wavFile.BlockAlign = reader.ReadUInt16();
            wavFile.BitsPerSample = reader.ReadUInt16();
            wavFile.SubChunk2ID = reader.ReadInt32();
            wavFile.SubChunk2Size = reader.ReadInt32();
            byteArray = reader.ReadBytes((int)wavFile.SubChunk2Size);
            short[] shortAr = new short[wavFile.SubChunk2Size / wavFile.BlockAlign];
            double[] arr;
            for (int i = 0; i < wavFile.SubChunk2Size / wavFile.BlockAlign; i++) {
                shortAr[i] = BitConverter.ToInt16(byteArray, i * wavFile.BlockAlign);
            }
            arr = shortAr.Select(x => (double)(x)).ToArray();
            reader.Close();
            return arr;
        }
        /**Method to open a file and plot it.*/
        public void OpenFile(string fileName)
        {
            this.Text = fileName; 
            global_freq = readWave(fileName);

            freqChart.Series[0].Points.Clear(); 
            plotFreqWaveChart(global_freq);
        }
        
        /**Calls our Save File function and creates a new file.*/
        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save a Wave File";
            saveFileDialog1.Filter = "Wave Files (*.wav)|*.wav";
            saveFileDialog1.DefaultExt = "wav";
            saveFileDialog1.AddExtension = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile(saveFileDialog1.FileName);
            }
        }
        /**Method to save to a file.*/
        public void SaveFile(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                BinaryWriter wr = new BinaryWriter(fs);
                this.Text = fileName;
                fwrite(wr, wavFile);
                int[] intAr = global_freq.Select(x => Convert.ToInt32(Math.Round(x))).ToArray();
                byte[] waveByteData = intAr.Select(x => Convert.ToInt32(x)).SelectMany(x => BitConverter.GetBytes(x)).ToArray();
                fwrite(wr, waveByteData.Length, waveByteData);
                fs.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        /**Method to write to a file.*/
        public void fwrite(BinaryWriter file, int samples, byte[] data)
        {   
            for (int i = 0; i < samples; i++) {
                file.Write(data[i]);
            }
        }
        /**Method to write to a file.*/
        public void fwrite(BinaryWriter file, wave_file waveHead)
        {
            file.Write(waveHead.ChunkID);
            file.Write(waveHead.ChunkSize);
            file.Write(waveHead.Format);
            file.Write(waveHead.SubChunk1ID);
            file.Write(waveHead.SubChunk1Size);
            file.Write(waveHead.AudioFormat);
            file.Write(waveHead.NumChannels);
            file.Write(waveHead.SampleRate);
            file.Write(waveHead.ByteRate);
            file.Write(waveHead.BlockAlign);
            file.Write(waveHead.BitsPerSample);
            file.Write(waveHead.SubChunk2ID);
            file.Write(waveHead.SubChunk2Size);
        }
        /**Method to plot our frequency on the chart*/
        public void plotFreqWaveChart(double[] freq)
        {
            this.freqChart.Series[0].Points.Clear();
            
            for (int m = 0; m < freq.Length; m++)
            {
                this.freqChart.Series[0].Points.AddXY(m, freq[m]);
            }
            this.freqChart.ChartAreas[0].AxisX.Minimum = 0;
           
        }
        /**Method to plot the amplitude after DFT */
        public void plotAmpWaveChart()
        {
            global_complex = DFT(global_amp);
            DFTChart.Series[0].Points.Clear();
            
            for (int i = 0; i < global_complex.Length; i++)
            {
               double d = Math.Sqrt(Math.Pow(global_complex[i].getReal(), 2) + Math.Pow(global_complex[i].getImaginary(), 2));
               DFTChart.Series[0].Points.AddY(d);
            }
        }
        /**Launches our recorder*/
        private void record_Click(object sender, EventArgs e)
        {
            record.launch();
           
        }
       
        /**Selected points will be stored into a double array*/
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copiedPoints = new double[(int)(freq_select.getEnd() - freq_select.getStart())];
            for (int i = 0; i < (int)(freq_select.getEnd() - freq_select.getStart()); i++) {
                copiedPoints[i] = global_freq[(int)freq_select.getStart() + i];
            }
        }
        /** Deletes selected points and stores them into an array that will be ready to be pasted.*/
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copiedPoints = new double[(int)(freq_select.getEnd() - freq_select.getStart())];
            for (int i = 0; i < (int)(freq_select.getEnd() - freq_select.getStart()); i++)
            {
               copiedPoints[i] = global_freq[(int)freq_select.getStart() + i];
            }
            List<double> list = new List<double>(global_freq);
            list.RemoveRange((int)freq_select.getStart(), (int)(freq_select.getEnd() - freq_select.getStart()));
            global_freq = list.ToArray();
            plotFreqWaveChart(global_freq);
        }
        /**Paste the copied points onto our frequency chart.*/
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] temp = new double[global_freq.Length + copiedPoints.Length];
            int selectionSize = copiedPoints.Length;
            for (int i = 0, j = 0; i < temp.Length; i++, j++)
            {
                if (i == freq_select.getStart())
                {
                    for (int l = 0; l < copiedPoints.Length; l++, i++)
                    {
                        temp[i] = copiedPoints[l];
                    }
                }
                else
                {
                    temp[i] = global_freq[j];
                }
            }
            global_freq = temp;
            plotFreqWaveChart(global_freq);
        }
        /** Switch between selection and zooming */
        private void selection_button_Click(object sender, EventArgs e)
        {
            if (selection_button.Text == "Zoomable")
            {
                selection_button.Text = "Selection";
                freqChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = false;
                DFTChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = false;
                editToolStripMenuItem.Enabled = true;
            } else if (selection_button.Text == "Selection")
            {
                selection_button.Text = "Zoomable";
                editToolStripMenuItem.Enabled = false;
                freqChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
                DFTChart.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
            }

        }
        /**Applies Rectangular Windowing on our amplitude chart.*/
        private void rectangularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (freq_select.getStart() > 0)
            {
                int size = (int)(freq_select.getEnd() - freq_select.getStart());
                int start = (int)(freq_select.getStart());
                DFTChart.Series[0].Points.Clear();
                DFTChart.Series[0].ChartType = SeriesChartType.FastLine;
                global_complex = DFT(window.Rectangle(global_freq, size, start));
                if (freq_select.getEnd() < global_freq.Length)
                {
                    for (int i = 0; i < size; i++)
                    {
                        double d = Math.Sqrt(Math.Pow(global_complex[i].getReal(), 2) + Math.Pow(global_complex[i].getImaginary(), 2));
                        DFTChart.Series[0].Points.AddY(d);
                    }
                }
            }
        }
        /**Applies Triangle Windowing on our amplitude chart.*/
        private void triangularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (freq_select.getStart() > 0)
            {
                int size = (int)(freq_select.getEnd() - freq_select.getStart());
                int start = (int)(freq_select.getStart());
                DFTChart.Series[0].Points.Clear();
                DFTChart.Series[0].ChartType = SeriesChartType.FastLine;
                global_complex = DFT(window.Triangle(global_freq, size, start));
                if (freq_select.getEnd() < global_freq.Length)
                {
                    for (int i = 0; i < size; i++)
                    {
                        double d = Math.Sqrt(Math.Pow(global_complex[i].getReal(), 2) + Math.Pow(global_complex[i].getImaginary(), 2));
                        DFTChart.Series[0].Points.AddY(d);
                    }
                }
            }
        }
        /**Applies Welch Windowing on our amplitude chart.*/
        private void welchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (freq_select.getStart() > 0)
            {
                int size = (int)(freq_select.getEnd() - freq_select.getStart());
                int start = (int)(freq_select.getStart());
                DFTChart.Series[0].Points.Clear();
                DFTChart.Series[0].ChartType = SeriesChartType.FastLine;
                global_complex = DFT(window.Welch(global_freq, size, start));
                if (freq_select.getEnd() < global_freq.Length)
                {
                    for (int i = 0; i < size; i++)
                    {
                        double d = Math.Sqrt(Math.Pow(global_complex[i].getReal(), 2) + Math.Pow(global_complex[i].getImaginary(), 2));
                        DFTChart.Series[0].Points.AddY(d);
                    }
                }
            }
        }
        /**Creates the lowpass filer depending on selected points */
        private Complex[] lowpassFilter(double[] frequency)
        {
            int N = frequency.Length; 
            Complex[] outComplex = new Complex[N];
            double start = amp_select.getStart();
            for (int i = 0; i < (N / 2); i++)
            {
                if (N % 2 != 0)
                {
                    outComplex[N / 2] = new Complex(0, 0);
                }
                if (i < start)
                {
                    outComplex[i] = new Complex(1, 1);
                    outComplex[N - i - 1] = new Complex(1, 1);
                }
                else
                {
                    outComplex[i] = new Complex(0, 0);
                    outComplex[N - i - 1] = new Complex(0, 0);
                }
            }
            return outComplex;
        }
        
        private void convolution(double[] data, double[] signal)
        {
            int N = signal.Length;
            int WN = data.Length;
            double[] newSignal = new double[N];
            for (int n = 0; n < N; n++)
            {
                double temp = 0;
                for (int wn = 0; wn < WN; wn++)
                {
                    if ((n + wn) < (N - 1)) 
                        temp += data[wn] * signal[n + wn];
                    else
                        temp += 0;
                }
                newSignal[n] = temp;
            }
            global_freq = newSignal; 
        }
        /**Applies our lowpass filter onto the current frequency.*/
        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Complex[] filter = lowpassFilter(global_amp);
            convolution(invDFT(filter), global_freq);
            plotFreqWaveChart(global_freq);
            plotAmpWaveChart();
        }
    }
}
