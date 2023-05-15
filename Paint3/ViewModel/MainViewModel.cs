using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;
using Paint3.ViewModel.Helpers;

namespace Paint3.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
      Menu window = new Menu();
        public ObjectCommand AddCommand { get; set; }
        public ObjectCommand AddCommand2 { get; set; }
        public ObjectCommand AddCommandR1 { get; set; }
        public ObjectCommand AddCommandR2 { get; set; }
        public ObjectCommand AddCommandR3 { get; set; }
        public ObjectCommand AddCommandRED { get; set; }
        public ObjectCommand AddCommandBlue { get; set; }
        public ObjectCommand AddCommandBlack { get; set; }
        public ObjectCommand AddCommandYellou { get; set; }
        public ObjectCommand AddCommandGreen { get; set; }
        public ObjectCommand AddCommandPink { get; set; }
        public ObjectCommand AddCommandGray { get; set; }


        public MainViewModel()
        {
            AddCommand = new ObjectCommand(_ => Button_Click());

            AddCommand2 = new ObjectCommand(_ => Button_Click2());

            AddCommandR1 = new ObjectCommand(_ => Red_Click_1());

            AddCommandR2 = new ObjectCommand(_ => Red_Click_2());

            AddCommandR3 = new ObjectCommand(_ => Red_Click_3());

            AddCommandRED = new ObjectCommand(_ => Red());

            AddCommandBlue = new ObjectCommand(_ => Blue());

            AddCommandBlack = new ObjectCommand(_ => Black());

            AddCommandYellou = new ObjectCommand(_ => Yellow());

            AddCommandGreen = new ObjectCommand(_ => Green());

            AddCommandPink = new ObjectCommand(_ => Pink());

            AddCommandGray = new ObjectCommand(_ => Gray());
        }

        private void Button_Click()
        {
            window.Paint.Strokes.Clear();
        }

        private void Button_Click2()
        {
            string imgPath = @"C:\Temp\file.gif";
            MemoryStream ms = new MemoryStream();
            FileStream fs = new FileStream(imgPath, FileMode.Create);


            RenderTargetBitmap rtb = new RenderTargetBitmap((int)window.Paint.Width, (int)window.Paint.Height, 96, 96, PixelFormats.Default);
            rtb.Render(window.Paint);

            GifBitmapEncoder gifEnc = new GifBitmapEncoder();
            gifEnc.Frames.Add(BitmapFrame.Create(rtb));
            gifEnc.Save(fs);
            fs.Close();
            MessageBox.Show("Файл сохранен, " + imgPath);
        }
        private void Red_Click_1()
        {
            window.Paint.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }
        private void Red_Click_2()
        {
            window.Paint.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void Red_Click_3()
        {
            window.Paint.EditingMode = InkCanvasEditingMode.Select;
        }

        private void Red()
        {
            window.Paint.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void Blue()
        {
            window.Paint.DefaultDrawingAttributes.Color = Colors.Blue;
        }

        private void Black()
        {
            window.Paint.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void Yellow()
        {
            window.Paint.DefaultDrawingAttributes.Color = Colors.Yellow;
        }

        private void Green()
        {
            window.Paint.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void Pink()
        {
            window.Paint.DefaultDrawingAttributes.Color = Colors.Pink;
        }

        private void Gray()
        {
            window.Paint.DefaultDrawingAttributes.Color = Colors.Gray;
        }

    }
}

