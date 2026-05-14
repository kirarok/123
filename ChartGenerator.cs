using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BoilerCalc
{
    /// <summary>
    /// Генератор I-θ диаграммы в виде PNG изображения
    /// </summary>
    public static class ChartGenerator
    {
        /// <summary>
        /// Создаёт I-θ диаграмму и сохраняет как PNG
        /// </summary>
        public static string CreateIThetaDiagram(double[,] data, string filePath)
        {
            if (data == null || data.GetLength(0) < 5 || data.GetLength(1) < 2)
                return null;

            int cols = data.GetLength(1);
            int width = 1200, height = 800;
            int margin = 80;

            using (Bitmap bmp = new Bitmap(width, height))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                // Цвета линий
                Color[] colors = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange };
                string[] labels = { "Iг0 (продукты α=1)", "Iв0 (воздух)", "Iг(αт) - топка", "Iзл (зола)", "Iг(αух)" };
                int[] dataRows = { 1, 2, 3, 4, 3 }; // row indices, row 3=газоход топки, 4=нет, используем 3
            
                // Находим min/max
                double minT = data[0, 0], maxT = data[0, cols - 1];
                double minI = double.MaxValue, maxI = double.MinValue;
                for (int r = 0; r < Math.Min(5, data.GetLength(0)); r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (data[r, c] < minI) minI = data[r, c];
                        if (data[r, c] > maxI) maxI = data[r, c];
                    }
                }
                if (minI == maxI) maxI = minI + 100;
                if (minI < 0) minI = 0;
            
                int graphW = width - 2 * margin;
                int graphH = height - 2 * margin;

                // --- Сетка ---
                using (Pen gridPen = new Pen(Color.LightGray, 1))
                using (Pen axisPen = new Pen(Color.Black, 2))
                using (Font font = new Font("Arial", 10))
                using (Font titleFont = new Font("Arial", 14, FontStyle.Bold))
                using (Brush textBrush = Brushes.Black)
                {
                    // Заголовок
                    g.DrawString("I-θ диаграмма продуктов сгорания", titleFont, textBrush, width / 2 - 200, 10);

                    // Оси
                    g.DrawLine(axisPen, margin, margin, margin, height - margin);
                    g.DrawLine(axisPen, margin, height - margin, width - margin, height - margin);

                    // Подписи осей
                    g.DrawString("θ, °C", font, textBrush, width / 2 - 20, height - 30);
                    g.DrawString("I, кДж/кг", font, textBrush, 5, height / 2 - 40);

                    // Засечки X
                    int xSteps = 8;
                    for (int i = 0; i <= xSteps; i++)
                    {
                        double tVal = minT + (maxT - minT) * i / xSteps;
                        int x = margin + (int)(graphW * i / xSteps);
                        g.DrawLine(gridPen, x, margin, x, height - margin);
                        g.DrawString(tVal.ToString("F0"), font, textBrush, x - 15, height - margin + 5);
                    }

                    // Засечки Y
                    int ySteps = 6;
                    for (int i = 0; i <= ySteps; i++)
                    {
                        double iVal = minI + (maxI - minI) * i / ySteps;
                        int y = height - margin - (int)(graphH * i / ySteps);
                        g.DrawLine(gridPen, margin, y, width - margin, y);
                        string label = (iVal / 1000).ToString("F1") + "k";
                        g.DrawString(label, font, textBrush, 2, y - 8);
                    }

                    // Кривые
                    for (int r = 0; r < data.GetLength(0) - 1; r++)
                    {
                        if (r > 4) break;
                        using (Pen curvePen = new Pen(colors[r % colors.Length], 2))
                        {
                            PointF[] points = new PointF[cols];
                            for (int c = 0; c < cols; c++)
                            {
                                double t = data[0, c];
                                double iVal = data[r + 1, c];
                                if (r == 4) continue; // skip
                                double x = margin + (t - minT) / (maxT - minT) * graphW;
                                double yPos = height - margin - (iVal - minI) / (maxI - minI) * graphH;
                                points[c] = new PointF((float)x, (float)yPos);
                            }
                            g.DrawLines(curvePen, points);
                        }
                    }

                    // Легенда
                    int legX = width - 350;
                    int legY = 40;
                    for (int r = 0; r < Math.Min(data.GetLength(0) - 1, 5); r++)
                    {
                        using (Pen legPen = new Pen(colors[r % colors.Length], 3))
                        {
                            g.DrawRectangle(legPen, legX, legY + r * 22, 20, 12);
                            g.FillRectangle(new SolidBrush(colors[r % colors.Length]), legX + 1, legY + r * 22 + 1, 19, 11);
                            g.DrawString(labels[r % labels.Length], font, textBrush, legX + 25, legY + r * 22);
                        }
                    }
                }

                // Сохраняем
                string dir = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                bmp.Save(filePath, ImageFormat.Png);
            }
            return filePath;
        }
    }
}